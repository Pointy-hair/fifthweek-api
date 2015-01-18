﻿namespace Fifthweek.Api.FileManagement.Tests.Commands
{
    using System;
    using System.Threading.Tasks;

    using Fifthweek.Api.Azure;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.FileManagement.Commands;
    using Fifthweek.Api.Identity.Membership;
    using Fifthweek.Shared;
    using Fifthweek.Tests.Shared;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class CompleteFileUploadCommandHandlerTests
    {
        private const string BlobName = "blobName";
        private const string ContainerName = "containerName";
        private const string Purpose = "purpose";
        private const string FileExtension = "jpeg";
        private const string MimeType = "image/jpeg";
        private const long BlobSize = 1234;
        private static readonly FileId FileId = new FileId(Guid.NewGuid());
        private static readonly UserId UserId = new UserId(Guid.NewGuid());
        private static readonly Requester Requester = Requester.Authenticated(UserId);

        private Mock<IFileRepository> fileRepository;
        private Mock<IMimeTypeMap> mimeTypeMap;
        private Mock<IBlobService> blobService;
        private Mock<IQueueService> queueService;
        private Mock<IBlobLocationGenerator> blobNameCreator;

        private CompleteFileUploadCommandHandler handler;

        [TestInitialize]
        public void TestInitialize()
        {
            this.blobNameCreator = new Mock<IBlobLocationGenerator>();
            this.mimeTypeMap = new Mock<IMimeTypeMap>();

            // Give side-effecting components strict mock behaviour.
            this.fileRepository = new Mock<IFileRepository>(MockBehavior.Strict);
            this.blobService = new Mock<IBlobService>(MockBehavior.Strict);
            this.queueService = new Mock<IQueueService>(MockBehavior.Strict);

            this.handler = new CompleteFileUploadCommandHandler(
                this.fileRepository.Object,
                this.mimeTypeMap.Object,
                this.blobService.Object,
                this.queueService.Object,
                this.blobNameCreator.Object);
        }

        [TestMethod]
        public async Task WhenCalled_ItShouldUpdateStorageAndQueue()
        {
            this.mimeTypeMap.Setup(_ => _.GetMimeType(FileExtension)).Returns(MimeType);

            this.fileRepository.Setup(v => v.GetFileWaitingForUploadAsync(FileId))
                .ReturnsAsync(new FileWaitingForUpload(FileId, UserId, "myfile", FileExtension, Purpose));

            this.blobNameCreator.Setup(v => v.GetBlobLocation(UserId, FileId, Purpose))
                .Returns(new BlobLocation(ContainerName, BlobName));

            this.blobService.Setup(v => v.GetBlobLengthAndSetContentTypeAsync(ContainerName, BlobName, MimeType))
                .ReturnsAsync(BlobSize).Verifiable();

            this.fileRepository.Setup(v => v.SetFileUploadComplete(FileId, BlobSize))
                .Returns(Task.FromResult(0))
                .Verifiable();

            this.queueService.Setup(v => v.PostFileUploadCompletedMessageToQueueAsync(ContainerName, BlobName, Purpose))
                .Returns(Task.FromResult(0))
                .Verifiable();

            await this.handler.HandleAsync(new CompleteFileUploadCommand(Requester, FileId));

            this.fileRepository.Verify();
            this.blobService.Verify();
            this.queueService.Verify();
        }

        [TestMethod]
        public async Task WhenCalledAndFileDoesNotBelogToUser_ItShouldNotUpdateStorageOrQueue()
        {
            this.fileRepository.Setup(v => v.GetFileWaitingForUploadAsync(FileId))
                .ReturnsAsync(new FileWaitingForUpload(FileId, new UserId(Guid.NewGuid()), "myfile", FileExtension, Purpose));

            Func<Task> badMethodCall = () => this.handler.HandleAsync(new CompleteFileUploadCommand(Requester, FileId));

            await badMethodCall.AssertExceptionAsync<UnauthorizedException>();
        }
    }
}
