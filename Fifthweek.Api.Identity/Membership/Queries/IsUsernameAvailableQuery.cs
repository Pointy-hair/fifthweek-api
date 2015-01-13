﻿namespace Fifthweek.Api.Identity.Membership.Queries
{
    using Fifthweek.Api.Core;

    [AutoEqualityMembers, AutoConstructor]
    public partial class IsUsernameAvailableQuery : IQuery<bool>
    {
        public ValidatedUsername Username { get; private set; }
    }
}