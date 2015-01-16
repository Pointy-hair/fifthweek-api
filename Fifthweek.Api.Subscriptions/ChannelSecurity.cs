﻿namespace Fifthweek.Api.Subscriptions
{
    using System.Threading.Tasks;

    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Membership;
    using Fifthweek.Shared;

    [AutoConstructor]
    public partial class ChannelSecurity : IChannelSecurity
    {
        private readonly IChannelOwnership channelOwnership;

        public Task<bool> IsPostingAllowedAsync(UserId requester, ChannelId channelId)
        {
            requester.AssertNotNull("requester");
            channelId.AssertNotNull("channelId");

            return this.channelOwnership.IsOwnerAsync(requester, channelId);
        }

        public async Task AssertPostingAllowedAsync(UserId requester, ChannelId channelId)
        {
            requester.AssertNotNull("requester");
            channelId.AssertNotNull("channelId");

            var isPostingAllowed = await this.IsPostingAllowedAsync(requester, channelId);
            if (!isPostingAllowed)
            {
                throw new UnauthorizedException(string.Format("Not allowed to post to channel. {0} {1}", requester, channelId));
            }
        }
    }
}