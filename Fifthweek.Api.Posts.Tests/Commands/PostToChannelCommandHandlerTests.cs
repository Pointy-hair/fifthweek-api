﻿namespace Fifthweek.Api.Posts.Tests.Commands
{
    using System;
    using System.Threading.Tasks;

    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Collections.Shared;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.FileManagement.Shared;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Identity.Tests.Shared.Membership;
    using Fifthweek.Api.Posts.Commands;
    using Fifthweek.Api.Posts.Shared;
    using Fifthweek.Shared;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class PostToChannelCommandHandlerTests
    {
        private const bool IsQueued = false;
        private static readonly UserId UserId = new UserId(Guid.NewGuid());
        private static readonly Requester Requester = Requester.Authenticated(UserId);
        private static readonly ChannelId ChannelId = new ChannelId(Guid.NewGuid());
        private static readonly QueueId QueueId = new QueueId(Guid.NewGuid());
        private static readonly PostId PostId = new PostId(Guid.NewGuid());
        private static readonly FileId FileId = new FileId(Guid.NewGuid());
        private static readonly FileId ImageId = new FileId(Guid.NewGuid());
        private static readonly DateTime Timestamp = DateTime.UtcNow;
        private static readonly DateTime? ScheduleDate = null;
        private static readonly ValidComment Comment = ValidComment.Parse("Hey guys!");
        private static readonly PostToChannelCommand Command = new PostToChannelCommand(Requester, PostId, ChannelId, FileId, ImageId, Comment, ScheduleDate, QueueId, Timestamp);
        private Mock<IQueueSecurity> collectionSecurity;
        private Mock<IFileSecurity> fileSecurity;
        private Mock<IRequesterSecurity> requesterSecurity;
        private Mock<IPostFileTypeChecks> postFileTypeChecks;
        private Mock<IPostToChannelDbStatement> postToCollectionDbStatement;
        private PostToChannelCommandHandler target;

        [TestInitialize]
        public void Initialize()
        {
            this.collectionSecurity = new Mock<IQueueSecurity>();
            this.fileSecurity = new Mock<IFileSecurity>();
            this.postFileTypeChecks = new Mock<IPostFileTypeChecks>();
            this.requesterSecurity = new Mock<IRequesterSecurity>();
            this.requesterSecurity.SetupFor(Requester);

            // Give side-effecting components strict mock behaviour.
            this.postToCollectionDbStatement = new Mock<IPostToChannelDbStatement>(MockBehavior.Strict);

            this.target = new PostToChannelCommandHandler(
                this.collectionSecurity.Object,
                this.fileSecurity.Object,
                this.requesterSecurity.Object,
                this.postFileTypeChecks.Object,
                this.postToCollectionDbStatement.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(UnauthorizedException))]
        public async Task WhenUnauthenticated_ItShouldThrowUnauthorizedException()
        {
            await this.target.HandleAsync(new PostToChannelCommand(Requester.Unauthenticated, PostId, ChannelId, FileId, ImageId, Comment, ScheduleDate, QueueId, Timestamp));
        }

        [TestMethod]
        [ExpectedException(typeof(UnauthorizedException))]
        public async Task WhenNotAllowedToPost_ItShouldThrowUnauthorizedException()
        {
            this.collectionSecurity.Setup(_ => _.AssertWriteAllowedAsync(UserId, QueueId)).Throws<UnauthorizedException>();

            await this.target.HandleAsync(Command);
        }

        [TestMethod]
        [ExpectedException(typeof(UnauthorizedException))]
        public async Task WhenNotAllowedToUseFile_ItShouldThrowUnauthorizedException()
        {
            this.fileSecurity.Setup(_ => _.AssertReferenceAllowedAsync(UserId, FileId)).Throws<UnauthorizedException>();

            await this.target.HandleAsync(Command);
        }

        [TestMethod]
        [ExpectedException(typeof(RecoverableException))]
        public async Task WhenFileHasInvalidType_ItShouldThrowRecoverableException()
        {
            this.postFileTypeChecks.Setup(_ => _.AssertValidForFilePostAsync(FileId)).Throws(new RecoverableException("Bad file type"));

            await this.target.HandleAsync(Command);
        }

        [TestMethod]
        public async Task WhenAllowedToPost_ItShouldPostToCollection()
        {
            this.postToCollectionDbStatement.Setup(
                _ => _.ExecuteAsync(PostId, ChannelId, Comment, ScheduleDate, QueueId, FileId, ImageId, Timestamp))
                .Returns(Task.FromResult(0))
                .Verifiable();

            await this.target.HandleAsync(Command);

            this.postToCollectionDbStatement.Verify();
        }
    }
}