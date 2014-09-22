﻿namespace Dexter.Api.QueryHandlers
{
    using System.Threading.Tasks;

    using Dexter.Api.Entities;
    using Dexter.Api.Queries;
    using Dexter.Api.Repositories;

    public class GetRefreshTokenQueryHandler : IQueryHandler<GetRefreshTokenQuery, RefreshToken>
    {
        private readonly IRefreshTokenRepository refreshTokenRepository;

        public GetRefreshTokenQueryHandler(IRefreshTokenRepository refreshTokenRepository)
        {
            this.refreshTokenRepository = refreshTokenRepository;
        }

        public Task<RefreshToken> HandleAsync(GetRefreshTokenQuery query)
        {
            return this.refreshTokenRepository.TryGetRefreshTokenAsync(query.HashedRefreshTokenId.Value);
        }
    }
}