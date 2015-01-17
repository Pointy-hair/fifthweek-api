﻿namespace Fifthweek.Api.Subscriptions.Tests
{
    using System;
    using System.Threading.Tasks;

    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Membership;
    using Fifthweek.Tests.Shared;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class CollectionSecurityTests
    {
        private static readonly UserId UserId = new UserId(Guid.NewGuid());
        private static readonly CollectionId CollectionId = new CollectionId(Guid.NewGuid());
        private Mock<ICollectionOwnership> collectionOwnership;
        private CollectionSecurity target;

        [TestInitialize]
        public void Initialize()
        {
            this.collectionOwnership = new Mock<ICollectionOwnership>();
            this.target = new CollectionSecurity(this.collectionOwnership.Object);
        }

        [TestMethod]
        public async Task WhenAuthorizingPost_ItShouldAllowIfUserOwnsCollection()
        {
            this.collectionOwnership.Setup(_ => _.IsOwnerAsync(UserId, CollectionId)).ReturnsAsync(true);

            var result = await this.target.IsPostingAllowedAsync(UserId, CollectionId);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task WhenAuthorizingPost_ItShouldForbidIfUserDoesNotOwnCollection()
        {
            this.collectionOwnership.Setup(_ => _.IsOwnerAsync(UserId, CollectionId)).ReturnsAsync(false);

            var result = await this.target.IsPostingAllowedAsync(UserId, CollectionId);

            Assert.IsFalse(result);

            Func<Task> badMethodCall = () => this.target.AssertPostingAllowedAsync(UserId, CollectionId);

            await badMethodCall.AssertExceptionAsync<UnauthorizedException>();
        }
    }
}