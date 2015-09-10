﻿namespace Fifthweek.Api.Posts.Tests
{
    using System;
    using System.Data.SqlTypes;
    using System.Threading.Tasks;

    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Collections.Shared;
    using Fifthweek.Api.FileManagement.Shared;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Api.Persistence.Tests.Shared;
    using Fifthweek.Api.Posts.Shared;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class CommentOnPostDbStatementTests : PersistenceTestsBase
    {
        private static readonly UserId CreatorId = new UserId(Guid.NewGuid());
        private static readonly UserId UserId = new UserId(Guid.NewGuid());
        private static readonly QueueId QueueId = new QueueId(Guid.NewGuid());
        private static readonly ChannelId ChannelId = new ChannelId(Guid.NewGuid());
        private static readonly PostId PostId = new PostId(Guid.NewGuid());
        private static readonly FileId FileId = new FileId(Guid.NewGuid());
        private static readonly CommentId CommentId = CommentId.Random();
        private static readonly Shared.Comment Comment = new Shared.Comment("comment");
        private static readonly DateTime Timestamp = new SqlDateTime(DateTime.UtcNow).Value;

        private Mock<IFifthweekDbConnectionFactory> connectionFactory;
        private CommentOnPostDbStatement target;

        [TestInitialize]
        public void Initialize()
        {
            this.connectionFactory = new Mock<IFifthweekDbConnectionFactory>(MockBehavior.Strict);

            this.InitializeTarget(this.connectionFactory.Object);
        }

        public void InitializeTarget(IFifthweekDbConnectionFactory connectionFactory)
        {
            this.target = new CommentOnPostDbStatement(connectionFactory);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task ItShouldRequireUserId()
        {
            await this.target.ExecuteAsync(null, PostId, CommentId, Comment, Timestamp);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task ItShouldRequirePostId()
        {
            await this.target.ExecuteAsync(UserId, null, CommentId, Comment, Timestamp);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task ItShouldRequireCommentId()
        {
            await this.target.ExecuteAsync(UserId, PostId, null, Comment, Timestamp);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task ItShouldRequireComment()
        {
            await this.target.ExecuteAsync(UserId, PostId, CommentId, null, Timestamp);
        }

        [TestMethod]
        public async Task ItShouldBeIdempotent()
        {
            await this.DatabaseTestAsync(async testDatabase =>
            {
                this.InitializeTarget(testDatabase);
                await this.CreateEntitiesAsync(testDatabase);
                await this.target.ExecuteAsync(UserId, PostId, CommentId, Comment, Timestamp);
                await testDatabase.TakeSnapshotAsync();

                await this.target.ExecuteAsync(UserId, PostId, CommentId, Comment, Timestamp);

                return ExpectedSideEffects.None;
            });
        }

        [TestMethod]
        public async Task ItShouldCompleteSuccessfully()
        {
            await this.DatabaseTestAsync(async testDatabase =>
            {
                this.InitializeTarget(testDatabase);
                await this.CreateEntitiesAsync(testDatabase);
                await testDatabase.TakeSnapshotAsync();

                var expectedInsert = new Persistence.Comment
                {
                    Id = CommentId.Value,
                    PostId = PostId.Value,
                    UserId = UserId.Value,
                    Content = Comment.Value,
                    CreationDate = Timestamp,
                };

                await this.target.ExecuteAsync(UserId, PostId, CommentId, Comment, Timestamp);

                return new ExpectedSideEffects
                {
                    Insert = expectedInsert,
                };
            });
        }

        private async Task CreateEntitiesAsync(TestDatabaseContext testDatabase)
        {
            using (var databaseContext = testDatabase.CreateContext())
            {
                var random = new Random();
                await databaseContext.CreateTestCollectionAsync(CreatorId.Value, ChannelId.Value, QueueId.Value);
                await databaseContext.CreateTestFileWithExistingUserAsync(CreatorId.Value, FileId.Value);

                var post = PostTests.UniqueFileOrImage(random);
                post.Id = PostId.Value;
                post.ChannelId = ChannelId.Value;
                post.QueueId = QueueId.Value;
                post.FileId = FileId.Value;
                post.CreationDate = new SqlDateTime(post.CreationDate).Value;
                post.LiveDate = new SqlDateTime(post.LiveDate).Value;
                await databaseContext.Database.Connection.InsertAsync(post);

                await databaseContext.CreateTestUserAsync(UserId.Value, random);
            }
        }
    }
}