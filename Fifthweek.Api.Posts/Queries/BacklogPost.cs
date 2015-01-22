﻿namespace Fifthweek.Api.Posts.Queries
{
    using System;

    using Fifthweek.Api.Collections;
    using Fifthweek.Api.FileManagement;
    using Fifthweek.Api.Subscriptions;
    using Fifthweek.CodeGeneration;

    [AutoConstructor, AutoEqualityMembers]
    public partial class BacklogPost
    {
        public ChannelId ChannelId { get; private set; }

        [Optional]
        public CollectionId CollectionId { get; private set; }

        [Optional]
        public Comment Comment { get; private set; }

        [Optional]
        public FileId FileId { get; private set; }

        [Optional]
        public FileId ImageId { get; private set; }

        public bool ScheduledByQueue { get; private set; }
        
        public DateTime LiveDate { get; private set; }
    }
}