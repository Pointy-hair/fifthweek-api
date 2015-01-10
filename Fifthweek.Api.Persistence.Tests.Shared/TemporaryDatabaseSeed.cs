﻿using System;
using System.Linq;
using Fifthweek.Api.Core;

namespace Fifthweek.Api.Persistence.Tests.Shared
{
    [AutoConstructor]
    public partial class TemporaryDatabaseSeed
    {
        private const int Users = 10;
        private const int Creators = 5;
        private const int SubscriptionsPerCreator = 1; // That's all our interface supports for now!
        private const int ChannelsPerSubscription = 3;

        private static readonly Random Random = new Random();

        private readonly IFifthweekDbContext dbContext;

        public void PopulateWithDummyEntities()
        {
            PopulateUsers();
            PopulateSubscriptions();
            PopulateChannels();
        }

        private void PopulateUsers()
        {
            for (var i = 0; i < Users; i++)
            {
                this.dbContext.Users.Add(UserTests.UniqueEntity(Random));
            }
        }

        private void PopulateSubscriptions()
        {
            for (var creatorIndex = 0; creatorIndex < Creators; creatorIndex++)
            {
                var creator = dbContext.Users.Local[creatorIndex];
                for (var subscriptionIndex = 0; subscriptionIndex < SubscriptionsPerCreator; subscriptionIndex++)
                {
                    var subscription = SubscriptionTests.UniqueEntity(Random);
                    subscription.Creator = creator;
                    subscription.CreatorId = creator.Id;
                    this.dbContext.Subscriptions.Add(subscription);
                }
            }
        }

        private void PopulateChannels()
        {
            for (var creatorIndex = 0; creatorIndex < Creators; creatorIndex++)
            {
                var creator = dbContext.Users.Local[creatorIndex];
                for (var subscriptionIndex = 0; subscriptionIndex < SubscriptionsPerCreator; subscriptionIndex++)
                {
                    var subscription = dbContext.Subscriptions.Local.Single(_ => _.Creator == creator);
                    for (var channelIndex = 0; channelIndex < ChannelsPerSubscription; channelIndex++)
                    {
                        var channel = ChannelTests.UniqueEntity(Random);
                        channel.Subscription = subscription;
                        channel.SubscriptionId = subscription.Id;
                        this.dbContext.Channels.Add(channel);
                    }
                }
            }
        }
    }
}