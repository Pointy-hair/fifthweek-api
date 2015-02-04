﻿namespace Fifthweek.Api.Posts.Tests.Commands
{
    using System;
    using System.Data.Entity;
    using System.Threading.Tasks;

    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Identity.Tests.Shared.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Api.Persistence.Tests.Shared;
    using Fifthweek.Api.Posts.Commands;
    using Fifthweek.Api.Posts.Shared;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class RescheduleForNowCommandHandlerTests
    {
        private static readonly UserId UserId = new UserId(Guid.NewGuid());
        private static readonly Requester Requester = Requester.Authenticated(UserId);
        private static readonly PostId PostId = new PostId(Guid.NewGuid());
        private static readonly RescheduleForNowCommand Command = new RescheduleForNowCommand(Requester, PostId);

        private Mock<IRequesterSecurity> requesterSecurity;
        private Mock<IPostSecurity> postSecurity;
        private Mock<ISetBacklogPostLiveDateToNowDbStatement> setBacklogPostLiveDateToNow;
        private RescheduleForNowCommandHandler target;

        [TestInitialize]
        public void Initialize()
        {
            this.requesterSecurity = new Mock<IRequesterSecurity>();
            this.requesterSecurity.SetupFor(Requester);
            this.postSecurity = new Mock<IPostSecurity>();

            // Mock potentially side-effecting components with strict behaviour.            
            this.setBacklogPostLiveDateToNow = new Mock<ISetBacklogPostLiveDateToNowDbStatement>(MockBehavior.Strict);

            this.target = new RescheduleForNowCommandHandler(
                this.requesterSecurity.Object, 
                this.postSecurity.Object, 
                this.setBacklogPostLiveDateToNow.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(UnauthorizedException))]
        public async Task WhenUnauthenticated_ItShouldThrowUnauthorizedException()
        {
            await this.target.HandleAsync(new RescheduleForNowCommand(Requester.Unauthenticated, PostId));
        }

        [TestMethod]
        [ExpectedException(typeof(UnauthorizedException))]
        public async Task WhenNotAllowedToWriteToPost_ItShouldThrowUnauthorizedException()
        {
            this.postSecurity.Setup(_ => _.AssertWriteAllowedAsync(UserId, PostId)).Throws<UnauthorizedException>();

            await this.target.HandleAsync(Command);
        }

        [TestMethod]
        public async Task ItShouldSetBacklogPostLiveDateToNow()
        {
            this.setBacklogPostLiveDateToNow.Setup(_ => _.ExecuteAsync(PostId, It.Is<DateTime>(now => now.Kind == DateTimeKind.Utc)))
                .Returns(Task.FromResult(0))
                .Verifiable();

            await this.target.HandleAsync(Command);

            this.setBacklogPostLiveDateToNow.Verify();
        }
    }
}