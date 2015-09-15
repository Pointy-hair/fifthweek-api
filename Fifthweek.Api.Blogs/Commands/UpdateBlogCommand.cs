﻿namespace Fifthweek.Api.Blogs.Commands
{
    using Fifthweek.Api.Blogs.Shared;
    using Fifthweek.Api.FileManagement.Shared;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;

    [AutoEqualityMembers, AutoConstructor]
    public partial class UpdateBlogCommand
    {
        public Requester Requester { get; private set; }

        public BlogId BlogId { get; private set; }

        public ValidBlogName BlogName { get; private set; }

        [Optional]
        public ValidIntroduction Introduction { get; private set; }

        [Optional]
        public ValidBlogDescription Description { get; private set; }

        [Optional]
        public FileId HeaderImageFileId { get; private set; }

        [Optional]
        public ValidExternalVideoUrl Video { get; private set; }
    }
}