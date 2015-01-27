﻿namespace Fifthweek.Api.Aggregations.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;

    using Fifthweek.Api.Aggregations.Queries;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Membership;
    using Fifthweek.Api.Identity.OAuth;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.Api.Subscriptions;
    using Fifthweek.Api.Subscriptions.Controllers;
    using Fifthweek.Api.Subscriptions.Queries;
    using Fifthweek.CodeGeneration;

    using UserId = Fifthweek.Api.Identity.Shared.Membership.UserId;

    [AutoConstructor]
    [RoutePrefix("userState")]
    public partial class UserStateController : ApiController
    {
        private readonly IQueryHandler<GetUserStateQuery, UserState> getUserState;

        private readonly IUserContext userContext;

        [Route("{userId}")]
        public async Task<UserState> Get(string userId)
        {
            var requestedUserId = string.IsNullOrWhiteSpace(userId) ? null : new UserId(userId.DecodeGuid());
            var requester = this.userContext.GetRequester();

            var userState = await this.getUserState.HandleAsync(new GetUserStateQuery(requester, requestedUserId));

            return userState;
        }
    }
}