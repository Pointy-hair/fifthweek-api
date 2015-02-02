﻿namespace Fifthweek.Api.Posts.Tests.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Http.Results;

    using Fifthweek.Api.Collections.Shared;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.FileManagement.Shared;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Posts.Commands;
    using Fifthweek.Api.Posts.Controllers;
    using Fifthweek.Api.Posts.Shared;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class ImagePostControllerTests
    {
        private static readonly UserId UserId = new UserId(Guid.NewGuid());
        private static readonly Requester Requester = Requester.Authenticated(UserId);
        private static readonly PostId PostId = new PostId(Guid.NewGuid());
        private static readonly CollectionId CollectionId = new CollectionId(Guid.NewGuid());
        private static readonly FileId FileId = new FileId(Guid.NewGuid());
        private Mock<ICommandHandler<PostImageCommand>> postImage;
        private Mock<ICommandHandler<ReviseImageCommand>> reviseImage;
        private Mock<IRequesterContext> requesterContext;
        private Mock<IGuidCreator> guidCreator;
        private ImagePostController target;

        [TestInitialize]
        public void Initialize()
        {
            this.postImage = new Mock<ICommandHandler<PostImageCommand>>();
            this.reviseImage = new Mock<ICommandHandler<ReviseImageCommand>>();
            this.requesterContext = new Mock<IRequesterContext>();
            this.guidCreator = new Mock<IGuidCreator>();
            this.target = new ImagePostController(
                this.postImage.Object,
                this.reviseImage.Object,
                this.requesterContext.Object,
                this.guidCreator.Object);
        }

        [TestMethod]
        public async Task WhenPostingImage_ItShouldIssuePostImageCommand()
        {
            var data = new NewImageData(CollectionId, FileId, null, null, true);
            var command = new PostImageCommand(Requester, PostId, CollectionId, FileId, null, null, true);

            this.requesterContext.Setup(v => v.GetRequester()).Returns(Requester);
            this.guidCreator.Setup(_ => _.CreateSqlSequential()).Returns(PostId.Value);
            this.postImage.Setup(v => v.HandleAsync(command)).Returns(Task.FromResult(0)).Verifiable();

            var result = await this.target.PostImage(data);

            Assert.IsInstanceOfType(result, typeof(OkResult));
            this.postImage.Verify();
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public async Task WhenPostingImage_WithoutSpecifyingNewImageData_ItShouldThrowBadRequestException()
        {
            await this.target.PostImage(null);
        }

        [TestMethod]
        public async Task WhenPuttingImage_ItShouldIssuePostImageCommand()
        {
            var data = new RevisedImageData(CollectionId, FileId, null, null, true);
            var command = new ReviseImageCommand(Requester, PostId, CollectionId, FileId, null, null, true);

            this.requesterContext.Setup(v => v.GetRequester()).Returns(Requester);
            this.guidCreator.Setup(_ => _.CreateSqlSequential()).Returns(PostId.Value);
            this.reviseImage.Setup(v => v.HandleAsync(command)).Returns(Task.FromResult(0)).Verifiable();

            var result = await this.target.PutImage(PostId.Value.EncodeGuid(), data);

            Assert.IsInstanceOfType(result, typeof(OkResult));
            this.postImage.Verify();
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public async Task WhenPuttingImage_WithoutSpecifyingRevisedImageId_ItShouldThrowBadRequestException()
        {
            await this.target.PutImage(string.Empty, new RevisedImageData(CollectionId, FileId, null, null, true));
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public async Task WhenPuttingImage_WithoutSpecifyingRevisedImageData_ItShouldThrowBadRequestException()
        {
            await this.target.PutImage(PostId.Value.EncodeGuid(), null);
        }
    }
}