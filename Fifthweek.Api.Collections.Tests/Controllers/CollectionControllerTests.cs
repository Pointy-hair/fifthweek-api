﻿namespace Fifthweek.Api.Collections.Tests.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http.Results;

    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Collections.Commands;
    using Fifthweek.Api.Collections.Controllers;
    using Fifthweek.Api.Collections.Queries;
    using Fifthweek.Api.Collections.Shared;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class CollectionControllerTests
    {
        private static readonly DateTime NewQueuedPostLiveDate = DateTime.UtcNow;
        private static readonly UserId UserId = new UserId(Guid.NewGuid());
        private static readonly Requester Requester = Requester.Authenticated(UserId);
        private static readonly CollectionId CollectionId = new CollectionId(Guid.NewGuid());
        private static readonly ChannelId ChannelId = new ChannelId(Guid.NewGuid());
        private static readonly ValidCollectionName CollectionName = ValidCollectionName.Parse("Bat puns");
        private static readonly WeeklyReleaseSchedule WeeklyReleaseSchedule = WeeklyReleaseSchedule.Parse(new[] { HourOfWeek.Parse(0) });
        private Mock<ICommandHandler<CreateCollectionCommand>> createCollection;
        private Mock<ICommandHandler<UpdateCollectionCommand>> updateCollection;
        private Mock<IQueryHandler<GetLiveDateOfNewQueuedPostQuery, DateTime>> getLiveDateOfNewQueuedPost;
        private Mock<IRequesterContext> requesterContext;
        private Mock<IGuidCreator> guidCreator;
        private CollectionController target;

        [TestInitialize]
        public void Initialize()
        {
            this.createCollection = new Mock<ICommandHandler<CreateCollectionCommand>>();
            this.updateCollection = new Mock<ICommandHandler<UpdateCollectionCommand>>();
            this.getLiveDateOfNewQueuedPost = new Mock<IQueryHandler<GetLiveDateOfNewQueuedPostQuery, DateTime>>();
            this.requesterContext = new Mock<IRequesterContext>();
            this.guidCreator = new Mock<IGuidCreator>();
            this.target = new CollectionController(
                this.createCollection.Object, 
                this.updateCollection.Object,
                this.getLiveDateOfNewQueuedPost.Object, 
                this.requesterContext.Object, 
                this.guidCreator.Object);
        }

        [TestMethod]
        public async Task WhenPostingCollection_ItShouldIssueCreateCollectionCommand()
        {
            var data = new NewCollectionData(ChannelId, CollectionName.Value);
            var command = new CreateCollectionCommand(Requester, CollectionId, ChannelId, CollectionName);

            this.requesterContext.Setup(_ => _.GetRequester()).Returns(Requester);
            this.guidCreator.Setup(_ => _.CreateSqlSequential()).Returns(CollectionId.Value);
            this.createCollection.Setup(_ => _.HandleAsync(command)).Returns(Task.FromResult(0)).Verifiable();

            var result = await this.target.PostCollectionAsync(data);

            Assert.AreEqual(result, CollectionId);
            this.createCollection.Verify();
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public async Task WhenPostingCollectionWithoutSpecifyingCollection_ItShouldThrowBadRequestException()
        {
            await this.target.PostCollectionAsync(null);
        }

        [TestMethod]
        public async Task WhenPuttingCollection_ItShouldIssueUpdateCollectionCommand()
        {
            var data = new UpdatedCollectionData(ChannelId, CollectionName.Value, WeeklyReleaseSchedule.Value.Select(_ => _.Value).ToList());
            var command = new UpdateCollectionCommand(Requester, CollectionId, ChannelId, CollectionName, WeeklyReleaseSchedule);

            this.requesterContext.Setup(v => v.GetRequester()).Returns(Requester);
            this.updateCollection.Setup(v => v.HandleAsync(command)).Returns(Task.FromResult(0)).Verifiable();

            var result = await this.target.PutCollectionAsync(CollectionId.Value.EncodeGuid(), data);

            Assert.IsInstanceOfType(result, typeof(OkResult));
            this.updateCollection.Verify();
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public async Task WhenPuttingCollectionWithoutSpecifyingCollectionId_ItShouldThrowBadRequestException()
        {
            await this.target.PutCollectionAsync(string.Empty, new UpdatedCollectionData());
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public async Task WhenPuttingCollectionWithoutSpecifyingCollectionBody_ItShouldThrowBadRequestException()
        {
            await this.target.PutCollectionAsync(CollectionId.Value.EncodeGuid(), null);
        }

        [TestMethod]
        public async Task WhenGettingLiveDateOfNewQueuedPost_ItShouldReturnResultFromLiveDateOfNewQueuedPostQuery()
        {
            var requester = Requester.Authenticated(UserId);
            var query = new GetLiveDateOfNewQueuedPostQuery(requester, CollectionId);

            this.requesterContext.Setup(_ => _.GetRequester()).Returns(requester);
            this.getLiveDateOfNewQueuedPost.Setup(_ => _.HandleAsync(query)).ReturnsAsync(NewQueuedPostLiveDate);

            var result = await this.target.GetLiveDateOfNewQueuedPost(CollectionId.Value.EncodeGuid());

            Assert.AreEqual(result, NewQueuedPostLiveDate);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public async Task WhenGettingLiveDateOfNewQueuedPostWithoutSpecifyingCollection_ItShouldThrowBadRequestException()
        {
            await this.target.GetLiveDateOfNewQueuedPost(null);
        }
    }
}