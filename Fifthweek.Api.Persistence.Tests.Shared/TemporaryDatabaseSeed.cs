﻿namespace Fifthweek.Api.Persistence.Tests.Shared
{
    using System;
    using System.Linq;

    using Fifthweek.Api.Core;

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
            this.PopulateUsers();
            this.PopulateSubscriptions();
            this.PopulateChannels();
        }

        private void PopulateUsers()
        {
            for (var i = 0; i < Users; i++)
            {
                var user = UserTests.UniqueEntity(Random);

                if (Random.Next(1) == 1)
                {
                    var file = FileTests.UniqueEntity(Random);
                    file.User = user;
                    file.UserId = user.Id;
                    user.ProfileImageFile = file;
                    user.ProfileImageFileId = file.Id;
                    this.dbContext.Files.Add(file);
                }

                this.dbContext.Users.Add(user);
            }
        }

        private void PopulateSubscriptions()
        {
            for (var creatorIndex = 0; creatorIndex < Creators; creatorIndex++)
            {
                var creator = this.dbContext.Users.Local[creatorIndex];
                for (var subscriptionIndex = 0; subscriptionIndex < SubscriptionsPerCreator; subscriptionIndex++)
                {
                    var subscription = SubscriptionTests.UniqueEntity(Random);

                    if (subscription.HeaderImageFile != null)
                    {
                        var file = subscription.HeaderImageFile;
                        file.User = creator;
                        file.UserId = creator.Id;
                        this.dbContext.Files.Add(subscription.HeaderImageFile);
                    }

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
                var creator = this.dbContext.Users.Local[creatorIndex];
                for (var subscriptionIndex = 0; subscriptionIndex < SubscriptionsPerCreator; subscriptionIndex++)
                {
                    var subscription = this.dbContext.Subscriptions.Local.Single(_ => _.Creator == creator);
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