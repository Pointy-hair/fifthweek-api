﻿namespace Fifthweek.Api.Subscriptions.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;

    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Membership;
    using Fifthweek.Api.Identity.OAuth;
    using Fifthweek.Api.Subscriptions.Commands;
    using Fifthweek.Api.Subscriptions.Queries;
    using Fifthweek.CodeGeneration;

    [RoutePrefix("subscriptions"), AutoConstructor]
    public partial class SubscriptionController : ApiController
    {
        private readonly ICommandHandler<CreateSubscriptionCommand> createSubscription;
        private readonly ICommandHandler<UpdateSubscriptionCommand> updateSubscription;
        private readonly IQueryHandler<GetCreatorStatusQuery, CreatorStatus> getCreatorStatus;
        private readonly IUserContext userContext;
        private readonly IGuidCreator guidCreator;

        [Authorize]
        [Route("")]
        public async Task<IHttpActionResult> PostSubscription(NewSubscriptionData subscription)
        {
            subscription.AssertBodyProvided("subscription");
            subscription.Parse();

            var requester = this.userContext.GetRequester();
            var newSubscriptionId = new SubscriptionId(this.guidCreator.CreateSqlSequential());

            await this.createSubscription.HandleAsync(new CreateSubscriptionCommand(
                requester,
                newSubscriptionId,
                subscription.SubscriptionNameObject,
                subscription.TaglineObject,
                subscription.BasePriceObject));

            return this.Ok();
        }

        [Authorize]
        [Route("{subscriptionId}")]
        public async Task<IHttpActionResult> PutSubscription(string subscriptionId, [FromBody]UpdatedSubscriptionData subscription)
        {
            subscription.AssertUrlParameterProvided("subscriptionId");
            subscription.AssertBodyProvided("subscription");
            subscription.Parse();

            var requester = this.userContext.GetRequester();
            var subscriptionIdObject = new SubscriptionId(subscriptionId.DecodeGuid());

            await this.updateSubscription.HandleAsync(new UpdateSubscriptionCommand(
                requester,
                subscriptionIdObject,
                subscription.SubscriptionNameObject,
                subscription.TaglineObject,
                subscription.IntroductionObject,
                subscription.DescriptionObject,
                subscription.HeaderImageFileIdObject,
                subscription.VideoObject));

            return this.Ok();
        }

        [Authorize]
        [ResponseType(typeof(CreatorStatusData))]
        [Route("currentCreatorStatus")]
        public async Task<CreatorStatusData> GetCurrentCreatorStatus()
        {
            var requester = this.userContext.GetRequester();
            var creatorStatus = await this.getCreatorStatus.HandleAsync(new GetCreatorStatusQuery(requester));
            return new CreatorStatusData(
                creatorStatus.SubscriptionId == null ? null : creatorStatus.SubscriptionId.Value.EncodeGuid(), 
                creatorStatus.MustWriteFirstPost);
        }
    }
}
