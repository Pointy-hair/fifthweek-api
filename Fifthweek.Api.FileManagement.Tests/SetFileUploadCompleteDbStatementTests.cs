namespace Fifthweek.Api.FileManagement.Tests
{
    using System;
    using System.Data.SqlTypes;
    using System.Threading;
    using System.Threading.Tasks;

    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.FileManagement.Shared;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Api.Persistence.Tests.Shared;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class SetFileUploadCompleteDbStatementTests : PersistenceTestsBase
    {
        private const string FileNameWithoutExtension = "myfile";
        private const string FileExtension = "jpeg";
        private const string Purpose = "profile-picture";
        private static readonly UserId UserId = new UserId(Guid.NewGuid());
        private static readonly FileId FileId = new FileId(Guid.NewGuid());
        private static readonly ChannelId ChannelId = new ChannelId(Guid.NewGuid());
        private static readonly DateTime TimeStamp = new SqlDateTime(DateTime.UtcNow).Value;
        private static readonly DateTime UploadStartedTimeStamp = new SqlDateTime(DateTime.UtcNow.AddSeconds(-180)).Value;

        private SetFileUploadCompleteDbStatement target;

        [TestInitialize]
        public void Initialize()
        {
            this.target = new SetFileUploadCompleteDbStatement(new Mock<IFifthweekDbConnectionFactory>(MockBehavior.Strict).Object);
        }

        [TestMethod]
        public async Task WhenSetFileUploadCompleteCalled_ItShouldUpdateTheDatabase()
        {
            await this.DatabaseTestAsync(async testDatabase =>
                {
                    this.target = new SetFileUploadCompleteDbStatement(testDatabase);

                    await this.CreateUserAsync(testDatabase);
                    await this.AddFileAsync(testDatabase);
                    await testDatabase.TakeSnapshotAsync();

                    const long NewLength = 11111L;

                    await this.target.ExecuteAsync(FileId, NewLength, TimeStamp);

                    var expectedFile = new File(
                        FileId.Value,
                        UserId.Value,
                        ChannelId.Value,
                        FileState.UploadComplete,
                        UploadStartedTimeStamp,
                        TimeStamp,
                        null,
                        null,
                        null,
                        FileNameWithoutExtension,
                        FileExtension,
                        NewLength,
                        Purpose,
                        null,
                        null);

                    using (var databaseContext = testDatabase.CreateContext())
                    {
                        var newFile = databaseContext.Files.Find(FileId.Value);
                        Assert.IsTrue(newFile.UploadStartedDate < newFile.UploadCompletedDate);
                        Assert.IsTrue((DateTime.UtcNow - newFile.UploadStartedDate) < TimeSpan.FromMinutes(5));
                        Assert.IsTrue((newFile.UploadCompletedDate - newFile.UploadStartedDate) < TimeSpan.FromMinutes(5));
                    }

                    return new ExpectedSideEffects
                    {
                        Update = expectedFile,
                    };
                });
        }

        [TestMethod]
        public async Task WhenSetFileUploadCompleteCalledTwice_ItShouldHaveNoEffect()
        {
            await this.DatabaseTestAsync(async testDatabase =>
                {
                    this.target = new SetFileUploadCompleteDbStatement(testDatabase);

                    await this.CreateUserAsync(testDatabase);
                    await this.AddFileAsync(testDatabase);

                    const long NewLength = 11111L;

                    await this.target.ExecuteAsync(FileId, NewLength, TimeStamp);
                    await testDatabase.TakeSnapshotAsync();

                    await this.target.ExecuteAsync(FileId, NewLength, TimeStamp);
                    return ExpectedSideEffects.None;
                });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task WhenSetFileUploadCompleteCalled_ItShouldRequireAFileId()
        {
            await this.target.ExecuteAsync(null, 123, TimeStamp);
        }

        private async Task CreateUserAsync(TestDatabaseContext testDatabase)
        {
            var random = new Random();
            var user = UserTests.UniqueEntity(random);
            user.Id = UserId.Value;

            using (var databaseContext = testDatabase.CreateContext())
            {
                databaseContext.Users.Add(user);
                await databaseContext.SaveChangesAsync();
            }
        }

        private async Task AddFileAsync(TestDatabaseContext testDatabase)
        {
            var file = new File(
                FileId.Value,
                UserId.Value,
                ChannelId.Value,
                FileState.WaitingForUpload,
                UploadStartedTimeStamp,
                null,
                null,
                null,
                null,
                FileNameWithoutExtension,
                FileExtension,
                0,
                Purpose,
                null,
                null);

            using (var databaseContext = testDatabase.CreateContext())
            {
                await databaseContext.Database.Connection.InsertAsync(file);
            }
        }
    }
}