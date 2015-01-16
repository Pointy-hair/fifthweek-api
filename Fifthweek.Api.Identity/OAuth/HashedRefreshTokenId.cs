﻿namespace Fifthweek.Api.Identity.OAuth
{
    using Fifthweek.Api.Core;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Shared;

    [AutoEqualityMembers, AutoConstructor]
    public partial class HashedRefreshTokenId
    {
        public string Value { get; private set; }

        public static HashedRefreshTokenId FromRefreshToken(string refreshToken)
        {
            var hashedTokenId = Helper.GetHash(refreshToken);
            return new HashedRefreshTokenId(hashedTokenId);
        }

        public static HashedRefreshTokenId FromRefreshTokenId(RefreshTokenId refreshTokenId)
        {
            var hashedTokenId = Helper.GetHash(refreshTokenId.Value);
            return new HashedRefreshTokenId(hashedTokenId);
        }
    }
}