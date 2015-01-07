﻿using Fifthweek.Api.Core;

namespace Fifthweek.Api.Identity.OAuth.Commands
{
    [AutoEqualityMembers, AutoConstructor]
    public partial class RemoveRefreshTokenCommand
    {
        public HashedRefreshTokenId HashedRefreshTokenId { get; private set; }
    }
}