﻿namespace Fifthweek.Api.Subscriptions.Tests.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Http.Results;

    using Fifthweek.Api.Channels;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.FileManagement;
    using Fifthweek.Api.Identity.Membership;
    using Fifthweek.Api.Identity.OAuth;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Subscriptions.Commands;
    using Fifthweek.Api.Subscriptions.Controllers;
    using Fifthweek.Api.Subscriptions.Queries;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using FileId = Fifthweek.Api.FileManagement.Shared.FileId;
    using UserId = Fifthweek.Api.Identity.Shared.Membership.UserId;
    using ValidChannelPriceInUsCentsPerWeek = Fifthweek.Api.Channels.Shared.ValidChannelPriceInUsCentsPerWeek;

    [TestClass]
    public class SubscriptionControllerTests
    {
        private static readonly UserId UserId = new UserId(Guid.NewGuid());
        private static readonly Requester Requester = Requester.Authenticated(UserId);
        private static readonly SubscriptionId SubscriptionId = new SubscriptionId(Guid.NewGuid());
        private static readonly FileId HeaderImageFileId = new FileId(Guid.NewGuid());
        private Mock<ICommandHandler<CreateSubscriptionCommand>> createSubscription;
        private Mock<ICommandHandler<UpdateSubscriptionCommand>> updateSubscription;
        private Mock<IUserContext> userContext;
        private Mock<IGuidCreator> guidCreator;
        private SubscriptionController target;

        [TestInitialize]
        public void Initialize()
        {
            this.createSubscription = new Mock<ICommandHandler<CreateSubscriptionCommand>>();
            this.updateSubscription = new Mock<ICommandHandler<UpdateSubscriptionCommand>>();
            this.userContext = new Mock<IUserContext>();
            this.guidCreator = new Mock<IGuidCreator>();
            this.target = new SubscriptionController(
                this.createSubscription.Object,
                this.updateSubscription.Object,
                this.userContext.Object,
                this.guidCreator.Object);
        }

        [TestMethod]
        public async Task WhenPostingSubscription_ItShouldIssueCreateSubscriptionCommand()
        {
            var data = NewCreateSubscriptionData();
            var command = NewCreateSubscriptionCommand(UserId, SubscriptionId, data);

            this.userContext.Setup(v => v.GetRequester()).Returns(Requester);
            this.guidCreator.Setup(_ => _.CreateSqlSequential()).Returns(SubscriptionId.Value);
            this.createSubscription.Setup(v => v.HandleAsync(command)).Returns(Task.FromResult(0)).Verifiable();

            var result = await this.target.PostSubscription(data);

            Assert.IsInstanceOfType(result, typeof(OkResult));
            this.createSubscription.Verify();
        }

        [TestMethod]
        public async Task WhenPuttingSubscription_ItShouldIssueUpdateSubscriptionCommand()
        {
            var data = NewUpdatedSubscriptionData();
            var command = NewUpdateSubscriptionCommand(UserId, SubscriptionId, data);

            this.userContext.Setup(v => v.GetRequester()).Returns(Requester);
            this.updateSubscription.Setup(v => v.HandleAsync(command)).Returns(Task.FromResult(0)).Verifiable();

            var result = await this.target.PutSubscription(SubscriptionId.Value.EncodeGuid(), data);

            Assert.IsInstanceOfType(result, typeof(OkResult));
            this.updateSubscription.Verify();
        }

        public static NewSubscriptionData NewCreateSubscriptionData()
        {
            return new NewSubscriptionData
            {
                SubscriptionName = "Captain Phil",
                Tagline = "Web Comics And More",
                BasePrice = 50
            };
        }

        public static CreateSubscriptionCommand NewCreateSubscriptionCommand(
            UserId userId,
            SubscriptionId subscriptionId,
            NewSubscriptionData data)
        {
            return new CreateSubscriptionCommand(
                Requester.Authenticated(userId),
                subscriptionId,
                ValidSubscriptionName.Parse(data.SubscriptionName),
                ValidTagline.Parse(data.Tagline),
                ValidChannelPriceInUsCentsPerWeek.Parse(data.BasePrice));
        }

        public static UpdatedSubscriptionData NewUpdatedSubscriptionData()
        {
            return new UpdatedSubscriptionData
            {
                SubscriptionName = "Captain Phil",
                Tagline = "Web Comics And More",
                Introduction = "Subscription introduction",
                HeaderImageFileId = HeaderImageFileId,
                Video = "http://youtube.com/3135",
                Description = "Hello all!"
            };
        }

        public static UpdateSubscriptionCommand NewUpdateSubscriptionCommand(
            UserId userId,
            SubscriptionId subscriptionId,
            UpdatedSubscriptionData data)
        {
            return new UpdateSubscriptionCommand(
                Requester.Authenticated(userId),
                subscriptionId,
                ValidSubscriptionName.Parse(data.SubscriptionName),
                ValidTagline.Parse(data.Tagline),
                ValidIntroduction.Parse(data.Introduction),
                ValidDescription.Parse(data.Description),
                data.HeaderImageFileId,
                ValidExternalVideoUrl.Parse(data.Video));
        }
    }
}