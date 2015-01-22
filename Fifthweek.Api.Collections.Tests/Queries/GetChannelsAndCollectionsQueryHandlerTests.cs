﻿namespace Fifthweek.Api.Collections.Tests.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fifthweek.Api.Collections.Queries;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Membership;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class GetChannelsAndCollectionsQueryHandlerTests
    {
        public static readonly UserId UserId = new UserId(Guid.NewGuid());
        public static readonly Requester Requester = Requester.Authenticated(UserId);

        private GetChannelsAndCollectionsQueryHandler target;
        private Mock<IGetChannelsAndCollectionsDbStatement> getChannelsAndCollections;

        [TestInitialize]
        public void TestInitialize()
        {
            this.getChannelsAndCollections = new Mock<IGetChannelsAndCollectionsDbStatement>(MockBehavior.Strict);
            this.target = new GetChannelsAndCollectionsQueryHandler(this.getChannelsAndCollections.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task WhenCalled_ItShouldCheckQueryIsNotNull()
        {
            await this.target.HandleAsync(null);
        }

        [TestMethod]
        [ExpectedException(typeof(UnauthorizedException))]
        public async Task WhenCalled_ItShouldCheckTheRequestedUserMatchesTheAuthenticatedUser()
        {
            await this.target.HandleAsync(new GetChannelsAndCollectionsQuery(Requester, new UserId(Guid.NewGuid())));
        }

        [TestMethod]
        public async Task WhenCalled_ItShouldCallTheDbStatement()
        {
            this.getChannelsAndCollections.Setup(v => v.ExecuteAsync(UserId))
                .ReturnsAsync(
                    new GetChannelsAndCollectionsResult(new List<GetChannelsAndCollectionsResult.Channel>()))
                .Verifiable();

            await this.target.HandleAsync(new GetChannelsAndCollectionsQuery(Requester, UserId));

            this.getChannelsAndCollections.Verify();
        }
    }
}