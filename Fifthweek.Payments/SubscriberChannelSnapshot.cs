namespace Fifthweek.Payments
{
    using System;

    using Fifthweek.CodeGeneration;

    [AutoEqualityMembers, AutoConstructor]
    public partial class SubscriberChannelSnapshot
    {
        public Guid ChannelId { get; private set; }

        public int AcceptedPrice { get; private set; }

        public DateTime SubscriptionStartDate { get; private set; }
    }
}