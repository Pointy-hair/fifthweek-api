﻿namespace Fifthweek.Payments.Tests.Services.Credit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence.Payments;
    using Fifthweek.Payments.Services;
    using Fifthweek.Payments.Services.Credit;
    using Fifthweek.Payments.Shared;
    using Fifthweek.Shared;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class TopUpUserAccountsWithCreditTests
    {
        private static readonly DateTime Now1 = DateTime.UtcNow;
        private static readonly DateTime Now2 = Now1.AddSeconds(1);
        private static readonly TransactionReference TransactionReference1 = TransactionReference.Random();
        private static readonly TransactionReference TransactionReference2 = TransactionReference.Random();
        
        private Mock<IGetUsersRequiringPaymentRetryDbStatement> getUsersRequiringPaymentRetry;
        private Mock<IApplyUserCredit> applyUserCredit;
        private Mock<IGetUserWeeklySubscriptionsCost> getUserWeeklySubscriptionsCost;
        private Mock<IIncrementPaymentStatusDbStatement> incrementPaymentStatus;
        private Mock<IGetUserPaymentOriginDbStatement> getUserPaymentOrigin;
        private Mock<ITimestampCreator> timestampCreator;
        private Mock<IGuidCreator> guidCreator;

        private TopUpUserAccountsWithCredit target;

        [TestInitialize]
        public void Initialize()
        {
            this.getUsersRequiringPaymentRetry = new Mock<IGetUsersRequiringPaymentRetryDbStatement>(MockBehavior.Strict);
            this.applyUserCredit = new Mock<IApplyUserCredit>(MockBehavior.Strict);
            this.getUserWeeklySubscriptionsCost = new Mock<IGetUserWeeklySubscriptionsCost>(MockBehavior.Strict);
            this.incrementPaymentStatus = new Mock<IIncrementPaymentStatusDbStatement>(MockBehavior.Strict);
            this.getUserPaymentOrigin = new Mock<IGetUserPaymentOriginDbStatement>(MockBehavior.Strict);
            this.timestampCreator = new Mock<ITimestampCreator>(MockBehavior.Strict);
            this.guidCreator = new Mock<IGuidCreator>(MockBehavior.Strict);

            this.target = new TopUpUserAccountsWithCredit(
                this.getUsersRequiringPaymentRetry.Object,
                this.applyUserCredit.Object,
                this.getUserWeeklySubscriptionsCost.Object,
                this.incrementPaymentStatus.Object,
                this.getUserPaymentOrigin.Object,
                this.timestampCreator.Object,
                this.guidCreator.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task WhenUpdatedAccountBalancesIsNull_ItShouldThrowAnException()
        {
            await this.target.ExecuteAsync(null, new List<PaymentProcessingException>());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task WhenErrorsIsNull_ItShouldThrowAnException()
        {
            await this.target.ExecuteAsync(new List<CalculatedAccountBalanceResult>(), null);
        }

        [TestMethod]
        public async Task ItShouldChargeAllNecessaryUsers()
        {
            this.timestampCreator.SetupSequence(v => v.Now()).Returns(Now1).Returns(Now2);
            this.guidCreator.SetupSequence(v => v.CreateSqlSequential()).Returns(TransactionReference1.Value).Returns(TransactionReference2.Value);

            var userId1 = UserId.Random();
            var userId2 = UserId.Random();
            var userId3 = UserId.Random();
            var userId4 = UserId.Random();
            var userId5 = UserId.Random();
            var input = new List<CalculatedAccountBalanceResult>
            { 
                new CalculatedAccountBalanceResult(DateTime.UtcNow, UserId.Random(), LedgerAccountType.FifthweekCredit, TopUpUserAccountsWithCredit.MinimumAccountBalanceBeforeCharge),
                new CalculatedAccountBalanceResult(DateTime.UtcNow, UserId.Random(), LedgerAccountType.Stripe, 0),
                new CalculatedAccountBalanceResult(DateTime.UtcNow, userId1, LedgerAccountType.FifthweekCredit, TopUpUserAccountsWithCredit.MinimumAccountBalanceBeforeCharge - 1),
                new CalculatedAccountBalanceResult(DateTime.UtcNow, userId2, LedgerAccountType.FifthweekCredit, -1m),
            };

            var usersRequiringRetry = new List<UserId> { userId3, userId4, userId5 };
            this.getUsersRequiringPaymentRetry.Setup(v => v.ExecuteAsync()).ReturnsAsync(usersRequiringRetry);

            var usersRequiringCharge = new List<UserId> { userId1, userId2, userId3, userId4, userId5 };
            this.incrementPaymentStatus.Setup(v => v.ExecuteAsync(It.IsAny<IReadOnlyList<UserId>>()))
                .Callback<IReadOnlyList<UserId>>(v => CollectionAssert.AreEquivalent(usersRequiringCharge, v.ToList()))
                .Returns(Task.FromResult(0)).Verifiable();

            this.getUserWeeklySubscriptionsCost.Setup(v => v.ExecuteAsync(userId1)).ReturnsAsync(TopUpUserAccountsWithCredit.MinimumPaymentAmount - 1);
            this.getUserWeeklySubscriptionsCost.Setup(v => v.ExecuteAsync(userId2)).ReturnsAsync(TopUpUserAccountsWithCredit.MinimumPaymentAmount + 1);
            this.getUserWeeklySubscriptionsCost.Setup(v => v.ExecuteAsync(userId3)).ReturnsAsync(0);
            this.getUserWeeklySubscriptionsCost.Setup(v => v.ExecuteAsync(userId4)).ReturnsAsync(TopUpUserAccountsWithCredit.MinimumPaymentAmount * 2);
            this.getUserWeeklySubscriptionsCost.Setup(v => v.ExecuteAsync(userId5)).ReturnsAsync(TopUpUserAccountsWithCredit.MinimumPaymentAmount * 2);

            this.getUserPaymentOrigin.Setup(v => v.ExecuteAsync(userId1))
                .ReturnsAsync(new UserPaymentOriginResult("customer1", PaymentOriginKeyType.Stripe, null, null, null, null, PaymentStatus.Retry1));
            this.getUserPaymentOrigin.Setup(v => v.ExecuteAsync(userId2))
                .ReturnsAsync(new UserPaymentOriginResult("customer2", PaymentOriginKeyType.Stripe, null, null, null, null, PaymentStatus.Retry1));
            
            // Test PaymentOriginKeyType with no key.
            this.getUserPaymentOrigin.Setup(v => v.ExecuteAsync(userId4))
                .ReturnsAsync(new UserPaymentOriginResult(null, PaymentOriginKeyType.Stripe, null, null, null, null, PaymentStatus.Retry1));

            this.getUserPaymentOrigin.Setup(v => v.ExecuteAsync(userId5))
                .ReturnsAsync(new UserPaymentOriginResult("customer5", PaymentOriginKeyType.Stripe, null, null, null, null, PaymentStatus.None));

            this.applyUserCredit.Setup(v => v.ExecuteAsync(userId1, Now1, TransactionReference1, PositiveInt.Parse(TopUpUserAccountsWithCredit.MinimumPaymentAmount), null, UserType.StandardUser))
                .Returns(Task.FromResult(0))
                .Verifiable();

            this.applyUserCredit.Setup(v => v.ExecuteAsync(userId2, Now2, TransactionReference2, PositiveInt.Parse(TopUpUserAccountsWithCredit.MinimumPaymentAmount + 1), null, UserType.StandardUser))
                .Returns(Task.FromResult(0))
                .Verifiable();

            var result = await this.target.ExecuteAsync(input, new List<PaymentProcessingException>());

            this.incrementPaymentStatus.Verify();
            this.applyUserCredit.Verify();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task ItShouldReturnFalseIfNoUsersCharged()
        {
            var userId1 = UserId.Random();
            var userId2 = UserId.Random();
            var userId3 = UserId.Random();
            var userId4 = UserId.Random();
            var userId5 = UserId.Random();
            var input = new List<CalculatedAccountBalanceResult>
            { 
                new CalculatedAccountBalanceResult(DateTime.UtcNow, UserId.Random(), LedgerAccountType.FifthweekCredit, TopUpUserAccountsWithCredit.MinimumAccountBalanceBeforeCharge),
                new CalculatedAccountBalanceResult(DateTime.UtcNow, UserId.Random(), LedgerAccountType.Stripe, 0),
                new CalculatedAccountBalanceResult(DateTime.UtcNow, userId1, LedgerAccountType.FifthweekCredit, TopUpUserAccountsWithCredit.MinimumAccountBalanceBeforeCharge - 1),
                new CalculatedAccountBalanceResult(DateTime.UtcNow, userId2, LedgerAccountType.FifthweekCredit, -1m),
            };

            var usersRequiringRetry = new List<UserId> { userId3, userId4, userId5 };
            this.getUsersRequiringPaymentRetry.Setup(v => v.ExecuteAsync()).ReturnsAsync(usersRequiringRetry);

            var usersRequiringCharge = new List<UserId> { userId1, userId2, userId3, userId4, userId5 };
            this.incrementPaymentStatus.Setup(v => v.ExecuteAsync(It.IsAny<IReadOnlyList<UserId>>()))
                .Callback<IReadOnlyList<UserId>>(v => CollectionAssert.AreEquivalent(usersRequiringCharge, v.ToList()))
                .Returns(Task.FromResult(0)).Verifiable();

            this.getUserWeeklySubscriptionsCost.Setup(v => v.ExecuteAsync(userId1)).ReturnsAsync(0);
            this.getUserWeeklySubscriptionsCost.Setup(v => v.ExecuteAsync(userId2)).ReturnsAsync(0);
            this.getUserWeeklySubscriptionsCost.Setup(v => v.ExecuteAsync(userId3)).ReturnsAsync(0);
            this.getUserWeeklySubscriptionsCost.Setup(v => v.ExecuteAsync(userId4)).ReturnsAsync(TopUpUserAccountsWithCredit.MinimumPaymentAmount * 2);
            this.getUserWeeklySubscriptionsCost.Setup(v => v.ExecuteAsync(userId5)).ReturnsAsync(TopUpUserAccountsWithCredit.MinimumPaymentAmount * 2);

            // Test PaymentOriginKey with no KeyType.
            this.getUserPaymentOrigin.Setup(v => v.ExecuteAsync(userId4))
                .ReturnsAsync(new UserPaymentOriginResult("customer4", PaymentOriginKeyType.None, null, null, null, null, PaymentStatus.Retry1));
            
            this.getUserPaymentOrigin.Setup(v => v.ExecuteAsync(userId5))
                .ReturnsAsync(new UserPaymentOriginResult("customer5", PaymentOriginKeyType.Stripe, null, null, null, null, PaymentStatus.None));

            var result = await this.target.ExecuteAsync(input, new List<PaymentProcessingException>());

            this.incrementPaymentStatus.Verify();

            Assert.IsFalse(result);
        }
    }
}