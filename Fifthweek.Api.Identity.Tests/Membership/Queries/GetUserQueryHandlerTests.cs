﻿namespace Fifthweek.Api.Identity.Tests.Membership.Queries
{
    using System.Threading.Tasks;

    using Fifthweek.Api.Identity.Membership;
    using Fifthweek.Api.Identity.Membership.Queries;
    using Fifthweek.Api.Persistence;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class GetUserQueryHandlerTests
    {
        [TestMethod]
        public async Task ItShouldReturnTheRequestedUser()
        {
            var authenticationRepository = new Mock<IUserManager>();

            authenticationRepository.Setup(v => v.FindAsync("username", "Password"))
                .ReturnsAsync(new ApplicationUser { UserName = "username" });

            var handler = new GetUserQueryHandler(authenticationRepository.Object);

            var result = await handler.HandleAsync(new GetUserQuery(NormalizedUsername.Parse("username"), "Password"));

            authenticationRepository.Verify(v => v.FindAsync("username", "Password"));

            Assert.AreEqual("username", result.UserName);
        }
    }
}