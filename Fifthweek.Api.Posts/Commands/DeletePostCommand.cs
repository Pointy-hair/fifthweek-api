﻿namespace Fifthweek.Api.Posts.Commands
{
    using Fifthweek.Api.Identity.Membership;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;

    [AutoConstructor, AutoEqualityMembers]
    public partial class DeletePostCommand
    {
        public PostId PostId { get; private set; }

        public Requester Requester { get; private set; }
    }
}