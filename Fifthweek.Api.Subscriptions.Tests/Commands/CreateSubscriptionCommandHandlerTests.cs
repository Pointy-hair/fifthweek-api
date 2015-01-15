﻿namespace Fifthweek.Api.Subscriptions.Tests.Commands
{
    using System;
    using System.Threading.Tasks;

    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Api.Persistence.Tests.Shared;
    using Fifthweek.Api.Subscriptions.Commands;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class CreateSubscriptionCommandHandlerTests : PersistenceTestsBase
    {
        private static readonly UserId UserId = new UserId(Guid.NewGuid());
        private static readonly SubscriptionId SubscriptionId = new SubscriptionId(Guid.NewGuid());
        private static readonly ValidSubscriptionName SubscriptionName = ValidSubscriptionName.Parse("Lawrence");
        private static readonly ValidTagline Tagline = ValidTagline.Parse("Web Comics and More");
        private static readonly ChannelPriceInUsCentsPerWeek BasePrice = ChannelPriceInUsCentsPerWeek.Parse(10);
        private static readonly CreateSubscriptionCommand Command = new CreateSubscriptionCommand(UserId, SubscriptionId, SubscriptionName, Tagline, BasePrice);
        private Mock<ISubscriptionSecurity> subscriptionSecurity;
        private CreateSubscriptionCommandHandler target;

        [TestInitialize]
        public void Initialize()
        {
            this.subscriptionSecurity = new Mock<ISubscriptionSecurity>();
        }

        [TestMethod]
        public async Task WhenNotAllowedToCreate_ItShouldReportAnError()
        {
            await this.NewTestDatabaseAsync(async testDatabase =>
            {
                this.subscriptionSecurity.Setup(_ => _.AssertCreationAllowedAsync(UserId)).Throws<UnauthorizedException>();
                this.target = new CreateSubscriptionCommandHandler(this.subscriptionSecurity.Object, testDatabase.NewContext());
                await testDatabase.TakeSnapshotAsync();

                try
                {
                    await this.target.HandleAsync(Command);
                    Assert.Fail("Expected recoverable exception");
                }
                catch (UnauthorizedException)
                {
                }

                return ExpectedSideEffects.None;
            });
        }

        [TestMethod]
        public async Task WhenReRun_ItShouldHaveNoEffect()
        {
            await this.NewTestDatabaseAsync(async testDatabase =>
            {
                this.target = new CreateSubscriptionCommandHandler(this.subscriptionSecurity.Object, testDatabase.NewContext());
                await this.CreateUserAsync(UserId, testDatabase);
                await this.target.HandleAsync(Command);
                await testDatabase.TakeSnapshotAsync();

                await this.target.HandleAsync(Command);

                return ExpectedSideEffects.None;
            });
        }

        [TestMethod]
        public async Task ItShouldCreateSubscription()
        {
            await this.NewTestDatabaseAsync(async testDatabase =>
            {
                this.target = new CreateSubscriptionCommandHandler(this.subscriptionSecurity.Object, testDatabase.NewContext());
                await this.CreateUserAsync(UserId, testDatabase);
                await testDatabase.TakeSnapshotAsync();

                await this.target.HandleAsync(Command);

                var expectedSubscription = new Subscription(
                    SubscriptionId.Value,
                    UserId.Value,
                    null,
                    SubscriptionName.Value,
                    Tagline.Value,
                    ValidIntroduction.Default.Value,
                    null,
                    null,
                    null,
                    null,
                    default(DateTime));

                return new ExpectedSideEffects
                {
                    Insert = new WildcardEntity<Subscription>(expectedSubscription)
                    {
                        AreEqual = actualSubscription =>
                        {
                            expectedSubscription.CreationDate = actualSubscription.CreationDate; // Take wildcard properties from actual value.
                            return Equals(expectedSubscription, actualSubscription);
                        }
                    },
                    ExcludedFromTest = entity => entity is Channel
                };
            });
        }

        [TestMethod]
        public async Task ItShouldCreateTheDefaultChannel()
        {
            await this.NewTestDatabaseAsync(async testDatabase =>
            {
                this.target = new CreateSubscriptionCommandHandler(this.subscriptionSecurity.Object, testDatabase.NewContext());
                await this.CreateUserAsync(UserId, testDatabase);
                await testDatabase.TakeSnapshotAsync();

                await this.target.HandleAsync(Command);

                var expectedChannel = new Channel(
                SubscriptionId.Value, // The default channel uses the subscription ID.
                SubscriptionId.Value,
                null,
                BasePrice.Value,
                DateTime.MinValue);

                return new ExpectedSideEffects
                {
                    Insert = new WildcardEntity<Channel>(expectedChannel)
                    {
                        AreEqual = actualChannel =>
                        {
                            expectedChannel.CreationDate = actualChannel.CreationDate; // Take wildcard properties from actual value.
                            return Equals(expectedChannel, actualChannel);
                        }
                    },
                    ExcludedFromTest = entity => entity is Subscription
                };
            });
        }

        private async Task CreateUserAsync(UserId newUserId, TestDatabaseContext testDatabase)
        {
            using (var databaseContext = testDatabase.NewContext())
            {
                await databaseContext.CreateTestUserAsync(newUserId.Value);
            }
        }
    }
}