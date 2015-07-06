﻿namespace Fifthweek.Api.Payments.Tests
{
    using System;
    using System.Threading.Tasks;

    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Api.Persistence.Payments;
    using Fifthweek.Api.Persistence.Tests.Shared;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class SetUserPaymentOriginOriginalTaxamoTransactionKeyDbStatementTests : PersistenceTestsBase
    {
        private static readonly UserId UserId = UserId.Random();

        private static readonly string NewTaxamoTransactionKey = "newTaxamoTransactionKey";
        private static readonly string StripeCustomerId = "stripeCustomerId";
        private static readonly ValidCountryCode CountryCode = ValidCountryCode.Parse("GB");
        private static readonly ValidCreditCardPrefix CreditCardPrefix = ValidCreditCardPrefix.Parse("123456");
        private static readonly ValidIpAddress IpAddress = ValidIpAddress.Parse("1.1.1.1");

        private SetUserPaymentOriginOriginalTaxamoTransactionKeyDbStatement target;

        [TestInitialize]
        public void Initialize()
        {
            this.target = new SetUserPaymentOriginOriginalTaxamoTransactionKeyDbStatement(new Mock<FifthweekDbConnectionFactory>(MockBehavior.Strict).Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task WhenUserIdIsNull_ItShouldThrowAnException()
        {
            await this.target.ExecuteAsync(
                null,
                NewTaxamoTransactionKey);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task WhenTaxamoTransactionKeyIsNull_ItShouldThrowAnException()
        {
            await this.target.ExecuteAsync(
                UserId,
                null);
        }

        [TestMethod]
        public async Task WhenValuesArePopulated_ItShouldSaveData()
        {
            await this.DatabaseTestAsync(async testDatabase =>
            {
                this.target = new SetUserPaymentOriginOriginalTaxamoTransactionKeyDbStatement(testDatabase);
                await this.CreateDataAsync(UserId, testDatabase, false);
                await testDatabase.TakeSnapshotAsync();

                await this.target.ExecuteAsync(
                    UserId,
                    NewTaxamoTransactionKey);

                return new ExpectedSideEffects
                {
                    Insert = new UserPaymentOrigin(
                        UserId.Value,
                        null,
                        null,
                        null,
                        null,
                        null,
                        NewTaxamoTransactionKey)
                };
            });
        }

        [TestMethod]
        public async Task WhenDataExistsAndNewValuesArePopulated_ItShouldSaveDataAndClearOriginalTransactionKey()
        {
            await this.DatabaseTestAsync(async testDatabase =>
            {
                this.target = new SetUserPaymentOriginOriginalTaxamoTransactionKeyDbStatement(testDatabase);
                await this.CreateDataAsync(UserId, testDatabase, true);
                await testDatabase.TakeSnapshotAsync();

                await this.target.ExecuteAsync(
                    UserId,
                    NewTaxamoTransactionKey);

                return new ExpectedSideEffects
                {
                    Update = new UserPaymentOrigin(
                        UserId.Value,
                        null,
                        StripeCustomerId,
                        CountryCode.Value,
                        CreditCardPrefix.Value,
                        IpAddress.Value,
                        NewTaxamoTransactionKey)
                };
            });
        }

        private async Task CreateDataAsync(UserId newUserId, TestDatabaseContext testDatabase, bool createOrigin)
        {
            var random = new Random();
            var user = UserTests.UniqueEntity(random);
            user.Id = newUserId.Value;

            UserPaymentOrigin origin = null;
            if (createOrigin)
            {
                origin = new UserPaymentOrigin(
                    UserId.Value,
                    user,
                    StripeCustomerId,
                    CountryCode.Value,
                    CreditCardPrefix.Value,
                    IpAddress.Value,
                    "anotherKey");
            }

            using (var databaseContext = testDatabase.CreateContext())
            {
                databaseContext.Users.Add(user);
                if (createOrigin)
                {
                    databaseContext.UserPaymentOrigins.Add(origin);
                }

                await databaseContext.SaveChangesAsync();
            }
        }
    }
}