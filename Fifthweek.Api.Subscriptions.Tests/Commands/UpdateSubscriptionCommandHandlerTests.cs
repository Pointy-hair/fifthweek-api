﻿namespace Fifthweek.Api.Subscriptions.Tests.Commands
{
    using System;
    using System.Data.Entity;
    using System.Threading.Tasks;

    using Fifthweek.Api.Core;
    using Fifthweek.Api.FileManagement;
    using Fifthweek.Api.Identity.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Api.Persistence.Tests.Shared;
    using Fifthweek.Api.Subscriptions.Commands;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class UpdateSubscriptionCommandHandlerTests : PersistenceTestsBase
    {
        private static readonly UserId UserId = new UserId(Guid.NewGuid());
        private static readonly SubscriptionId SubscriptionId = new SubscriptionId(Guid.NewGuid());
        private static readonly ValidSubscriptionName SubscriptionName = ValidSubscriptionName.Parse("Lawrence");
        private static readonly ValidTagline Tagline = ValidTagline.Parse("Web Comics and More");
        private static readonly ValidIntroduction Introduction = ValidIntroduction.Default;
        private static readonly ValidDescription Description = ValidDescription.Parse("Hello all!");
        private static readonly FileId HeaderImageFileId = new FileId(Guid.NewGuid());
        private static readonly ValidExternalVideoUrl Video = ValidExternalVideoUrl.Parse("http://youtube.com/3135");
        private static readonly UpdateSubscriptionCommand Command = new UpdateSubscriptionCommand(
            UserId, 
            SubscriptionId, 
            SubscriptionName, 
            Tagline, 
            Introduction, 
            Description,
            HeaderImageFileId,
            Video);

        private Mock<ISubscriptionSecurity> subscriptionSecurity;
        private Mock<IFileSecurity> fileSecurity;
        private UpdateSubscriptionCommandHandler target;

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            this.subscriptionSecurity = new Mock<ISubscriptionSecurity>();
            this.fileSecurity = new Mock<IFileSecurity>();
            this.target = new UpdateSubscriptionCommandHandler(this.subscriptionSecurity.Object, this.fileSecurity.Object, this.NewDbContext());
        }

        [TestCleanup]
        public override void Cleanup()
        {
            base.Cleanup();
        }

        [TestMethod]
        public async Task WhenNotAllowedToUpdate_ItShouldReportAnError()
        {
            this.subscriptionSecurity.Setup(_ => _.AssertUpdateAllowedAsync(UserId, SubscriptionId)).Throws<UnauthorizedException>();

            await this.SnapshotDatabaseAsync();

            try
            {
                await this.target.HandleAsync(Command);
                Assert.Fail("Expected unauthorized exception");
            }
            catch (UnauthorizedException)
            {
            }

            await this.AssertDatabaseAsync(ExpectedSideEffects.None);
        }

        [TestMethod]
        public async Task WhenNotAllowedToUseFile_ItShouldReportAnError()
        {
            this.fileSecurity.Setup(_ => _.AssertFileBelongsToUserAsync(UserId, HeaderImageFileId)).Throws<UnauthorizedException>();

            await this.SnapshotDatabaseAsync();

            try
            {
                await this.target.HandleAsync(Command);
                Assert.Fail("Expected unauthorized exception");
            }
            catch (UnauthorizedException)
            {
            }

            await this.AssertDatabaseAsync(ExpectedSideEffects.None);
        }

        [TestMethod]
        public async Task WhenReRun_ItShouldHaveNoEffect()
        {
            await this.CreateSubscriptionAsync(UserId, SubscriptionId, HeaderImageFileId);
            await this.target.HandleAsync(Command);

            await this.SnapshotDatabaseAsync();

            await this.target.HandleAsync(Command);

            await this.AssertDatabaseAsync(ExpectedSideEffects.None);
        }

        [TestMethod]
        public async Task ItShouldUpdateSubscription()
        {
            var subscription = await this.CreateSubscriptionAsync(UserId, SubscriptionId, HeaderImageFileId);

            await this.SnapshotDatabaseAsync();

            await this.target.HandleAsync(Command);

            var expectedSubscription = new Subscription(
                SubscriptionId.Value,
                UserId.Value,
                null,
                SubscriptionName.Value,
                Tagline.Value,
                Introduction.Value,
                Description.Value,
                Video.Value,
                HeaderImageFileId.Value,
                null,
                subscription.CreationDate);
            
            await this.AssertDatabaseAsync(new ExpectedSideEffects
            {
                Update = expectedSubscription, 
                ExcludedFromTest = entity => entity is Channel
            });
        }

        private async Task<Subscription> CreateSubscriptionAsync(UserId newUserId, SubscriptionId newSubscriptionId, FileId headerImageFileId)
        {
            using (var databaseContext = this.NewDbContext())
            {
                await databaseContext.CreateTestSubscriptionAsync(newUserId.Value, newSubscriptionId.Value, headerImageFileId.Value);
            }

            using (var databaseContext = this.NewDbContext())
            {
                return await databaseContext.Subscriptions.SingleAsync(_ => _.Id == newSubscriptionId.Value);
            }
        }
    }
}