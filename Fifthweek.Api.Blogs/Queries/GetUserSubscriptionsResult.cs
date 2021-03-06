﻿namespace Fifthweek.Api.Blogs.Queries
{
    using System.Collections.Generic;

    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.CodeGeneration;

    [AutoConstructor, AutoEqualityMembers]
    public partial class GetUserSubscriptionsResult
    {
        public IReadOnlyList<BlogSubscriptionStatus> Blogs { get; private set; }
        
        public IReadOnlyList<ChannelId> FreeAccessChannelIds { get; private set; }
    }
}