﻿namespace Fifthweek.Api.FileManagement.Queries
{
    using System.Collections.Generic;

    using Fifthweek.Api.Azure;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;

    [AutoConstructor]
    public partial class UserAccessSignatures
    {
        public BlobContainerSharedAccessInformation PublicSignature { get; private set; }

        public IReadOnlyList<PrivateAccessSignature> PrivateSignatures { get; private set; }

        [AutoConstructor]
        public partial class PrivateAccessSignature
        {
            public UserId CreatorId { get; private set; }

            public BlobContainerSharedAccessInformation Information { get; private set; }
        }
    }
}