﻿using Fifthweek.Api.Identity.Membership;

namespace Fifthweek.Api.Identity.Tests.Membership.Queries
{
    using Fifthweek.Api.Identity.Membership.Queries;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GetUsernameAvailabilityQueryTests
    {
        [TestMethod]
        public void ItShouldRecogniseEqualObjects()
        {
            var query1 = new GetUsernameAvailabilityQuery(NormalizedUsername.Parse("lawrence"));
            var query2 = new GetUsernameAvailabilityQuery(NormalizedUsername.Parse("lawrence"));

            Assert.AreEqual(query1, query2);
        }

        [TestMethod]
        public void ItShouldRecogniseDifferentUsernames()
        {
            var query1 = new GetUsernameAvailabilityQuery(NormalizedUsername.Parse("lawrence"));
            var query2 = new GetUsernameAvailabilityQuery(NormalizedUsername.Parse("jamest"));

            Assert.AreNotEqual(query1, query2);
        }
    }
}