﻿namespace Fifthweek.Api.Posts.Tests.Commands
{
    using System;
    using System.Threading.Tasks;

    using Fifthweek.Api.Collections.Shared;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Identity.Tests.Shared.Membership;
    using Fifthweek.Api.Posts.Commands;
    using Fifthweek.Api.Posts.Shared;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class RescheduleWithQueueCommandHandlerTests
    {
        private static readonly UserId UserId = new UserId(Guid.NewGuid());
        private static readonly Requester Requester = Requester.Authenticated(UserId);
        private static readonly PostId PostId = new PostId(Guid.NewGuid());
        private static readonly CollectionId CollectionId = new CollectionId(Guid.NewGuid());
        private static readonly RescheduleWithQueueCommand Command = new RescheduleWithQueueCommand(Requester, PostId);

        private Mock<IRequesterSecurity> requesterSecurity;
        private Mock<IPostSecurity> postSecurity;
        private Mock<ITryGetUnqueuedPostCollectionDbStatement> tryGetUnqueuedPostCollection;
        private Mock<IMoveBacklogPostToQueueDbStatement> moveBacklogPostToQueue;
        private RescheduleWithQueueCommandHandler target;

        [TestInitialize]
        public void Initialize()
        {
            this.requesterSecurity = new Mock<IRequesterSecurity>();
            this.requesterSecurity.SetupFor(Requester);
            this.postSecurity = new Mock<IPostSecurity>();
            this.tryGetUnqueuedPostCollection = new Mock<ITryGetUnqueuedPostCollectionDbStatement>();

            // Mock potentially side-effecting components with strict behaviour.            
            this.moveBacklogPostToQueue = new Mock<IMoveBacklogPostToQueueDbStatement>(MockBehavior.Strict);

            this.target = new RescheduleWithQueueCommandHandler(
                this.requesterSecurity.Object, 
                this.postSecurity.Object, 
                this.tryGetUnqueuedPostCollection.Object,
                this.moveBacklogPostToQueue.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(UnauthorizedException))]
        public async Task WhenUnauthenticated_ItShouldThrowUnauthorizedException()
        {
            await this.target.HandleAsync(new RescheduleWithQueueCommand(Requester.Unauthenticated, PostId));
        }

        [TestMethod]
        [ExpectedException(typeof(UnauthorizedException))]
        public async Task WhenNotAllowedToWriteToPost_ItShouldThrowUnauthorizedException()
        {
            this.postSecurity.Setup(_ => _.AssertWriteAllowedAsync(UserId, PostId)).Throws<UnauthorizedException>();

            await this.target.HandleAsync(Command);
        }

        [TestMethod]
        public async Task WhenPostIsNotScheduledInCollectionBacklog_ItShouldHaveNoEffect()
        {
            this.tryGetUnqueuedPostCollection.Setup(_ => _.ExecuteAsync(PostId, It.Is<DateTime>(now => now.Kind == DateTimeKind.Utc)))
                .ReturnsAsync(null);

            await this.target.HandleAsync(Command);
        }

        [TestMethod]
        public async Task WhenPostIsScheduledInCollectionBacklog_ItShouldMovePostToQueue()
        {
            this.tryGetUnqueuedPostCollection.Setup(_ => _.ExecuteAsync(PostId, It.Is<DateTime>(now => now.Kind == DateTimeKind.Utc)))
                .ReturnsAsync(CollectionId);

            this.moveBacklogPostToQueue.Setup(_ => _.ExecuteAsync(PostId, CollectionId, It.Is<DateTime>(now => now.Kind == DateTimeKind.Utc)))
                .Returns(Task.FromResult(0))
                .Verifiable();

            await this.target.HandleAsync(Command);

            this.moveBacklogPostToQueue.Verify();
        }
    }
}