﻿namespace Fifthweek.Api.Subscriptions.Commands
{
    using Fifthweek.Api.Identity.Membership;
    using Fifthweek.CodeGeneration;

    [AutoConstructor, AutoEqualityMembers]
    public partial class PromoteNewUserToCreatorCommand
    {
        public UserId NewUserId { get; private set; }
    }
}