﻿namespace Fifthweek.Api.Identity.Membership.Tests
{
    using System;
    using System.Data.SqlTypes;
    using System.Threading.Tasks;

    using Fifthweek.Api.Core;
    using Fifthweek.Api.FileManagement;
    using Fifthweek.Api.FileManagement.Shared;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.Api.Persistence.Payments;
    using Fifthweek.Api.Persistence.Tests.Shared;
    using Fifthweek.Payments.Services;
    using Fifthweek.Tests.Shared;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class GetAccountSettingsDbRepositoryTests : PersistenceTestsBase
    {
        private static readonly DateTime Now = DateTime.UtcNow;

        private static readonly Username Username = new Username("username");
        private static readonly UserId UserId = new UserId(Guid.NewGuid());
        private static readonly FileId FileId = new FileId(Guid.NewGuid());
        private static readonly Email Email = new Email("accountrepositorytests@testing.fifthweek.com");
        private static readonly decimal PercentageOverride = 0.9m;
        private static readonly DateTime Expiry = new SqlDateTime(DateTime.UtcNow).Value;
        private static readonly DateTime FreePostsTimestamp1 = Expiry.AddDays(1);
        private static readonly DateTime FreePostsTimestamp2 = Expiry.AddDays(2);
        private static readonly int MaximumFreePosts = 7;
        private static readonly int ExpectedFreePostRemaining = MaximumFreePosts - 2;

        private GetAccountSettingsDbStatement target;

        [TestInitialize]
        public void Initialize()
        {
            // Required for non-database tests.
            this.target = new GetAccountSettingsDbStatement(new Mock<IFifthweekDbConnectionFactory>(MockBehavior.Strict).Object);
        }

        [TestMethod]
        public async Task WhenGetAccountSettingsCalled_ItShouldGetAccountSettingsFromTheDatabase()
        {
            await this.DatabaseTestAsync(async testDatabase =>
            {
                this.target = new GetAccountSettingsDbStatement(testDatabase);
                await this.CreateDataAsync(
                    testDatabase,
                    UserId,
                    Username,
                    Email,
                    FileId,
                    0,
                    false,
                    false,
                    false);

                await testDatabase.TakeSnapshotAsync();

                var result = await this.target.ExecuteAsync(UserId, FreePostsTimestamp2, MaximumFreePosts);

                var expectedResult = new GetAccountSettingsDbResult(
                    Username,
                    Email,
                    FileId,
                    0,
                    PaymentStatus.None,
                    false,
                    null,
                    ExpectedFreePostRemaining);

                Assert.AreEqual(expectedResult, result);
                
                return ExpectedSideEffects.None;
            });
        }

        [TestMethod]
        public async Task WhenGetAccountSettingsCalledAndNoProfileImageExists_ItShouldGetAccountSettingsFromTheDatabase()
        {
            await this.DatabaseTestAsync(async testDatabase =>
            {
                this.target = new GetAccountSettingsDbStatement(testDatabase);
                await this.CreateDataAsync(
                    testDatabase,
                    UserId,
                    Username,
                    Email,
                    null,
                    0,
                    false,
                    false,
                    false);

                await testDatabase.TakeSnapshotAsync();

                var result = await this.target.ExecuteAsync(UserId, FreePostsTimestamp2, MaximumFreePosts);

                var expectedResult = new GetAccountSettingsDbResult(
                    Username,
                    Email,
                    null,
                    0,
                    PaymentStatus.None,
                    false,
                    null,
                    ExpectedFreePostRemaining);

                Assert.AreEqual(expectedResult, result);

                return ExpectedSideEffects.None;
            });
        }

        [TestMethod]
        public async Task WhenGetAccountSettingsCalledAndCalculatedAccountBalanceExists_ItShouldGetAccountSettingsFromTheDatabase()
        {
            await this.DatabaseTestAsync(async testDatabase =>
            {
                this.target = new GetAccountSettingsDbStatement(testDatabase);
                await this.CreateDataAsync(
                    testDatabase,
                    UserId,
                    Username,
                    Email,
                    FileId,
                    5,
                    false,
                    false,
                    false);

                await testDatabase.TakeSnapshotAsync();

                var result = await this.target.ExecuteAsync(UserId, FreePostsTimestamp2, MaximumFreePosts);

                var expectedResult = new GetAccountSettingsDbResult(
                    Username,
                    Email,
                    FileId,
                    100,
                    PaymentStatus.None,
                    false,
                    null,
                    ExpectedFreePostRemaining);

                Assert.AreEqual(expectedResult, result);

                return ExpectedSideEffects.None;
            });
        }

        [TestMethod]
        public async Task WhenGetAccountSettingsCalledAndOriginExists_ItShouldGetAccountSettingsFromTheDatabase()
        {
            await this.DatabaseTestAsync(async testDatabase =>
            {
                this.target = new GetAccountSettingsDbStatement(testDatabase);
                await this.CreateDataAsync(
                    testDatabase,
                    UserId,
                    Username,
                    Email,
                    FileId,
                    0,
                    true,
                    false,
                    false);

                await testDatabase.TakeSnapshotAsync();

                var result = await this.target.ExecuteAsync(UserId, FreePostsTimestamp2, MaximumFreePosts);

                var expectedResult = new GetAccountSettingsDbResult(
                    Username,
                    Email,
                    FileId,
                    0,
                    PaymentStatus.Retry2,
                    false,
                    null,
                    ExpectedFreePostRemaining);

                Assert.AreEqual(expectedResult, result);

                return ExpectedSideEffects.None;
            });
        }

        [TestMethod]
        public async Task WhenGetAccountSettingsCalledAndCreditCardExists_ItShouldGetAccountSettingsFromTheDatabase()
        {
            await this.DatabaseTestAsync(async testDatabase =>
            {
                this.target = new GetAccountSettingsDbStatement(testDatabase);
                await this.CreateDataAsync(
                    testDatabase,
                    UserId,
                    Username,
                    Email,
                    FileId,
                    0,
                    true,
                    true,
                    false);

                await testDatabase.TakeSnapshotAsync();

                var result = await this.target.ExecuteAsync(UserId, FreePostsTimestamp2, MaximumFreePosts);

                var expectedResult = new GetAccountSettingsDbResult(
                    Username,
                    Email,
                    FileId,
                    0,
                    PaymentStatus.Retry2,
                    true,
                    null,
                    ExpectedFreePostRemaining);

                Assert.AreEqual(expectedResult, result);

                return ExpectedSideEffects.None;
            });
        }

        [TestMethod]
        public async Task WhenGetAccountSettingsCalledWithInvalidUserId_ItShouldThrowARecoverableException()
        {
            await this.DatabaseTestAsync(async testDatabase =>
            {
                this.target = new GetAccountSettingsDbStatement(testDatabase);
                await this.CreateDataAsync(
                    testDatabase,
                    UserId,
                    Username,
                    Email,
                    FileId,
                    0,
                    false,
                    false,
                    false);

                await testDatabase.TakeSnapshotAsync();

                Func<Task> badMethodCall = () => this.target.ExecuteAsync(new UserId(Guid.NewGuid()), FreePostsTimestamp2, MaximumFreePosts);

                await badMethodCall.AssertExceptionAsync<DetailedRecoverableException>();

                return ExpectedSideEffects.None;
            });
        }

        [TestMethod]
        public async Task WhenGetAccountSettingsCalledWithNullUserId_ItShouldThrowAnAugumentException()
        {
            Func<Task> badMethodCall = () => this.target.ExecuteAsync(null, FreePostsTimestamp2, MaximumFreePosts);

            await badMethodCall.AssertExceptionAsync<ArgumentNullException>();
        }

        [TestMethod]
        public async Task WhenGetAccountSettingsCalledWithCreatorPercentageOverride_ItShouldGetAccountSettingsFromTheDatabase()
        {
            await this.DatabaseTestAsync(async testDatabase =>
            {
                this.target = new GetAccountSettingsDbStatement(testDatabase);
                await this.CreateDataAsync(
                    testDatabase,
                    UserId,
                    Username,
                    Email,
                    FileId,
                    0,
                    false,
                    false,
                    true);

                await testDatabase.TakeSnapshotAsync();

                var result = await this.target.ExecuteAsync(UserId, FreePostsTimestamp2, MaximumFreePosts);

                var expectedResult = new GetAccountSettingsDbResult(
                    Username,
                    Email,
                    FileId,
                    0,
                    PaymentStatus.None,
                    false,
                    new CreatorPercentageOverrideData(PercentageOverride, Expiry),
                    ExpectedFreePostRemaining);

                Assert.AreEqual(expectedResult, result);

                return ExpectedSideEffects.None;
            });
        }

        private async Task CreateDataAsync(
            TestDatabaseContext testDatabase, 
            UserId userId, 
            Username username, 
            Email email, 
            FileId fileId, 
            int accountBalanceCount,
            bool createOrigin,
            bool populateCreditCard,
            bool populateCreatorPercentageOverride)
        {
            var random = new Random();
            var user = UserTests.UniqueEntity(random);
            user.Id = userId.Value;
            user.Email = email.Value;
            user.UserName = username.Value;

            var postId1 = Guid.NewGuid();
            var postId2 = Guid.NewGuid();
            var postId3 = Guid.NewGuid();
            using (var databaseContext = testDatabase.CreateContext())
            {
                databaseContext.Users.Add(user);

                await databaseContext.CreateTestNoteAsync(Guid.NewGuid(), postId1, random);
                await databaseContext.CreateTestNoteAsync(Guid.NewGuid(), postId2, random);
                await databaseContext.CreateTestNoteAsync(Guid.NewGuid(), postId3, random);

                await databaseContext.SaveChangesAsync();
            }

            if (fileId != null)
            {
                var profileImageFile = FileTests.UniqueEntity(random);
                profileImageFile.Id = fileId.Value;
                profileImageFile.UserId = user.Id;

                using (var connection = testDatabase.CreateConnection())
                {
                    await connection.InsertAsync(profileImageFile);

                    user.ProfileImageFile = profileImageFile;
                    user.ProfileImageFileId = profileImageFile.Id;

                    await connection.UpdateAsync(user, FifthweekUser.Fields.ProfileImageFileId);
                }
            }

            using (var connection = testDatabase.CreateConnection())
            {
                await connection.InsertAsync(
                    new CalculatedAccountBalance(
                        user.Id,
                        LedgerAccountType.Stripe,
                        Now,
                        -120));

                await connection.InsertAsync(
                    new CalculatedAccountBalance(
                        user.Id,
                        LedgerAccountType.SalesTax,
                        Now,
                        20));

                await connection.InsertAsync(
                    new CalculatedAccountBalance(
                        user.Id,
                        LedgerAccountType.FifthweekRevenue,
                        Now,
                        200));

                for (int i = 0; i < accountBalanceCount; i++)
                {
                    await connection.InsertAsync(
                        new CalculatedAccountBalance(
                            user.Id,
                            LedgerAccountType.FifthweekCredit,
                            Now.AddHours(-1 - i),
                            100 + i));
                }

                if (createOrigin)
                {
                    if (populateCreditCard)
                    {
                        await connection.InsertAsync(
                            new UserPaymentOrigin(
                                user.Id,
                                null,
                                "blah",
                                PaymentOriginKeyType.Stripe,
                                null,
                                null,
                                null,
                                null,
                                PaymentStatus.Retry2));
                    }
                    else
                    {
                        var populateKey = random.NextDouble() > 0.5;
                        await connection.InsertAsync(
                            new UserPaymentOrigin(
                                user.Id,
                                null,
                                populateKey ? "blah" : null,
                                populateKey ? PaymentOriginKeyType.None : PaymentOriginKeyType.Stripe,
                                null,
                                null,
                                null,
                                null,
                                PaymentStatus.Retry2));
                    }
                }

                if (populateCreatorPercentageOverride)
                {
                    await connection.InsertAsync(new CreatorPercentageOverride(user.Id, PercentageOverride, Expiry));
                }

                await connection.InsertAsync(new FreePost(UserId.Value, postId1, null, FreePostsTimestamp1));
                await connection.InsertAsync(new FreePost(UserId.Value, postId2, null, FreePostsTimestamp2));
                await connection.InsertAsync(new FreePost(UserId.Value, postId3, null, FreePostsTimestamp2));
            }
        }
    }
}
