﻿namespace Fifthweek.Api.Posts.Queries
{
    using System.Collections.Generic;

    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;

    [AutoConstructor, AutoEqualityMembers]
    public partial class GetCreatorBacklogQuery : IQuery<IReadOnlyList<GetCreatorBacklogQueryResult>>
    {
        public Requester Requester { get; private set; }

        public UserId RequestedUserId { get; private set; }
    }
}