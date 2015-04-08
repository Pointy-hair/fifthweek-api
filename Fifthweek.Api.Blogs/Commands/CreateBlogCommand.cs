﻿namespace Fifthweek.Api.Blogs.Commands
{
    using Fifthweek.Api.Blogs.Shared;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;

    [AutoEqualityMembers, AutoConstructor]
    public partial class CreateBlogCommand
    {
        public Requester Requester { get; private set; }
        
        public BlogId NewBlogId { get; private set; }

        public ValidBlogName BlogName { get; private set; }

        public ValidTagline Tagline { get; private set; }

        public ValidChannelPriceInUsCentsPerWeek BasePrice { get; private set; }
    }
}