﻿namespace Fifthweek.Api.Subscriptions
{
    using System.Threading.Tasks;

    using Fifthweek.Api.Identity.Membership;

    public interface ICollectionOwnership
    {
        Task<bool> IsOwnerAsync(UserId userId, CollectionId collectionId);
    }
}