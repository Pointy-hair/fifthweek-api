﻿namespace Fifthweek.Api.Subscriptions.Commands
{
    using System;
    using System.Threading.Tasks;

    using Fifthweek.Api.Core;
    using Fifthweek.Api.Persistence;

    [AutoConstructor]
    public partial class UpdateSubscriptionCommandHandler : ICommandHandler<UpdateSubscriptionCommand>
    {
        private readonly IFifthweekDbContext databaseContext;
        private readonly ISubscriptionSecurity subscriptionSecurity;

        public async Task HandleAsync(UpdateSubscriptionCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }

            var isUpdateAllowed = await this.subscriptionSecurity.IsUpdateAllowedAsync(command.Requester, command.SubscriptionId);
            if (!isUpdateAllowed)
            {
                throw new UnauthorizedException(string.Format(
                    "Not allowed to update subscription. User={0} Subscription={1}", 
                    command.Requester.Value, 
                    command.SubscriptionId.Value));
            }

            await this.UpdateSubscriptionAsync(command);
        }

        private Task UpdateSubscriptionAsync(UpdateSubscriptionCommand command)
        {
            var subscription = new Subscription(
                command.SubscriptionId.Value,
                default(Guid),
                null,
                command.SubscriptionName == null ? null : command.SubscriptionName.Value,
                command.Tagline == null ? null : command.Tagline.Value,
                command.Introduction == null ? null : command.Introduction.Value,
                command.Description == null ? null : command.Description.Value,
                command.Video == null ? null : command.Video.Value,
                command.HeaderImageFileId == null ? (Guid?)null : command.HeaderImageFileId.Value,
                null,
                default(DateTime));

            return this.databaseContext.Database.Connection.UpdateAsync(
                subscription,
                Subscription.Fields.Name |
                Subscription.Fields.Tagline |
                Subscription.Fields.Introduction |
                Subscription.Fields.Description |
                Subscription.Fields.ExternalVideoUrl |
                Subscription.Fields.HeaderImageFileId);
        }
    }
}