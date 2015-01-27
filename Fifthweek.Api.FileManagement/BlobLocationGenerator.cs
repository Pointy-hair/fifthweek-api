﻿namespace Fifthweek.Api.FileManagement
{
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Membership;
    using Fifthweek.Shared;

    using UserId = Fifthweek.Api.Identity.Shared.Membership.UserId;

    public class BlobLocationGenerator : IBlobLocationGenerator
    {
        public BlobLocation GetBlobLocation(UserId userId, FileId fileId, string filePurpose)
        {
            var purpose = FilePurposes.TryGetFilePurpose(filePurpose);
            if (purpose.IsPublic)
            {
                return new BlobLocation(Constants.PublicFileBlobContainerName, fileId.Value.EncodeGuid());
            }

            return new BlobLocation(this.GetBlobContainerName(userId), fileId.Value.ToString("N"));
        }

        public string GetBlobContainerName(UserId userId)
        {
            return userId.Value.ToString("N");
        }
    }
}