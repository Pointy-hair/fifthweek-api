﻿namespace Fifthweek.Api.Subscriptions.Commands
{
    using System;
    using System.Threading.Tasks;
    using System.Transactions;

    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Api.Subscriptions.Shared;
    using Fifthweek.CodeGeneration;

    [AutoConstructor]
    public partial class CreateSubscriptionCommandHandler : ICommandHandler<CreateSubscriptionCommand>
    {
        private static readonly ValidChannelDescription DefaultChannelDescription = ValidChannelDescription.Parse(
            "Exclusive News Feed" + Environment.NewLine + "Early Updates on New Releases");

        private readonly ISubscriptionSecurity subscriptionSecurity;
        private readonly IRequesterSecurity requesterSecurity;
        private readonly IFifthweekDbConnectionFactory connectionFactory;

        public async Task HandleAsync(CreateSubscriptionCommand command)
        {
            command.AssertNotNull("command");

            var authenticatedUserId = await this.requesterSecurity.AuthenticateAsync(command.Requester);

            await this.subscriptionSecurity.AssertCreationAllowedAsync(authenticatedUserId);

            await this.CreateEntitiesAsync(command, authenticatedUserId);
        }

        private async Task CreateEntitiesAsync(CreateSubscriptionCommand command, UserId authenticatedUserId)
        {
            var subscription = new Subscription(
                command.NewSubscriptionId.Value,
                authenticatedUserId.Value,
                null,
                command.SubscriptionName.Value,
                command.Tagline.Value,
                ValidIntroduction.Default.Value,
                null,
                null,
                null,
                null,
                DateTime.UtcNow);

            var channel = new Channel(
                command.NewSubscriptionId.Value, // Default channel uses same ID as subscription.
                command.NewSubscriptionId.Value,
                null,
                DefaultChannelDescription.Value,
                null,
                command.BasePrice.Value,
                true,
                DateTime.UtcNow);

            // Assuming no lock escalation, this transaction will hold X locks on the new rows and IX locks further up the hierarchy,
            // so no deadlocks are to be expected.
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                using (var connection = this.connectionFactory.CreateConnection())
                {
                    await connection.InsertAsync(subscription);
                    await connection.InsertAsync(channel);
                }

                transaction.Complete();
            }
        }
    }
}