﻿namespace Fifthweek.Api.Identity.Membership.Queries
{
    using System.Threading.Tasks;

    using Fifthweek.Api.Azure;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.FileManagement.Shared;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Shared;

    [AutoConstructor]
    public partial class GetAccountSettingsQueryHandler : IQueryHandler<GetAccountSettingsQuery, GetAccountSettingsResult>
    {
        private readonly IRequesterSecurity requesterSecurity;
        private readonly IGetAccountSettingsDbStatement getAccountSettings;
        private readonly IFileInformationAggregator fileInformationAggregator;

        public async Task<GetAccountSettingsResult> HandleAsync(GetAccountSettingsQuery query)
        {
            query.AssertNotNull("query");

            await this.requesterSecurity.AuthenticateAsAsync(query.Requester, query.RequestedUserId);

            var result = await this.getAccountSettings.ExecuteAsync(query.RequestedUserId);

            if (result.ProfileImageFileId == null)
            {
                return new GetAccountSettingsResult(result.Email, null);
            }

            var fileInformation = await this.fileInformationAggregator.GetFileInformationAsync(
                query.RequestedUserId,
                result.ProfileImageFileId,
                FilePurposes.ProfileImage);

            return new GetAccountSettingsResult(result.Email, fileInformation);
        }
    }
}