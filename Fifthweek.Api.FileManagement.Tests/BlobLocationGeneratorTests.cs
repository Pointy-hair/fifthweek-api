﻿namespace Fifthweek.Api.FileManagement.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;

    using Fifthweek.Api.Core;
    using Fifthweek.Api.FileManagement.Shared;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Shared;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Constants = Fifthweek.Api.FileManagement.Constants;

    [TestClass]
    public class BlobNameCreatorTests
    {
        private readonly FileId fileId = new FileId(Guid.NewGuid());
        
        private readonly FileId fileId2 = new FileId(Guid.NewGuid());

        private readonly UserId userId = new UserId(Guid.NewGuid());

        private readonly UserId userId2 = new UserId(Guid.NewGuid());

        private readonly FilePurpose validPublicPurpose = FilePurposes.GetAll().First(v => v.IsPublic);
        private readonly FilePurpose validPrivatePurpose = FilePurposes.GetAll().First(v => !v.IsPublic);

        private BlobLocationGenerator target;

        [TestInitialize]
        public void TestInitialize()
        {
            this.target = new BlobLocationGenerator();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WhenCalledWithNullPublicPurpose_ItShouldThrowAnException()
        {
            this.target.GetBlobLocation(this.userId, this.fileId, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WhenCalledWithNullFileIdAndPublicPurpose_ItShouldThrowAnException()
        {
            this.target.GetBlobLocation(this.userId, null, this.validPublicPurpose.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WhenCalledWithNullFileIdAndPrivatePurpose_ItShouldThrowAnException()
        {
            this.target.GetBlobLocation(this.userId, null, this.validPrivatePurpose.Name);
        }

        [TestMethod]
        public void WhenCalledWithNullUserIdAndPublicPurpose_ItShouldNotThrowAnException()
        {
            this.target.GetBlobLocation(this.userId, this.fileId, this.validPublicPurpose.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WhenCalledWithNullUserIdAndPrivatePurpose_ItShouldThrowAnException()
        {
            this.target.GetBlobLocation(null, this.fileId, this.validPrivatePurpose.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void WhenCalledWithUnknownPurpose_ItShouldThrowAnException()
        {
            this.target.GetBlobLocation(this.userId, this.fileId, "Unknown_Purpose");
        }

        [TestMethod]
        public void ItShouldGenerateValidLocations()
        {
            foreach (var filePurpose in FilePurposes.GetAll())
            {
                this.ItShouldGenerateAUrlFriendlyName(filePurpose.Name);
                this.ItShouldGenerateTheSameOutputGivenTheSameInputs(filePurpose.Name);
                this.ItShouldGenerateDifferentOutputsGivenDifferentInputs(filePurpose.Name, filePurpose.IsPublic);
                this.ItShouldGeneratePublicAndPrivateUrlsCorrectly(filePurpose.Name, filePurpose.IsPublic);
            }
        }

        private void ItShouldGenerateAUrlFriendlyName(string purpose)
        {
            var result = this.target.GetBlobLocation(this.userId, this.fileId, purpose);

            var encodedContainerName = HttpUtility.UrlEncode(result.ContainerName);
            var encodedBlobName = HttpUtility.UrlEncode(result.BlobName);

            Assert.AreEqual(encodedContainerName, result.ContainerName);
            Assert.AreEqual(encodedBlobName, result.BlobName);
        }

        private void ItShouldGenerateTheSameOutputGivenTheSameInputs(string purpose)
        {
            var result = this.target.GetBlobLocation(this.userId, this.fileId, purpose);
            var result2 = this.target.GetBlobLocation(this.userId, this.fileId, purpose);
            Assert.AreEqual(result2, result);
        }

        private void ItShouldGenerateDifferentOutputsGivenDifferentInputs(string purpose, bool isPublic)
        {
            var result = this.target.GetBlobLocation(this.userId, this.fileId, purpose);
            var result2 = this.target.GetBlobLocation(this.userId, this.fileId2, purpose);
            var result3 = this.target.GetBlobLocation(this.userId2, this.fileId, purpose);
            
            Assert.AreNotEqual(result2, result);

            if (isPublic)
            {
                Assert.AreEqual(result3, result);
            }
            else
            {
                Assert.AreNotEqual(result3, result);
            }
        }

        private void ItShouldGeneratePublicAndPrivateUrlsCorrectly(string purpose, bool isPublic)
        {
            var result = this.target.GetBlobLocation(this.userId, this.fileId, purpose);

            if (isPublic)
            {
                Assert.AreEqual(Constants.PublicFileBlobContainerName, result.ContainerName);
            }
            else
            {
                Assert.AreNotEqual(Constants.PublicFileBlobContainerName, result.ContainerName);
            }
        }
    }
}