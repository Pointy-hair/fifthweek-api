namespace Fifthweek.Api.Blogs.Queries
{
    using System.Collections.Generic;

    using Fifthweek.Api.Blogs.Shared;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;

    [AutoConstructor, AutoEqualityMembers]
    public partial class BlogSubscriptionStatus
    {
        public BlogId BlogId { get; private set; }

        public string BlogName { get; private set; }

        public UserId CreatorId { get; private set; }

        public Username CreatorUsername { get; private set; }

        public bool FreeAccess { get; private set; }

        public IReadOnlyList<ChannelSubscriptionStatus> Channels { get; private set; }
    }
}