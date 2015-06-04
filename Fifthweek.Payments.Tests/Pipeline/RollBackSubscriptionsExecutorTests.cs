﻿namespace Fifthweek.Payments.Tests.Pipeline
{
    using System;
    using System.Collections.Generic;

    using Fifthweek.Payments.Pipeline;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RollBackSubscriptionsExecutorTests
    {
        private RollBackSubscriptionsExecutor target;

        [TestInitialize]
        public void Initialize()
        {
            this.target = new RollBackSubscriptionsExecutor();
        }

        [TestMethod]
        public void ItShouldReturnTheGivenSnapshots()
        {
            var now = DateTime.UtcNow;
            var input = new List<MergedSnapshot> 
            {
                new MergedSnapshot(
                    CreatorSnapshot.Default(now, Guid.NewGuid()),
                    CreatorGuestListSnapshot.Default(now, Guid.NewGuid()),
                    SubscriberSnapshot.Default(now, Guid.NewGuid())),
            };

            Assert.AreSame(input, this.target.Execute(input));
        }
    }
}