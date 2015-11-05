namespace Fifthweek.Api.Blogs.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fifthweek.Api.Blogs.Shared;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.Api.Persistence.Tests.Shared;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class GetIsTestUserChannelDbStatementTests : PersistenceTestsBase
    {
        private static readonly BlogId BlogId = new BlogId(Guid.NewGuid());
        private static readonly UserId CreatorId = new UserId(Guid.NewGuid());
        private static readonly ChannelId ChannelId1 = new ChannelId(Guid.NewGuid());
        private GetIsTestUserChannelDbStatement target;

        [TestInitialize]
        public void Test()
        {
            this.target = new GetIsTestUserChannelDbStatement(new Mock<IFifthweekDbConnectionFactory>(MockBehavior.Strict).Object);
        }

        [TestMethod]
        public async Task WhenBlogBelongsToTestUser_ItShouldReturnTrue()
        {
            await this.DatabaseTestAsync(async testDatabase =>
                {
                    this.target = new GetIsTestUserChannelDbStatement(testDatabase);

                    await this.CreateDataAsync(testDatabase, true);
                    await testDatabase.TakeSnapshotAsync();

                    var result = await this.target.ExecuteAsync(ChannelId1);

                    Assert.IsTrue(result);

                    return ExpectedSideEffects.None;
                });
        }

        [TestMethod]
        public async Task WhenBlogBelongsToStandardUser_ItShouldReturnFalse()
        {
            await this.DatabaseTestAsync(async testDatabase =>
                {
                    this.target = new GetIsTestUserChannelDbStatement(testDatabase);

                    await this.CreateDataAsync(testDatabase, false);
                    await testDatabase.TakeSnapshotAsync();

                    var result = await this.target.ExecuteAsync(ChannelId1);

                    Assert.IsFalse(result);

                    return ExpectedSideEffects.None;
                });
        }

        [TestMethod]
        public async Task WhenBlogIsNotFound_ItShouldReturnFalse()
        {
            await this.DatabaseTestAsync(async testDatabase =>
                {
                    this.target = new GetIsTestUserChannelDbStatement(testDatabase);

                    await testDatabase.TakeSnapshotAsync();

                    var result = await this.target.ExecuteAsync(ChannelId1);

                    Assert.IsFalse(result);

                    return ExpectedSideEffects.None;
                });
        }

        private async Task CreateDataAsync(TestDatabaseContext testDatabase, bool setTestUser)
        {
            using (var context = testDatabase.CreateContext())
            {
                await context.CreateTestChannelAsync(CreatorId.Value, BlogId.Value, ChannelId1.Value);
            }

            if (setTestUser)
            {
                using (var connection = testDatabase.CreateConnection())
                {
                    var userRoles = new List<FifthweekUserRole>();
                    userRoles.Add(new FifthweekUserRole(FifthweekRole.TestUserId, CreatorId.Value));
                    await connection.InsertAsync(userRoles, false);
                }
            }
        }
    }
}