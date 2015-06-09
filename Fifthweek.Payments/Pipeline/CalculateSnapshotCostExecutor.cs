namespace Fifthweek.Payments.Pipeline
{
    using System.Linq;

    using Fifthweek.Payments.Pipeline;
    using Fifthweek.Payments.Snapshots;

    public class CalculateSnapshotCostExecutor : ICalculateSnapshotCostExecutor
    {
        public int Execute(MergedSnapshot snapshot)
        {
            if (snapshot.SubscriberChannels.SubscribedChannels.Count == 0)
            {
                return 0;
            }

            if (snapshot.Subscriber.Email != null && snapshot.CreatorFreeAccessUsers.FreeAccessUserEmails.Contains(snapshot.Subscriber.Email))
            {
                return 0;
            }

            var creatorSubscriptions 
                = from s in snapshot.SubscriberChannels.SubscribedChannels
                  let c = snapshot.CreatorChannels.CreatorChannels.FirstOrDefault(v => v.ChannelId.Equals(s.ChannelId))
                  where c != null
                  select new
                  {
                      Subscription = s,
                      Channel = c
                  };

            var acceptedSubscriptions = creatorSubscriptions.Where(v => v.Subscription.AcceptedPrice >= v.Channel.Price);

            var totalCost = acceptedSubscriptions.Aggregate(0, (a, s) => a + s.Channel.Price);

            return totalCost;
        }
    }
}