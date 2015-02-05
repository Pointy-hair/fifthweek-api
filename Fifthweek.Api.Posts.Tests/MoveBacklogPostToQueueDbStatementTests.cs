﻿namespace Fifthweek.Api.Posts.Tests
{
    using System;
    using System.Data.Entity;
    using System.Data.SqlTypes;
    using System.Threading.Tasks;

    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Collections.Shared;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Api.Persistence.Tests.Shared;
    using Fifthweek.Api.Posts.Shared;
    using Fifthweek.Shared;
    using Fifthweek.Tests.Shared;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class MoveBacklogPostToQueueDbStatementTests : PersistenceTestsBase
    {
        private const int QueuedPostCount = 3;

        private static readonly Random Random = new Random();
        private static readonly UserId UserId = new UserId(Guid.NewGuid());
        private static readonly PostId PostId = new PostId(Guid.NewGuid());
        private static readonly ChannelId ChannelId = new ChannelId(Guid.NewGuid());
        private static readonly CollectionId CollectionId = new CollectionId(Guid.NewGuid());
        private static readonly CollectionId DifferentCollectionId = new CollectionId(Guid.NewGuid());
        private static readonly DateTime Now = DateTime.UtcNow;
        private static readonly DateTime ExistingFutureLiveDate = Now.AddDays(42);
        private static readonly DateTime ExistingPastLiveDate = Now.AddDays(-42);
        private static readonly DateTime UniqueLiveDate = Now.AddDays(50);

        private Mock<IGetLiveDateOfNewQueuedPostDbStatement> getLiveDateOfNewQueuedPost;
        private Mock<IFifthweekDbContext> databaseContext;
        private MoveBacklogPostToQueueDbStatement target;

        [TestInitialize]
        public void Initialize()
        {
            this.getLiveDateOfNewQueuedPost = new Mock<IGetLiveDateOfNewQueuedPostDbStatement>();

            // Give potentially side-effecting components strict mock behaviour.
            this.databaseContext = new Mock<IFifthweekDbContext>(MockBehavior.Strict);

            this.InitializeTarget(this.databaseContext.Object);
        }

        public void InitializeTarget(IFifthweekDbContext databaseContext)
        {
            this.target = new MoveBacklogPostToQueueDbStatement(databaseContext, this.getLiveDateOfNewQueuedPost.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task ItShouldRequirePostId()
        {
            await this.target.ExecuteAsync(null, CollectionId, Now);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task ItShouldRequireCollectionId()
        {
            await this.target.ExecuteAsync(PostId, null, Now);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task ItShouldRequireUtcDate()
        {
            await this.target.ExecuteAsync(PostId, CollectionId, DateTime.Now);
        }

        [TestMethod]
        public async Task ItShouldBeIdempotent()
        {
            await this.DatabaseTestAsync(async testDatabase =>
            {
                this.getLiveDateOfNewQueuedPost.Setup(_ => _.ExecuteAsync(CollectionId)).ReturnsAsync(UniqueLiveDate);

                this.InitializeTarget(testDatabase.NewContext());
                await this.CreateEntitiesAsync(testDatabase);
                await this.CreatePostAsync(testDatabase, ExistingFutureLiveDate);
                await this.target.ExecuteAsync(PostId, CollectionId, Now);
                await testDatabase.TakeSnapshotAsync();

                await this.target.ExecuteAsync(PostId, CollectionId, Now);

                return ExpectedSideEffects.None;
            });
        }

        [TestMethod]
        public async Task WhenCalculatedLiveDateIsUnique_AndPostNotInQueue_AndPostNotLive_AndCollectionNotChanged_ItShouldQueueThePost()
        {
            await this.DatabaseTestAsync(async testDatabase =>
            {
                this.getLiveDateOfNewQueuedPost.Setup(_ => _.ExecuteAsync(CollectionId)).ReturnsAsync(UniqueLiveDate);

                this.InitializeTarget(testDatabase.NewContext());
                await this.CreateEntitiesAsync(testDatabase);
                var post = await this.CreatePostAsync(testDatabase, ExistingFutureLiveDate);
                await testDatabase.TakeSnapshotAsync();

                await this.target.ExecuteAsync(PostId, CollectionId, Now);

                post.LiveDate = new SqlDateTime(UniqueLiveDate).Value;
                post.ScheduledByQueue = true;

                return new ExpectedSideEffects
                {
                    Update = post
                };
            });
        }

        [TestMethod]
        public async Task WhenPostAlreadyInQueue_ItShouldHaveNoEffect()
        {
            await this.DatabaseTestAsync(async testDatabase =>
            {
                this.getLiveDateOfNewQueuedPost.Setup(_ => _.ExecuteAsync(CollectionId)).ReturnsAsync(UniqueLiveDate);

                this.InitializeTarget(testDatabase.NewContext());
                await this.CreateEntitiesAsync(testDatabase);
                await this.CreatePostAsync(testDatabase, ExistingFutureLiveDate, scheduledByQueue: true);
                await testDatabase.TakeSnapshotAsync();

                await this.target.ExecuteAsync(PostId, CollectionId, Now);

                return ExpectedSideEffects.None;
            });
        }

        [TestMethod]
        public async Task WhenPostAlreadyLive_ItShouldHaveNoEffect()
        {
            await this.DatabaseTestAsync(async testDatabase =>
            {
                this.getLiveDateOfNewQueuedPost.Setup(_ => _.ExecuteAsync(CollectionId)).ReturnsAsync(UniqueLiveDate);

                this.InitializeTarget(testDatabase.NewContext());
                await this.CreateEntitiesAsync(testDatabase);
                await this.CreatePostAsync(testDatabase, ExistingPastLiveDate);
                await testDatabase.TakeSnapshotAsync();

                await this.target.ExecuteAsync(PostId, CollectionId, Now);

                return ExpectedSideEffects.None;
            });
        }

        [TestMethod]
        public async Task WhenPostHasChangedCollection_ItShouldThrowOptimisticConcurrencyException()
        {
            await this.DatabaseTestAsync(async testDatabase =>
            {
                this.getLiveDateOfNewQueuedPost.Setup(_ => _.ExecuteAsync(CollectionId)).ReturnsAsync(UniqueLiveDate);

                this.InitializeTarget(testDatabase.NewContext());
                await this.CreateEntitiesAsync(testDatabase);
                await this.CreatePostAsync(testDatabase, ExistingFutureLiveDate, differentCollection: true);
                await testDatabase.TakeSnapshotAsync();

                await ExpectedException.AssertExceptionAsync<OptimisticConcurrencyException>(() =>
                {
                    return this.target.ExecuteAsync(PostId, CollectionId, Now);
                });

                return ExpectedSideEffects.None;
            });
        }

        [TestMethod]
        public async Task WhenCalculatedLiveDateMatchesAnotherQueuedPostInDifferentCollection_ItShouldQueueThePost()
        {
            await this.DatabaseTestAsync(async testDatabase =>
            {
                this.getLiveDateOfNewQueuedPost.Setup(_ => _.ExecuteAsync(CollectionId)).ReturnsAsync(UniqueLiveDate);

                this.InitializeTarget(testDatabase.NewContext());
                await this.CreateEntitiesAsync(testDatabase);
                var post = await this.CreatePostAsync(testDatabase, ExistingFutureLiveDate);
                await this.CreateOtherPostAsync(testDatabase, UniqueLiveDate, scheduledByQueue: true, differentCollection: true);
                await testDatabase.TakeSnapshotAsync();

                await this.target.ExecuteAsync(PostId, CollectionId, Now);

                post.LiveDate = new SqlDateTime(UniqueLiveDate).Value;
                post.ScheduledByQueue = true;

                return new ExpectedSideEffects
                {
                    Update = post
                };
            });
        }

        [TestMethod]
        public async Task WhenCalculatedLiveDateMatchesAnotherScheduledPostInTheCollection_ItShouldQueueThePost()
        {
            await this.DatabaseTestAsync(async testDatabase =>
            {
                this.getLiveDateOfNewQueuedPost.Setup(_ => _.ExecuteAsync(CollectionId)).ReturnsAsync(UniqueLiveDate);

                this.InitializeTarget(testDatabase.NewContext());
                await this.CreateEntitiesAsync(testDatabase);
                var post = await this.CreatePostAsync(testDatabase, ExistingFutureLiveDate);
                await this.CreateOtherPostAsync(testDatabase, UniqueLiveDate, scheduledByQueue: false, differentCollection: false);
                await testDatabase.TakeSnapshotAsync();

                await this.target.ExecuteAsync(PostId, CollectionId, Now);

                post.LiveDate = new SqlDateTime(UniqueLiveDate).Value;
                post.ScheduledByQueue = true;

                return new ExpectedSideEffects
                {
                    Update = post
                };
            });
        }

        [TestMethod]
        public async Task WhenCalculatedLiveDateMatchesAnotherQueuedPostInTheCollection_ItShouldThrowOptimisticConcurrencyException()
        {
            await this.DatabaseTestAsync(async testDatabase =>
            {
                this.getLiveDateOfNewQueuedPost.Setup(_ => _.ExecuteAsync(CollectionId)).ReturnsAsync(UniqueLiveDate);

                this.InitializeTarget(testDatabase.NewContext());
                await this.CreateEntitiesAsync(testDatabase);
                await this.CreatePostAsync(testDatabase, ExistingFutureLiveDate);
                await this.CreateOtherPostAsync(testDatabase, UniqueLiveDate, scheduledByQueue: true, differentCollection: false);
                await testDatabase.TakeSnapshotAsync();

                await ExpectedException.AssertExceptionAsync<OptimisticConcurrencyException>(() =>
                {
                    return this.target.ExecuteAsync(PostId, CollectionId, Now);
                });

                return ExpectedSideEffects.None;
            });
        }

        private Task<Post> CreateOtherPostAsync(
            TestDatabaseContext testDatabase,
            DateTime liveDate,
            bool scheduledByQueue,
            bool differentCollection)
        {
            return this.CreatePostWithIdAsync(testDatabase, liveDate, scheduledByQueue, differentCollection, Guid.NewGuid());
        }

        private Task<Post> CreatePostAsync(
            TestDatabaseContext testDatabase,
            DateTime liveDate,
            bool scheduledByQueue = false,
            bool differentCollection = false)
        {
            return this.CreatePostWithIdAsync(testDatabase, liveDate, scheduledByQueue, differentCollection, PostId.Value);
        }

        private async Task<Post> CreatePostWithIdAsync(
            TestDatabaseContext testDatabase, 
            DateTime liveDate, 
            bool scheduledByQueue, 
            bool differentCollection,
            Guid postId)
        {
            using (var databaseContext = testDatabase.NewContext())
            {
                if (differentCollection)
                {
                    var collection = CollectionTests.UniqueEntity(Random);
                    collection.Id = DifferentCollectionId.Value;
                    collection.ChannelId = ChannelId.Value;
                    await databaseContext.Database.Connection.InsertAsync(collection);
                }

                var post = PostTests.UniqueFileOrImage(Random);
                post.Id = postId;
                post.ChannelId = ChannelId.Value;
                post.CollectionId = differentCollection ? DifferentCollectionId.Value : CollectionId.Value;
                post.ScheduledByQueue = scheduledByQueue;
                post.LiveDate = liveDate;
                await databaseContext.Database.Connection.InsertAsync(post);
            }

            using (var databaseContext = testDatabase.NewContext())
            {
                return await databaseContext.Posts.FirstAsync(_ => _.Id == postId);
            }
        }

        private async Task CreateEntitiesAsync(TestDatabaseContext testDatabase, bool createQueuedPosts = false)
        {
            using (var databaseContext = testDatabase.NewContext())
            {
                await databaseContext.CreateTestCollectionAsync(UserId.Value, ChannelId.Value, CollectionId.Value);

                if (createQueuedPosts)
                {
                    for (var i = 0; i <= QueuedPostCount; i++)
                    {
                        var post = PostTests.UniqueFileOrImage(Random);
                        post.ChannelId = ChannelId.Value;
                        post.CollectionId = CollectionId.Value;
                        post.ScheduledByQueue = true;
                        post.LiveDate = DateTime.UtcNow.AddDays(i);
                        await databaseContext.Database.Connection.InsertAsync(post);
                    }
                }
            }
        }
    }
}