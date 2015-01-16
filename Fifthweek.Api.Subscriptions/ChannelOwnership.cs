﻿namespace Fifthweek.Api.Subscriptions
{
    using System;
    using System.Threading.Tasks;

    using Dapper;

    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Shared;

    [AutoConstructor]
    public partial class ChannelOwnership : IChannelOwnership
    {
        private readonly IFifthweekDbContext databaseContext;

        public Task<bool> IsOwnerAsync(UserId userId, ChannelId channelId)
        {
            if (userId == null)
            {
                throw new ArgumentNullException("userId");
            }

            if (channelId == null)
            {
                throw new ArgumentNullException("channelId");
            }

            return this.databaseContext.Database.Connection.ExecuteScalarAsync<bool>(
                @"IF EXISTS(SELECT *
                            FROM        Channels channel
                            INNER JOIN  Subscriptions subscription
                            ON          channel.SubscriptionId  = subscription.Id
                            WHERE       channel.Id              = @ChannelId
                            AND         subscription.CreatorId  = @CreatorId)
                    SELECT 1 AS FOUND
                ELSE
                    SELECT 0 AS FOUND",
                new
                {
                    ChannelId = channelId.Value,
                    CreatorId = userId.Value
                });
        }
    }
}