﻿using Fifthweek.Api.Core;

namespace Fifthweek.Api.Subscriptions.Controllers
{
    [AutoEqualityMembers]
    public partial class NewSubscriptionData
    {
        [Parsed(typeof(ValidSubscriptionName))]
        public string SubscriptionName { get; set; }

        [Parsed(typeof(ValidTagline))]
        public string Tagline { get; set; }

        [Parsed(typeof(ChannelPriceInUsCentsPerWeek))]
        public int BasePrice { get; set; }
    }
}