﻿namespace Fifthweek.Api.Subscriptions
{
    using System;

    using Fifthweek.Api.Core;

    [AutoEqualityMembers, AutoConstructor]
    public partial class SubscriptionId
    {
        public Guid Value { get; private set; }
    }
}