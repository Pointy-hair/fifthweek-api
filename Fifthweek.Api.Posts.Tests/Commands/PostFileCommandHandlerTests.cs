﻿namespace Fifthweek.Api.Posts.Tests.Commands
{
    using System;
    using System.Threading.Tasks;

    using Fifthweek.Api.Collections;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.FileManagement;
    using Fifthweek.Api.Identity.Membership;
    using Fifthweek.Api.Posts.Commands;
    using Fifthweek.Tests.Shared;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class PostFileCommandHandlerTests
    {
        private const bool IsQueued = false;
        private static readonly UserId UserId = new UserId(Guid.NewGuid());
        private static readonly Requester Requester = Requester.Authenticated(UserId);
        private static readonly CollectionId CollectionId = new CollectionId(Guid.NewGuid());
        private static readonly PostId PostId = new PostId(Guid.NewGuid());
        private static readonly FileId FileId = new FileId(Guid.NewGuid());
        private static readonly DateTime? ScheduleDate = null;
        private static readonly ValidComment Comment = ValidComment.Parse("Hey guys!");
        private static readonly PostFileCommand Command = new PostFileCommand(Requester, PostId, CollectionId, FileId, Comment, ScheduleDate, IsQueued);
        private Mock<ICollectionSecurity> collectionSecurity;
        private Mock<IFileSecurity> fileSecurity;
        private Mock<IPostFileTypeChecks> postFileTypeChecks;
        private Mock<IPostToCollectionDbStatement> postToCollectionDbStatement;
        private PostFileCommandHandler target;

        [TestInitialize]
        public void Initialize()
        {
            this.collectionSecurity = new Mock<ICollectionSecurity>();
            this.fileSecurity = new Mock<IFileSecurity>();
            this.postFileTypeChecks = new Mock<IPostFileTypeChecks>();

            // Give side-effecting components strict mock behaviour.
            this.postToCollectionDbStatement = new Mock<IPostToCollectionDbStatement>(MockBehavior.Strict);

            this.target = new PostFileCommandHandler(
                this.collectionSecurity.Object,
                this.fileSecurity.Object,
                this.postFileTypeChecks.Object,
                this.postToCollectionDbStatement.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(UnauthorizedException))]
        public async Task WhenUnauthenticated_ItShouldThrowUnauthorizedException()
        {
            await this.target.HandleAsync(new PostFileCommand(Requester.Unauthenticated, PostId, CollectionId, FileId, Comment, ScheduleDate, IsQueued));
        }

        [TestMethod]
        [ExpectedException(typeof(UnauthorizedException))]
        public async Task WhenNotAllowedToPost_ItShouldThrowUnauthorizedException()
        {
            this.collectionSecurity.Setup(_ => _.AssertPostingAllowedAsync(UserId, CollectionId)).Throws<UnauthorizedException>();

            await this.target.HandleAsync(Command);
        }

        [TestMethod]
        [ExpectedException(typeof(UnauthorizedException))]
        public async Task WhenNotAllowedToUseFile_ItShouldThrowUnauthorizedException()
        {
            this.fileSecurity.Setup(_ => _.AssertUsageAllowedAsync(UserId, FileId)).Throws<UnauthorizedException>();

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
                _ => _.ExecuteAsync(PostId, CollectionId, Comment, ScheduleDate, IsQueued, FileId, false, It.IsAny<DateTime>()))
                .Returns(Task.FromResult(0))
                .Verifiable();

            await this.target.HandleAsync(Command);

            this.postToCollectionDbStatement.Verify();
        }
    }
}