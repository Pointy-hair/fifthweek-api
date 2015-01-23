﻿namespace Fifthweek.Api.Aggregations.Tests.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fifthweek.Api.Aggregations.Queries;
    using Fifthweek.Api.Azure;
    using Fifthweek.Api.Collections.Queries;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.FileManagement.Queries;
    using Fifthweek.Api.Identity.Membership;
    using Fifthweek.Api.Identity.Tests.Shared.Membership;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.Api.Subscriptions;
    using Fifthweek.Api.Subscriptions.Queries;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class GetUserStateQueryHandlerTests
    {
        private static readonly UserId UserId = new UserId(Guid.NewGuid());
        private static readonly Requester Requester = Requester.Authenticated(UserId);

        private static readonly UserAccessSignatures UserAccessSignatures =
            new UserAccessSignatures(
                new BlobContainerSharedAccessInformation("containerName", "uri", "signature", DateTime.UtcNow),
                new List<UserAccessSignatures.PrivateAccessSignature>
                    {
                        new UserAccessSignatures.
                            PrivateAccessSignature(
                            new UserId(Guid.NewGuid()),
                            new BlobContainerSharedAccessInformation(
                            "containerName2",
                            "uri2",
                            "signature2",
                            DateTime.UtcNow)),
                    });

        private GetUserStateQueryHandler target;

        private Mock<IRequesterSecurity> requesterSecurity;
        private Mock<IQueryHandler<GetUserAccessSignaturesQuery, UserAccessSignatures>> getUserAccessSignatures;
        private Mock<IQueryHandler<GetCreatorStatusQuery, CreatorStatus>> getCreatorStatus;
        private Mock<IQueryHandler<GetCreatedChannelsAndCollectionsQuery, ChannelsAndCollections>> getCreatedChannelsAndCollections;

        [TestInitialize]
        public void TestInitialize()
        {
            this.requesterSecurity = new Mock<IRequesterSecurity>();

            this.getUserAccessSignatures = new Mock<IQueryHandler<GetUserAccessSignaturesQuery, UserAccessSignatures>>();

            // Give potentially side-effecting components strict mock behaviour.
            this.getCreatorStatus = new Mock<IQueryHandler<GetCreatorStatusQuery, CreatorStatus>>(MockBehavior.Strict);
            this.getCreatedChannelsAndCollections = new Mock<IQueryHandler<GetCreatedChannelsAndCollectionsQuery, ChannelsAndCollections>>(MockBehavior.Strict);
            
            this.target = new GetUserStateQueryHandler(
                this.requesterSecurity.Object, 
                this.getUserAccessSignatures.Object,
                this.getCreatorStatus.Object, 
                this.getCreatedChannelsAndCollections.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task WhenCalled_ItShouldCheckTheQueryIsNotNull()
        {
            await this.target.HandleAsync(null);
        }

        [TestMethod]
        [ExpectedException(typeof(UnauthorizedException))]
        public async Task WhenCalled_ItShouldCheckTheAuthenticatedUserIsCorrect()
        {
            this.requesterSecurity.SetupFor(Requester);
            await this.target.HandleAsync(new GetUserStateQuery(Requester, new UserId(Guid.NewGuid())));
        }

        [TestMethod]
        public async Task WhenCalledAsASignedOutUser_ItShouldReturnUserStateWithoutCreatorState()
        {
            // Should not be called.
            this.requesterSecurity = new Mock<IRequesterSecurity>(MockBehavior.Strict);

            this.getUserAccessSignatures.Setup(v => v.HandleAsync(new GetUserAccessSignaturesQuery(Requester.Unauthenticated, null)))
                .ReturnsAsync(UserAccessSignatures);

            var result = await this.target.HandleAsync(new GetUserStateQuery(Requester.Unauthenticated, null));

            Assert.IsNotNull(result);
            Assert.AreEqual(UserAccessSignatures, result.AccessSignatures);
            Assert.IsNull(result.CreatorStatus);
            Assert.IsNull(result.CreatedChannelsAndCollections);
        }

        [TestMethod]
        public async Task WhenCalledAsAUser_ItShouldReturnUserStateWithoutCreatorState()
        {
            this.requesterSecurity.SetupFor(Requester);

            this.getUserAccessSignatures.Setup(v => v.HandleAsync(new GetUserAccessSignaturesQuery(Requester, UserId)))
                .ReturnsAsync(UserAccessSignatures);

            var result = await this.target.HandleAsync(new GetUserStateQuery(Requester, UserId));

            Assert.IsNotNull(result);
            Assert.AreEqual(UserAccessSignatures, result.AccessSignatures);
            Assert.IsNull(result.CreatorStatus);
            Assert.IsNull(result.CreatedChannelsAndCollections);
        }

        [TestMethod]
        public async Task WhenCalledAsACreator_ItShouldReturnUserStateWithCreatorState()
        {
            this.requesterSecurity.SetupFor(Requester);

            this.requesterSecurity.Setup(v => v.IsInRoleAsync(Requester, FifthweekRole.Creator)).ReturnsAsync(true);

            var creatorStatus = new CreatorStatus(new SubscriptionId(Guid.NewGuid()), true);
            var createdChannelsAndCollections = new ChannelsAndCollections(new List<ChannelsAndCollections.Channel>());

            this.getUserAccessSignatures.Setup(v => v.HandleAsync(new GetUserAccessSignaturesQuery(Requester, UserId)))
                .ReturnsAsync(UserAccessSignatures);
            this.getCreatorStatus.Setup(v => v.HandleAsync(new GetCreatorStatusQuery(Requester, UserId)))
                .ReturnsAsync(creatorStatus);
            this.getCreatedChannelsAndCollections.Setup(v => v.HandleAsync(new GetCreatedChannelsAndCollectionsQuery(Requester, UserId)))
                .ReturnsAsync(createdChannelsAndCollections);

            var result = await this.target.HandleAsync(new GetUserStateQuery(Requester, UserId));

            Assert.IsNotNull(result);
            Assert.AreEqual(UserAccessSignatures, result.AccessSignatures);
            Assert.AreEqual(creatorStatus, result.CreatorStatus);
            Assert.AreEqual(createdChannelsAndCollections, result.CreatedChannelsAndCollections);
        }
    }
}