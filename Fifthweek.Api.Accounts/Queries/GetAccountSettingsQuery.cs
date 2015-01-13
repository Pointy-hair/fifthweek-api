﻿namespace Fifthweek.Api.Accounts.Queries
{
    using Fifthweek.Api.Accounts.Controllers;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Membership;

    [AutoConstructor]
    [AutoEqualityMembers]
    public partial class GetAccountSettingsQuery : IQuery<AccountSettingsResult>
    {
        public UserId AuthenticatedUserId { get; private set; }

        public UserId RequestedUserId { get; private set; }
    }
}