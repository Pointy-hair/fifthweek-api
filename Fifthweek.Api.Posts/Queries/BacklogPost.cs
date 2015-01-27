﻿namespace Fifthweek.Api.Posts.Queries
{
    using System;

    using Fifthweek.Api.Channels;
    using Fifthweek.Api.Collections;
    using Fifthweek.Api.FileManagement;
    using Fifthweek.CodeGeneration;

    using ChannelId = Fifthweek.Api.Channels.Shared.ChannelId;
    using CollectionId = Fifthweek.Api.Collections.Shared.CollectionId;
    using FileId = Fifthweek.Api.FileManagement.Shared.FileId;

    [AutoConstructor, AutoEqualityMembers, AutoCopy]
    public partial class BacklogPost
    {
        public PostId PostId { get; private set; }

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