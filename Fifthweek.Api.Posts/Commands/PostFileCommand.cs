﻿namespace Fifthweek.Api.Posts.Commands
{
    using System;

    using Fifthweek.Api.Collections;
    using Fifthweek.Api.FileManagement;
    using Fifthweek.Api.Identity.Membership;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;

    [AutoConstructor, AutoEqualityMembers]
    public partial class PostFileCommand
    {
        public Requester Requester { get; private set; }

        public PostId NewPostId { get; private set; }

        public CollectionId CollectionId { get; private set; }

        public FileId FileId { get; private set; }

        [Optional]
        public ValidComment Comment { get; private set; }

        [Optional]
        public DateTime? ScheduledPostDate { get; private set; }

        public bool IsQueued { get; private set; }
    }
}