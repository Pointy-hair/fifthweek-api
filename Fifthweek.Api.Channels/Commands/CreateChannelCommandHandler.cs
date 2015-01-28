﻿namespace Fifthweek.Api.Channels.Commands
{
    using System;
    using System.Threading.Tasks;

    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Api.Subscriptions.Shared;
    using Fifthweek.CodeGeneration;

    [AutoConstructor]
    public partial class CreateChannelCommandHandler : ICommandHandler<CreateChannelCommand>
    {
        private readonly IRequesterSecurity requesterSecurity;
        private readonly ISubscriptionSecurity subscriptionSecurity;
        private readonly IFifthweekDbContext databaseContext;

        public async Task HandleAsync(CreateChannelCommand command)
        {
            command.AssertNotNull("command");

            var userId = await this.requesterSecurity.AuthenticateAsync(command.Requester);
            await this.subscriptionSecurity.AssertWriteAllowedAsync(userId, command.SubscriptionId);

            await this.CreateChannelAsync(command);
        }

        private Task CreateChannelAsync(CreateChannelCommand command)
        {
            var channel = new Channel(
                command.NewChannelId.Value,
                command.SubscriptionId.Value,
                null,
                command.Name.Value,
                command.Price.Value,
                DateTime.UtcNow);

            return this.databaseContext.Database.Connection.InsertAsync(channel);
        }
    }
}