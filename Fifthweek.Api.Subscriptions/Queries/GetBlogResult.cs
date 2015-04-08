﻿namespace Fifthweek.Api.Blogs.Queries
{
    using System;

    using Fifthweek.Api.Blogs.Shared;
    using Fifthweek.Api.FileManagement.Shared;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;

    [AutoConstructor]
    [AutoEqualityMembers]
    public partial class GetBlogResult
    {
        public BlogId BlogId { get; private set; }

        public UserId CreatorId { get; private set; }

        public BlogName BlogName { get; private set; }

        public Tagline Tagline { get; private set; }

        public Introduction Introduction { get; private set; }

        public DateTime CreationDate { get; private set; }

        [Optional]
        public FileInformation HeaderImage { get; private set; }

        [Optional]
        public ExternalVideoUrl Video { get; private set; }

        [Optional]
        public BlogDescription Description { get; private set; }
    }
}