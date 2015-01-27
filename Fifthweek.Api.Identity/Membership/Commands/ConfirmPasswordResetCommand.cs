﻿using Fifthweek.Api.Core;

namespace Fifthweek.Api.Identity.Membership.Commands
{
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Shared;

    [AutoEqualityMembers, AutoConstructor]
    public partial class ConfirmPasswordResetCommand
    {
        public UserId UserId { get; private set; }

        public string Token { get; private set; }

        public ValidPassword NewPassword { get; private set; }
    }
}