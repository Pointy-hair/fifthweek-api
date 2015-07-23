﻿namespace Fifthweek.Api.Blogs.Queries
{
    using Fifthweek.Api.Blogs.Shared;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;

    [AutoConstructor, AutoEqualityMembers]
    public partial class GetBlogSubscriberInformationQuery : IQuery<BlogSubscriberInformation>
    {
        public Requester Requester { get; private set; }

        public BlogId BlogId { get; private set; }
    }
}