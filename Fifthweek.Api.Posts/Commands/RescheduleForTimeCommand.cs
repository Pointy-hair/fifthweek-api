﻿namespace Fifthweek.Api.Posts.Commands
{
    using System;

    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Posts.Shared;
    using Fifthweek.CodeGeneration;

    [AutoConstructor, AutoEqualityMembers]
    public partial class RescheduleForTimeCommand
    {
        public Requester Requester { get; private set; }

        public PostId PostId { get; private set; }

        public DateTime ScheduledPostTime { get; private set; }
    }
}