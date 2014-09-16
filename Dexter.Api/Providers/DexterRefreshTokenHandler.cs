﻿namespace Dexter.Api.Providers
{
    using System;
    using System.Threading.Tasks;

    using Dexter.Api.CommandHandlers;
    using Dexter.Api.Commands;
    using Dexter.Api.Entities;
    using Dexter.Api.Models;
    using Dexter.Api.Queries;
    using Dexter.Api.QueryHandlers;
    using Dexter.Api.Repositories;

    using Microsoft.Owin.Security.Infrastructure;

    public class DexterRefreshTokenHandler : IDexterRefreshTokenHandler
    {
        private readonly ICommandHandler<AddRefreshTokenCommand> addRefreshToken;

        private readonly ICommandHandler<RemoveRefreshTokenCommand> removeRefreshToken;

        private readonly IQueryHandler<GetRefreshTokenQuery, RefreshToken> getRefreshToken;

        public DexterRefreshTokenHandler(
            ICommandHandler<AddRefreshTokenCommand> addRefreshToken,
            ICommandHandler<RemoveRefreshTokenCommand> removeRefreshToken,
            IQueryHandler<GetRefreshTokenQuery, RefreshToken> getRefreshToken)
        {
            this.addRefreshToken = addRefreshToken;
            this.removeRefreshToken = removeRefreshToken;
            this.getRefreshToken = getRefreshToken;
        }

        public delegate IDexterRefreshTokenHandler Factory();

        public async Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            var refreshTokenId = RefreshTokenId.Create();

            var clientid = context.Ticket.Properties.Dictionary[Constants.TokenClientIdKey];

            if (string.IsNullOrEmpty(clientid))
            {
                return;
            }

            var refreshTokenLifeTime = context.OwinContext.Get<string>(Constants.TokenRefreshTokenLifeTimeKey);

            var token = new RefreshToken()
            {
                Id = Helper.GetHash(refreshTokenId.Value),
                ClientId = clientid,
                Username = context.Ticket.Identity.Name,
                IssuedUtc = DateTime.UtcNow,
                ExpiresUtc = DateTime.UtcNow.AddMinutes(Convert.ToDouble(refreshTokenLifeTime))
            };

            context.Ticket.Properties.IssuedUtc = token.IssuedUtc;
            context.Ticket.Properties.ExpiresUtc = token.ExpiresUtc;

            token.ProtectedTicket = context.SerializeTicket();

            await this.addRefreshToken.HandleAsync(new AddRefreshTokenCommand(token));

            context.SetToken(refreshTokenId.Value);
        }

        public async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            var allowedOrigin = context.OwinContext.Get<string>(Constants.TokenAllowedOriginKey);
            Helper.SetAccessControlAllowOrigin(context.OwinContext, allowedOrigin);

            var refreshTokenId = new RefreshTokenId(context.Token);
            var refreshToken = await this.getRefreshToken.HandleAsync(new GetRefreshTokenQuery(refreshTokenId));

            if (refreshToken != null)
            {
                // Get protectedTicket from refreshToken class
                context.DeserializeTicket(refreshToken.ProtectedTicket);

                // We can remove the current refresh token because a new one
                // is created in the CreateAsync method when a new auth token
                // is requested using the refresh token.
                await this.removeRefreshToken.HandleAsync(new RemoveRefreshTokenCommand(refreshTokenId));
            }
        }
    }
}