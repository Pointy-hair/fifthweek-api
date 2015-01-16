﻿namespace Fifthweek.Api.Subscriptions.Controllers
{
    using System;

    using Fifthweek.Api.FileManagement;
    using Fifthweek.CodeGeneration;

    [AutoEqualityMembers]
    public partial class NewImageData
    {
        [Optional]
        [Constructed(typeof(CollectionId), IsGuidBase64 = true)]
        public string CollectionId { get; set; }

        [Constructed(typeof(FileId), IsGuidBase64 = true)]
        public string ImageFileId { get; set; }

        [Optional]
        public DateTime? ScheduledPostDate { get; set; }

        public bool IsQueued { get; set; }
    }
}