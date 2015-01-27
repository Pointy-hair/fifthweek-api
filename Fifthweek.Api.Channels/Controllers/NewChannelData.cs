﻿namespace Fifthweek.Api.Channels.Controllers
{
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Subscriptions.Shared;
    using Fifthweek.CodeGeneration;

    [AutoConstructor, AutoEqualityMembers]
    public partial class NewChannelData
    {
        public NewChannelData()
        {
        }

        public SubscriptionId SubscriptionId { get; set; }

        [Parsed(typeof(ValidChannelName))]
        public string Name { get; set; }

        [Parsed(typeof(ValidChannelPriceInUsCentsPerWeek))]
        public int Price { get; set; }
    }
}