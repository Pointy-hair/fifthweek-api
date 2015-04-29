﻿namespace Fifthweek.Api.FileManagement.Tests.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fifthweek.Api.Azure;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.FileManagement.Queries;
    using Fifthweek.Api.FileManagement.Shared;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Identity.Tests.Shared.Membership;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class GetUserAccessSignaturesQueryHandlerTests
    {
        private static readonly UserId UserId = new UserId(Guid.NewGuid());
        private static readonly Requester Requester = Requester.Authenticated(UserId);
        private static readonly List<UserId> CreatorIds = new List<UserId> { new UserId(Guid.NewGuid()), new UserId(Guid.NewGuid()) };
        
        private GetUserAccessSignaturesQueryHandler target;

        private Mock<IBlobService> blobService;
        private Mock<IBlobLocationGenerator> blobLocationGenerator;
        private Mock<IRequesterSecurity> requesterSecurity;

        [TestInitialize]
        public void TestInitialize()
        {
            this.blobService = new Mock<IBlobService>();
            this.blobLocationGenerator = new Mock<IBlobLocationGenerator>();
            this.requesterSecurity = new Mock<IRequesterSecurity>();

            this.target = new GetUserAccessSignaturesQueryHandler(
                this.blobService.Object,
                this.blobLocationGenerator.Object,
                this.requesterSecurity.Object);

            this.requesterSecurity.SetupFor(Requester);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task WhenQueryIsNull_ItShouldThrowException()
        {
            await this.target.HandleAsync(null);
        }

        [TestMethod]
        [ExpectedException(typeof(UnauthorizedException))]
        public async Task WhenUnauthenticatedAndRequestingForUserId_ItShouldThrowUnauthorizedException()
        {
            await this.target.HandleAsync(new GetUserAccessSignaturesQuery(Requester.Unauthenticated, UserId, CreatorIds));
        }

        [TestMethod]
        [ExpectedException(typeof(UnauthorizedException))]
        public async Task WhenRequestingForNonAuthenticatedUserId_ItShouldThrowUnauthorizedException()
        {
            await this.target.HandleAsync(new GetUserAccessSignaturesQuery(Requester, new UserId(Guid.NewGuid()), CreatorIds));
        }

        [TestMethod]
        public async Task WhenUnauthenticated_ItShouldReturnAccessSignatureForPublicFiles()
        {
            var filesInformation = new BlobContainerSharedAccessInformation("files", "uri", "sig", DateTime.UtcNow);

            this.blobService.Setup(v => v.GetBlobContainerSharedAccessInformationForReadingAsync(FileManagement.Constants.PublicFileBlobContainerName, It.IsAny<DateTime>()))
                .ReturnsAsync(filesInformation);

            var result = await this.target.HandleAsync(new GetUserAccessSignaturesQuery(Requester.Unauthenticated, null, CreatorIds));

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.PublicSignature);
            Assert.AreEqual(filesInformation, result.PublicSignature);
            Assert.AreEqual(0, result.PrivateSignatures.Count);
        }

        [TestMethod]
        public async Task WhenAuthenticated_ItShouldReturnAccessSignaturesForTheUser()
        {
            var now = DateTime.UtcNow;
            var expectedPublicExpiry = this.target.GetNextExpiry(now, true);
            var expectedPrivateExpiry = this.target.GetNextExpiry(now, false);
            var publicFilesInformation = new BlobContainerSharedAccessInformation("files", "uri", "sig", expectedPublicExpiry);

            this.blobService.Setup(v => v.GetBlobContainerSharedAccessInformationForReadingAsync(FileManagement.Constants.PublicFileBlobContainerName, expectedPublicExpiry))
                .ReturnsAsync(publicFilesInformation);

            var userContainerName = "containerName";
            var creatorContainerName1 = "containerName1";
            var creatorContainerName2 = "containerName2";
            this.blobLocationGenerator.Setup(v => v.GetBlobContainerName(UserId)).Returns(userContainerName);
            this.blobLocationGenerator.Setup(v => v.GetBlobContainerName(CreatorIds[0])).Returns(creatorContainerName1);
            this.blobLocationGenerator.Setup(v => v.GetBlobContainerName(CreatorIds[1])).Returns(creatorContainerName2);

            var userInformation = new BlobContainerSharedAccessInformation(userContainerName, "useruri", "usersig", expectedPrivateExpiry);
            var creatorInformation1 = new BlobContainerSharedAccessInformation(creatorContainerName1, "useruri1", "usersig1", expectedPrivateExpiry);
            var creatorInformation2 = new BlobContainerSharedAccessInformation(creatorContainerName2, "useruri2", "usersig2", expectedPrivateExpiry);

            this.blobService.Setup(v => v.GetBlobContainerSharedAccessInformationForReadingAsync(userContainerName, expectedPrivateExpiry))
                .ReturnsAsync(userInformation);
            this.blobService.Setup(v => v.GetBlobContainerSharedAccessInformationForReadingAsync(creatorContainerName1, expectedPrivateExpiry))
                .ReturnsAsync(creatorInformation1);
            this.blobService.Setup(v => v.GetBlobContainerSharedAccessInformationForReadingAsync(creatorContainerName2, expectedPrivateExpiry))
                .ReturnsAsync(creatorInformation2);

            var result = await this.target.HandleAsync(new GetUserAccessSignaturesQuery(Requester, UserId, CreatorIds));

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.PublicSignature);
            Assert.AreEqual(publicFilesInformation, result.PublicSignature);

            Assert.AreEqual(3, result.PrivateSignatures.Count);

            Assert.AreEqual(UserId, result.PrivateSignatures[0].CreatorId);
            Assert.AreEqual(userInformation, result.PrivateSignatures[0].Information);
            Assert.AreEqual(CreatorIds[0], result.PrivateSignatures[1].CreatorId);
            Assert.AreEqual(creatorInformation1, result.PrivateSignatures[1].Information);
            Assert.AreEqual(CreatorIds[1], result.PrivateSignatures[2].CreatorId);
            Assert.AreEqual(creatorInformation2, result.PrivateSignatures[2].Information);
        }

        [TestMethod]
        public async Task WhenGettingNextPublicExpiry_ItShouldReturnTheNextWholeWeekTakingMinimumExpiryIntoAccount()
        {
            DateTime result;
            result = this.target.GetNextExpiry(new DateTime(2015, 3, 18, 10, 00, 00, DateTimeKind.Utc), true);
            Assert.AreEqual(new DateTime(2015, 3, 23, 00, 00, 00, DateTimeKind.Utc), result);

            result = this.target.GetNextExpiry(new DateTime(2015, 3, 22, 23, 30, 00, DateTimeKind.Utc), true);
            Assert.AreEqual(new DateTime(2015, 3, 23, 00, 00, 00, DateTimeKind.Utc), result);

            result = this.target.GetNextExpiry(new DateTime(2015, 3, 22, 23, 49, 59, DateTimeKind.Utc), true);
            Assert.AreEqual(new DateTime(2015, 3, 23, 00, 00, 00, DateTimeKind.Utc), result);

            result = this.target.GetNextExpiry(new DateTime(2015, 3, 22, 23, 50, 00, DateTimeKind.Utc), true);
            Assert.AreEqual(new DateTime(2015, 3, 30, 00, 00, 00, DateTimeKind.Utc), result);
        }

        [TestMethod]
        public async Task WhenGettingNextPrivateExpiry_ItShouldReturnTheNextWholeHourTakingMinimumExpiryIntoAccount()
        {
            DateTime result;
            result = this.target.GetNextExpiry(new DateTime(2015, 3, 18, 10, 00, 00, DateTimeKind.Utc), false);
            Assert.AreEqual(new DateTime(2015, 3, 18, 11, 00, 00, DateTimeKind.Utc), result);

            result = this.target.GetNextExpiry(new DateTime(2015, 3, 18, 10, 30, 00, DateTimeKind.Utc), false);
            Assert.AreEqual(new DateTime(2015, 3, 18, 11, 00, 00, DateTimeKind.Utc), result);

            result = this.target.GetNextExpiry(new DateTime(2015, 3, 18, 10, 49, 59, DateTimeKind.Utc), false);
            Assert.AreEqual(new DateTime(2015, 3, 18, 11, 00, 00, DateTimeKind.Utc), result);

            result = this.target.GetNextExpiry(new DateTime(2015, 3, 18, 10, 50, 00, DateTimeKind.Utc), false);
            Assert.AreEqual(new DateTime(2015, 3, 18, 12, 00, 00, DateTimeKind.Utc), result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public async Task WhenGettingNextPublicExpiry_ItShouldExpectTimesAsUtc()
        {
            this.target.GetNextExpiry(new DateTime(2015, 3, 18, 10, 00, 00), true);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public async Task WhenGettingNextPrivateExpiry_ItShouldExpectTimesAsUtc()
        {
            this.target.GetNextExpiry(new DateTime(2015, 3, 18, 10, 00, 00), false);
        }

        [TestMethod]
        public async Task WhenGettingNextPublicExpiry_ItShouldReturnTimesAsUtc()
        {
            var result = this.target.GetNextExpiry(new DateTime(2015, 3, 18, 10, 00, 00, DateTimeKind.Utc), true);
            Assert.AreEqual(DateTimeKind.Utc, result.Kind);
        }

        [TestMethod]
        public async Task WhenGettingNextPrivateExpiry_ItShouldReturnTimesAsUtc()
        {
            var result = this.target.GetNextExpiry(new DateTime(2015, 3, 18, 10, 00, 00, DateTimeKind.Utc), false);
            Assert.AreEqual(DateTimeKind.Utc, result.Kind);
        }
    }
}
