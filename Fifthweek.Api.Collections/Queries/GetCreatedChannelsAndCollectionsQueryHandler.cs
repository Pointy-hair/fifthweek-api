﻿namespace Fifthweek.Api.Collections.Queries
{
    using System.Threading.Tasks;

    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Shared;

    [AutoConstructor]
    public partial class GetCreatedChannelsAndCollectionsQueryHandler : IQueryHandler<GetCreatedChannelsAndCollectionsQuery, ChannelsAndCollections>
    {
        private readonly IRequesterSecurity requesterSecurity;
        private readonly IGetChannelsAndCollectionsDbStatement getChannelsAndCollections;

        public async Task<ChannelsAndCollections> HandleAsync(GetCreatedChannelsAndCollectionsQuery query)
        {
            query.AssertNotNull("query");

            await this.requesterSecurity.AuthenticateAsAsync(query.Requester, query.RequestedCreatorId);

            return await this.getChannelsAndCollections.ExecuteAsync(query.RequestedCreatorId);
        }
    }
}