﻿namespace Fifthweek.Api.Accounts.Queries
{
    using System.Threading.Tasks;

    using Fifthweek.Api.Accounts.Controllers;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Membership;

    [AutoConstructor]
    public partial class GetAccountSettingsQueryHandler : IQueryHandler<GetAccountSettingsQuery, AccountSettingsResult>
    {
        private readonly IAccountRepository accountRepository;

        public Task<AccountSettingsResult> HandleAsync(GetAccountSettingsQuery query)
        {
            query.AssertNotNull("query");
            query.AuthenticatedUserId.AssertAuthorizedFor(query.RequestedUserId);

            return this.accountRepository.GetAccountSettingsAsync(query.RequestedUserId);
        }
    }
}