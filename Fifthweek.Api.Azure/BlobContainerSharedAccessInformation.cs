﻿namespace Fifthweek.Api.Azure
{
    using System;

    using Fifthweek.CodeGeneration;

    [AutoConstructor, AutoEqualityMembers]
    public partial class BlobContainerSharedAccessInformation
    {
        public string ContainerName { get; private set; }

        public string Uri { get; private set; }

        public string Signature { get; private set; }

        public DateTime Expiry { get; private set; }
    }
}