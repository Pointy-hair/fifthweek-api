namespace Fifthweek.Api.Posts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Collections.Shared;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Posts.Queries;
    using Fifthweek.Shared;

    public interface IGetNewsfeedDbStatement
    {
        Task<IReadOnlyList<NewsfeedPost>> ExecuteAsync(
            UserId requestorId,
            UserId creatorId,
            IReadOnlyList<ChannelId> requestedChannelIds,
            IReadOnlyList<CollectionId> requestedCollectionIds,
            DateTime now,
            DateTime origin,
            bool searchForwards, 
            NonNegativeInt startIndex, 
            PositiveInt count);
    }
}