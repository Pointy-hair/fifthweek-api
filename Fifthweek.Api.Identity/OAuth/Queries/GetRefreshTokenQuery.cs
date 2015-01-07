﻿namespace Fifthweek.Api.Identity.OAuth.Queries
{
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Persistence;

    [AutoEqualityMembers]
    public partial class GetRefreshTokenQuery : IQuery<RefreshToken>
    {
        public GetRefreshTokenQuery(HashedRefreshTokenId hashedRefreshTokenId)
        {
            this.HashedRefreshTokenId = hashedRefreshTokenId;
        }

        public HashedRefreshTokenId HashedRefreshTokenId { get; private set; }
    }
}