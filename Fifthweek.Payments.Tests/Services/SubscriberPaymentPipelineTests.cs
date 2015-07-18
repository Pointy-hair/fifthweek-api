﻿namespace Fifthweek.Payments.Tests.Services
{
    using System;
    using System.Collections.Generic;

    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Payments.Pipeline;
    using Fifthweek.Payments.Services;
    using Fifthweek.Payments.Snapshots;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class SubscriberPaymentPipelineTests
    {
        private static readonly DateTime Now = DateTime.UtcNow;
        private static readonly DateTime StartTimeInclusive = Now;
        private static readonly DateTime EndTimeExclusive = Now.AddDays(10);
        private static readonly UserId CreatorId1 = new UserId(Guid.NewGuid());
        private static readonly UserId SubscriberId1 = new UserId(Guid.NewGuid());

        private Mock<IVerifySnapshotsExecutor> verifySnapshots;
        private Mock<IMergeSnapshotsExecutor> mergeSnapshots;
        private Mock<IRollBackSubscriptionsExecutor> rollBackSubscriptions;
        private Mock<IRollForwardSubscriptionsExecutor> rollForwardSubscriptions;
        private Mock<ITrimSnapshotsExecutor> trimSnapshots;
        private Mock<ICalculateCostPeriodsExecutor> calculateCostPeriods;
        private Mock<IAggregateCostPeriodsExecutor> aggregateCostPeriods;
        private Mock<IAddSnapshotsForBillingEndDatesExecutor> addSnapshotsForBillingEndDates;
        private SubscriberPaymentPipeline target;

        [TestInitialize]
        public void Initialize()
        {
            this.verifySnapshots = new Mock<IVerifySnapshotsExecutor>(MockBehavior.Strict);
            this.mergeSnapshots = new Mock<IMergeSnapshotsExecutor>(MockBehavior.Strict);
            this.rollBackSubscriptions = new Mock<IRollBackSubscriptionsExecutor>(MockBehavior.Strict);
            this.rollForwardSubscriptions = new Mock<IRollForwardSubscriptionsExecutor>(MockBehavior.Strict);
            this.trimSnapshots = new Mock<ITrimSnapshotsExecutor>(MockBehavior.Strict);
            this.calculateCostPeriods = new Mock<ICalculateCostPeriodsExecutor>(MockBehavior.Strict);
            this.aggregateCostPeriods = new Mock<IAggregateCostPeriodsExecutor>(MockBehavior.Strict);
            this.addSnapshotsForBillingEndDates = new Mock<IAddSnapshotsForBillingEndDatesExecutor>(MockBehavior.Strict);
            this.target = new SubscriberPaymentPipeline(
                this.verifySnapshots.Object,
                this.mergeSnapshots.Object,
                this.rollBackSubscriptions.Object,
                this.rollForwardSubscriptions.Object,
                this.trimSnapshots.Object,
                this.addSnapshotsForBillingEndDates.Object,
                this.calculateCostPeriods.Object,
                this.aggregateCostPeriods.Object);
        }

        [TestMethod]
        public void ItShouldCallServicesInOrder()
        {
            var snapshots = new List<ISnapshot> { CreatorChannelsSnapshot.Default(Now, new UserId(Guid.NewGuid())) };
            var creatorPosts = new List<CreatorPost> { new CreatorPost(new Api.Channels.Shared.ChannelId(Guid.NewGuid()), Now) };

            this.verifySnapshots.Setup(v => v.Execute(StartTimeInclusive, EndTimeExclusive, SubscriberId1, CreatorId1, snapshots));

            var mergedSnapshots = CreateMergedSnapshotResult();
            this.mergeSnapshots.Setup(v => v.Execute(SubscriberId1, CreatorId1, StartTimeInclusive, snapshots))
                .Returns(mergedSnapshots);

            var rolledBackSnapshots = CreateMergedSnapshotResult();
            this.rollBackSubscriptions.Setup(v => v.Execute(mergedSnapshots)).Returns(rolledBackSnapshots);

            var rolledForwardSnapshots = CreateMergedSnapshotResult();
            this.rollForwardSubscriptions.Setup(v => v.Execute(EndTimeExclusive, rolledBackSnapshots)).Returns(rolledForwardSnapshots);

            var trimmedSnapshots = CreateMergedSnapshotResult();
            this.trimSnapshots.Setup(v => v.Execute(StartTimeInclusive, rolledForwardSnapshots)).Returns(trimmedSnapshots);

            var snapshotsWithBillingDates = CreateMergedSnapshotResult();
            this.addSnapshotsForBillingEndDates.Setup(v => v.Execute(trimmedSnapshots)).Returns(snapshotsWithBillingDates);

            var costPeriods = new List<CostPeriod> { new CostPeriod(StartTimeInclusive, EndTimeExclusive, 101) };
            this.calculateCostPeriods.Setup(v => v.Execute(StartTimeInclusive, EndTimeExclusive, snapshotsWithBillingDates, creatorPosts))
                .Returns(costPeriods);

            var aggregateCost = new AggregateCostSummary(201);
            this.aggregateCostPeriods.Setup(v => v.Execute(costPeriods)).Returns(aggregateCost);

            var result = this.target.CalculatePayment(snapshots, creatorPosts, SubscriberId1, CreatorId1, StartTimeInclusive, EndTimeExclusive);

            Assert.AreEqual(aggregateCost, result);
        }

        private static List<MergedSnapshot> CreateMergedSnapshotResult()
        {
            return new List<MergedSnapshot>
            {
                new MergedSnapshot(
                    CreatorChannelsSnapshot.Default(Now, UserId.Random()),
                    CreatorFreeAccessUsersSnapshot.Default(Now, UserId.Random()),
                    SubscriberChannelsSnapshot.Default(Now, UserId.Random()),
                    SubscriberSnapshot.Default(Now, UserId.Random()),
                    CalculatedAccountBalanceSnapshot.DefaultFifthweekCreditAccount(Now, UserId.Random()))
            };
        }
    }
}