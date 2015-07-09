﻿namespace Fifthweek.Api.Posts.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlTypes;
    using System.Linq;
    using System.Threading.Tasks;

    using Fifthweek.Api.AssemblyResolution;
    using Fifthweek.Api.Blogs.Shared;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Collections.Shared;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.FileManagement.Shared;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.Api.Persistence.Payments;
    using Fifthweek.Api.Persistence.Tests.Shared;
    using Fifthweek.Api.Posts.Queries;
    using Fifthweek.Api.Posts.Shared;
    using Fifthweek.Shared;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class GetNewsfeedDbStatementTests : PersistenceTestsBase
    {
        // 1 in 3 chance of coincidental ordering being correct, yielding a false positive when implementation fails to order explicitly.
        const int ChannelsPerCreator = 3;
        const int CollectionsPerChannel = 3;
        const int Posts = 6;
        
        private static readonly UserId UnsubscribedUserId = new UserId(Guid.NewGuid());
        private static readonly UserId SubscribedLowPriceUserId = new UserId(Guid.NewGuid());
        private static readonly UserId SubscribedHighPriceUserId = new UserId(Guid.NewGuid());
        private static readonly UserId SubscribedUserId = new UserId(Guid.NewGuid());
        private static readonly UserId SubscribedUserIdNoBalance = new UserId(Guid.NewGuid());
        private static readonly UserId SubscribedUserIdZeroBalance = new UserId(Guid.NewGuid());
        private static readonly UserId SubscribedUserIdZeroBalancePaymentInProgress = new UserId(Guid.NewGuid());
        private static readonly UserId GuestListUserId = new UserId(Guid.NewGuid());
        private static readonly UserId CreatorId = new UserId(Guid.NewGuid());
        private static readonly List<ChannelId> ChannelIds;
        private static readonly List<List<CollectionId>> CollectionIds;
        private static readonly NonNegativeInt StartIndex = NonNegativeInt.Parse(10);
        private static readonly PositiveInt Count = PositiveInt.Parse(5);
        private static readonly BlogId BlogId = new BlogId(Guid.NewGuid());
        private static readonly Comment Comment = new Comment("Hey guys!");
        private static readonly Random Random = new Random();
        private static readonly DateTime Now = new SqlDateTime(DateTime.UtcNow).Value;
        private static readonly string FileName = "FileName";
        private static readonly string FileExtension = "FileExtension";
        private static readonly long FileSize = 1024;
        private static readonly int FileWidth = 800;
        private static readonly int FileHeight = 600;
        private static readonly int ChannelPrice = 10;
        private static readonly IReadOnlyList<NewsfeedPost> SortedNewsfeedPosts;
        private static readonly IReadOnlyList<NewsfeedPost> SortedLiveNewsfeedPosts;

        static GetNewsfeedDbStatementTests()
        {
            ChannelIds = new List<ChannelId>();
            CollectionIds = new List<List<CollectionId>>();
            for (int i = 0; i < ChannelsPerCreator; i++)
            {
                ChannelIds.Add(new ChannelId(Guid.NewGuid()));

                var collectionIds = new List<CollectionId>();
                CollectionIds.Add(collectionIds);

                for (int j = 0; j < CollectionsPerChannel; j++)
                {
                    // Null colleciton is for notes.
                    collectionIds.Add(j == 0 ? null : new CollectionId(Guid.NewGuid()));
                }
            }

            SortedNewsfeedPosts = GetSortedNewsfeedPosts().ToList();
            SortedLiveNewsfeedPosts = SortedNewsfeedPosts.Where(v => v.LiveDate <= Now).ToList();
        }

        private readonly Random random = new Random();
        
        private Mock<IFifthweekDbConnectionFactory> connectionFactory;

        private GetNewsfeedDbStatement target;

        [TestInitialize]
        public void Initialize()
        {
            DapperTypeHandlerRegistration.Register(FifthweekAssembliesResolver.Assemblies);

            this.connectionFactory = new Mock<IFifthweekDbConnectionFactory>(MockBehavior.Strict);

            this.target = new GetNewsfeedDbStatement(this.connectionFactory.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task ItShouldRequireUserId()
        {
            await this.target.ExecuteAsync(null, CreatorId, ChannelIds, CollectionIds[0], Now, Now, false, StartIndex, Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task ItShouldRequireStartIndex()
        {
            await this.target.ExecuteAsync(SubscribedUserId, CreatorId, ChannelIds, CollectionIds[0], Now, Now, false, null, Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task ItShouldRequireCount()
        {
            await this.target.ExecuteAsync(SubscribedUserId, CreatorId, ChannelIds, CollectionIds[0], Now, Now, false, StartIndex, null);
        }

        [TestMethod]
        public async Task ItShouldReturnPostsWithLiveDateInPastOrNow()
        {
            await this.DatabaseTestAsync(async testDatabase =>
            {
                this.target = new GetNewsfeedDbStatement(testDatabase);
                await this.CreateEntitiesAsync(testDatabase, createLivePosts: true, createFuturePosts: true);
                await testDatabase.TakeSnapshotAsync();

                await this.ParameterizedTestAsync(async (userId, creatorId, channelIds, collectionIds, origin, searchForwards, startIndex, count, expectedPosts, expectedAccountBalance) =>
                {
                    var result = await this.target.ExecuteAsync(userId, creatorId, channelIds, collectionIds, Now, origin, searchForwards, startIndex, count);

                    foreach (var newsfeedPost in result.Posts)
                    {
                        Assert.IsTrue(newsfeedPost.LiveDate <= Now);
                    }
                });

                return ExpectedSideEffects.None;
            });
        }

        [TestMethod]
        public async Task ItShouldReturnPostsForUser()
        {
            await this.DatabaseTestAsync(async testDatabase =>
            {
                this.target = new GetNewsfeedDbStatement(testDatabase);
                await this.CreateEntitiesAsync(testDatabase, createLivePosts: true, createFuturePosts: true);
                await testDatabase.TakeSnapshotAsync();

                await this.ParameterizedTestAsync(async (userId, creatorId, channelIds, collectionIds, origin, searchForwards, startIndex, count, expectedPosts, expectedAccountBalance) =>
                {
                    var result = await this.target.ExecuteAsync(userId, creatorId, channelIds, collectionIds, Now, origin, searchForwards, startIndex, count);

                    CollectionAssert.AreEquivalent(expectedPosts.ToList(), result.Posts.ToList());
                });

                return ExpectedSideEffects.None;
            });
        }

        [TestMethod]
        public async Task ItShouldReturnExpectedAccountBalances()
        {
            await this.DatabaseTestAsync(async testDatabase =>
            {
                this.target = new GetNewsfeedDbStatement(testDatabase);
                await this.CreateEntitiesAsync(testDatabase, createLivePosts: true, createFuturePosts: true);
                await testDatabase.TakeSnapshotAsync();

                await this.ParameterizedTestAsync(async (userId, creatorId, channelIds, collectionIds, origin, searchForwards, startIndex, count, expectedPosts, expectedAccountBalance) =>
                {
                    var result = await this.target.ExecuteAsync(userId, creatorId, channelIds, collectionIds, Now, origin, searchForwards, startIndex, count);
                    Assert.AreEqual(expectedAccountBalance, result.AccountBalance);
                });

                return ExpectedSideEffects.None;
            });
        }

        [TestMethod]
        public async Task ItShouldReturnPostsWithDatesAsUtc()
        {
            await this.DatabaseTestAsync(async testDatabase =>
            {
                this.target = new GetNewsfeedDbStatement(testDatabase);
                await this.CreateEntitiesAsync(testDatabase, createLivePosts: true, createFuturePosts: true);
                await testDatabase.TakeSnapshotAsync();

                await this.ParameterizedTestAsync(async (userId, creatorId, channelIds, collectionIds, origin, searchForwards, startIndex, count, expectedPosts, expectedAccountBalance) =>
                {
                    var result = await this.target.ExecuteAsync(userId, creatorId, channelIds, collectionIds, Now, origin, searchForwards, startIndex, count);

                    foreach (var item in result.Posts)
                    {
                        Assert.AreEqual(DateTimeKind.Utc, item.LiveDate.Kind);
                        Assert.AreEqual(DateTimeKind.Utc, item.CreationDate.Kind);
                    }
                });

                return ExpectedSideEffects.None;
            });
        }

        [TestMethod]
        public async Task ItShouldOrderPostsCorrectly()
        {
            await this.DatabaseTestAsync(async testDatabase =>
            {
                this.target = new GetNewsfeedDbStatement(testDatabase);
                await this.CreateEntitiesAsync(testDatabase, createLivePosts: true, createFuturePosts: true);
                await testDatabase.TakeSnapshotAsync();

                await this.ParameterizedTestAsync(async (userId, creatorId, channelIds, collectionIds, origin, searchForwards, startIndex, count, expectedPosts, expectedAccountBalance) =>
                {
                    var result = await this.target.ExecuteAsync(userId, creatorId, channelIds, collectionIds, Now, origin, searchForwards, startIndex, count);

                    Func<NewsfeedPost, NewsfeedPost> removeSortInsensitiveValues = post => post.Copy(_ =>
                    {
                        // Required fields. Set to a value that is equal across all elements.
                        _.PostId = new PostId(Guid.Empty);
                        _.ChannelId = new ChannelId(Guid.Empty);
                        _.CreatorId = new UserId(Guid.Empty);

                        // Non required fields.
                        _.Comment = null;
                        _.FileId = null;
                        _.FileName = null;
                        _.FileExtension = null;
                        _.FileSize = null;
                        _.ImageId = null;
                        _.ImageName = null;
                        _.ImageExtension = null;
                        _.ImageSize = null;
                        _.ImageRenderWidth = null;
                        _.ImageRenderHeight = null;
                        _.CollectionId = null;
                    });

                    var expectedOrder = expectedPosts.Select(removeSortInsensitiveValues).ToList();
                    var actualOrder = result.Posts.Select(removeSortInsensitiveValues).ToList();

                    CollectionAssert.AreEqual(expectedOrder, actualOrder);
                });

                return ExpectedSideEffects.None;
            });
        }

        [TestMethod]
        public async Task ItShouldReturnNothingWhenUserHasNoPosts()
        {
            await this.DatabaseTestAsync(async testDatabase =>
            {
                this.target = new GetNewsfeedDbStatement(testDatabase);
                await this.CreateEntitiesAsync(testDatabase, createLivePosts: false, createFuturePosts: false);
                await testDatabase.TakeSnapshotAsync();

                await this.ParameterizedTestAsync(async (userId, creatorId, channelIds, collectionIds, origin, searchForwards, startIndex, count, expectedPosts, expectedAccountBalance) =>
                {
                    var result = await this.target.ExecuteAsync(userId, creatorId, channelIds, collectionIds, Now, origin, searchForwards, startIndex, count);
                    Assert.AreEqual(result.Posts.Count, 0);
                });

                return ExpectedSideEffects.None;
            });
        }

        [TestMethod]
        public async Task ItShouldReturnNothingWhenUserHasNoPostsWithLiveDateInPastOrNow()
        {
            await this.DatabaseTestAsync(async testDatabase =>
            {
                this.target = new GetNewsfeedDbStatement(testDatabase);
                await this.CreateEntitiesAsync(testDatabase, createLivePosts: false, createFuturePosts: true);
                await testDatabase.TakeSnapshotAsync();

                await this.ParameterizedTestAsync(async (userId, creatorId, channelIds, collectionIds, origin, searchForwards, startIndex, count, expectedPosts, expectedAccountBalance) =>
                {
                    var result = await this.target.ExecuteAsync(userId, creatorId, channelIds, collectionIds, Now, origin, searchForwards, startIndex, count);
                    Assert.AreEqual(result.Posts.Count, 0);
                });

                return ExpectedSideEffects.None;
            });
        }

        private async Task ParameterizedTestAsync(
            Func<UserId, 
                 UserId, 
                 IReadOnlyList<ChannelId>,
                 IReadOnlyList<CollectionId>, 
                 DateTime,
                 bool,
                 NonNegativeInt,
                 PositiveInt,
                 IReadOnlyList<NewsfeedPost>,
                 int,
                 Task> parameterizedTest)
        {
            var totalLivePosts = SortedLiveNewsfeedPosts.Count;

            NonNegativeInt noPaginationStart = NonNegativeInt.Parse(0);
            PositiveInt noPaginationCount = PositiveInt.Parse(int.MaxValue);

            // No pagination.
            await parameterizedTest(
                CreatorId, CreatorId, null, null, Now, false, noPaginationStart, noPaginationCount, SortedLiveNewsfeedPosts, 0);

            // Paginate from start.
            await parameterizedTest(
                CreatorId, CreatorId, null, null, Now, false, NonNegativeInt.Parse(0), PositiveInt.Parse(10), SortedLiveNewsfeedPosts.Take(10).ToList(), 0);

            // Paginate from middle with different page size and page index.
            await parameterizedTest(
                CreatorId, CreatorId, null, null, Now, false, NonNegativeInt.Parse(5), PositiveInt.Parse(10), SortedLiveNewsfeedPosts.Skip(5).Take(10).ToList(), 0);

            // Paginate from middle with same page size and page index.
            await parameterizedTest(
                CreatorId, CreatorId, null, null, Now, false, NonNegativeInt.Parse(10), PositiveInt.Parse(10), SortedLiveNewsfeedPosts.Skip(10).Take(10).ToList(), 0);

            // Paginate from near end, requesting up to last post.
            await parameterizedTest(
                CreatorId, CreatorId, null, null, Now, false, NonNegativeInt.Parse(totalLivePosts - 10), PositiveInt.Parse(10), SortedLiveNewsfeedPosts.Skip(totalLivePosts - 10).Take(10).ToList(), 0);

            // Paginate from near end, requesting beyond last post.
            await parameterizedTest(
                CreatorId, CreatorId, null, null, Now, false, NonNegativeInt.Parse(totalLivePosts - 5), PositiveInt.Parse(10), SortedLiveNewsfeedPosts.Skip(totalLivePosts - 5).Take(10).ToList(), 0);

            // Paginate from end, requesting beyond last post.
            await parameterizedTest(
                CreatorId, CreatorId, null, null, Now, false, NonNegativeInt.Parse(totalLivePosts), PositiveInt.Parse(1), new NewsfeedPost[0], 0);

            // Paginate from beyond end, requesting beyond last post.
            await parameterizedTest(
                CreatorId, CreatorId, null, null, Now, false, NonNegativeInt.Parse(totalLivePosts + 1), PositiveInt.Parse(1), new NewsfeedPost[0], 0);

            // Unsubscribed.
            await parameterizedTest(
                UnsubscribedUserId, CreatorId, null, null, Now, false, noPaginationStart, noPaginationCount, new NewsfeedPost[0], 0);

            // Subscribed at correct price.
            await parameterizedTest(
                SubscribedUserId, CreatorId, null, null, Now, false, noPaginationStart, noPaginationCount, SortedLiveNewsfeedPosts.Where(v => !v.ChannelId.Equals(ChannelIds[2])).ToList(), 10);

            // Subscribed at low price.
            await parameterizedTest(
                SubscribedLowPriceUserId, CreatorId, null, null, Now, false, noPaginationStart, noPaginationCount, new NewsfeedPost[0], 10);

            // Subscribed at high price.
            await parameterizedTest(
                SubscribedHighPriceUserId, CreatorId, null, null, Now, false, noPaginationStart, noPaginationCount, SortedLiveNewsfeedPosts.Where(v => !v.ChannelId.Equals(ChannelIds[2])).ToList(), 10);

            // Subscribed at zero, but on free access list.
            await parameterizedTest(
                GuestListUserId, CreatorId, null, null, Now, false, noPaginationStart, noPaginationCount, SortedLiveNewsfeedPosts.Where(v => !v.ChannelId.Equals(ChannelIds[2])).ToList(), 0);

            // Subscribed with no balance.
            await parameterizedTest(
                SubscribedUserIdNoBalance, CreatorId, null, null, Now, false, noPaginationStart, noPaginationCount, new NewsfeedPost[0], 0);

            // Subscribed with zero balance.
            await parameterizedTest(
                SubscribedUserIdZeroBalance, CreatorId, null, null, Now, false, noPaginationStart, noPaginationCount, new NewsfeedPost[0], 0);

            // Subscribed with zero balance but retrying billing.
            await parameterizedTest(
                SubscribedUserIdZeroBalancePaymentInProgress, CreatorId, null, null, Now, false, noPaginationStart, noPaginationCount, SortedLiveNewsfeedPosts.Where(v => !v.ChannelId.Equals(ChannelIds[2])).ToList(), 0);

            // Filter by channel for creator.
            await parameterizedTest(
                CreatorId, CreatorId, new[] { ChannelIds[0] }, null, Now, false, noPaginationStart, noPaginationCount, SortedLiveNewsfeedPosts.Where(v => v.ChannelId.Equals(ChannelIds[0])).ToList(), 0);

            // Filter by channel.
            await parameterizedTest(
                SubscribedUserId, null, new[] { ChannelIds[0] }, null, Now, false, noPaginationStart, noPaginationCount, SortedLiveNewsfeedPosts.Where(v => v.ChannelId.Equals(ChannelIds[0])).ToList(), 10);

            // Filter by channel 2.
            await parameterizedTest(
                SubscribedUserId, null, new[] { ChannelIds[1] }, null, Now, false, noPaginationStart, noPaginationCount, SortedLiveNewsfeedPosts.Where(v => v.ChannelId.Equals(ChannelIds[1])).ToList(), 10);

            // Filter by unsubscribed channel 3.
            await parameterizedTest(
                SubscribedUserId, null, new[] { ChannelIds[2] }, null, Now, false, noPaginationStart, noPaginationCount, new NewsfeedPost[0], 10);

            // Filter by valid channel and creator combination.
            await parameterizedTest(
                SubscribedUserId, CreatorId, new[] { ChannelIds[0] }, null, Now, false, noPaginationStart, noPaginationCount, SortedLiveNewsfeedPosts.Where(v => v.ChannelId.Equals(ChannelIds[0])).ToList(), 10);

            // Filter by invalid channel and creator combination.
            await parameterizedTest(
                SubscribedUserId, GuestListUserId, new[] { ChannelIds[0] }, null, Now, false, noPaginationStart, noPaginationCount, new NewsfeedPost[0], 10);

            // Filter by collection for creator.
            await parameterizedTest(
                CreatorId, CreatorId, null, new[] { CollectionIds[0][1] }, Now, false, noPaginationStart, noPaginationCount, SortedLiveNewsfeedPosts.Where(v => CollectionIds[0][1].Equals(v.CollectionId)).ToList(), 0);

            // Filter by collection.
            await parameterizedTest(
                SubscribedUserId, null, null, new[] { CollectionIds[0][1] }, Now, false, noPaginationStart, noPaginationCount, SortedLiveNewsfeedPosts.Where(v => CollectionIds[0][1].Equals(v.CollectionId)).ToList(), 10);

            // Filter by valid collection and creator combination.
            await parameterizedTest(
                SubscribedUserId, CreatorId, null, new[] { CollectionIds[0][1] }, Now, false, noPaginationStart, noPaginationCount, SortedLiveNewsfeedPosts.Where(v => CollectionIds[0][1].Equals(v.CollectionId)).ToList(), 10);

            // Filter by invalid collection and creator combination.
            await parameterizedTest(
                SubscribedUserId, GuestListUserId, null, new[] { CollectionIds[0][1] }, Now, false, noPaginationStart, noPaginationCount, new NewsfeedPost[0], 10);

            // Filter by valid channel and collection combination.
            await parameterizedTest(
                SubscribedUserId, null, new[] { ChannelIds[0] }, new[] { CollectionIds[0][1] }, Now, false, noPaginationStart, noPaginationCount, SortedLiveNewsfeedPosts.Where(v => CollectionIds[0][1].Equals(v.CollectionId)).ToList(), 10);

            // Filter by invalid channel and collection combination.
            await parameterizedTest(
                SubscribedUserId, null, new[] { ChannelIds[1] }, new[] { CollectionIds[0][1] }, Now, false, noPaginationStart, noPaginationCount, new NewsfeedPost[0], 10);

            // Filter by valid creator, channel and collection combination.
            await parameterizedTest(
                SubscribedUserId, CreatorId, new[] { ChannelIds[0] }, new[] { CollectionIds[0][1] }, Now, false, noPaginationStart, noPaginationCount, SortedLiveNewsfeedPosts.Where(v => CollectionIds[0][1].Equals(v.CollectionId)).ToList(), 10);

            // Filter by invalid creator, channel and collection combination.
            await parameterizedTest(
                SubscribedUserId, GuestListUserId, new[] { ChannelIds[0] }, new[] { CollectionIds[0][1] }, Now, false, noPaginationStart, noPaginationCount, new NewsfeedPost[0], 10);

            // Search forwards from now.
            await parameterizedTest(
                CreatorId, CreatorId, null, null, Now, true, noPaginationStart, noPaginationCount, new NewsfeedPost[0], 0);

            // Search forwards from beginning.
            await parameterizedTest(
                CreatorId, CreatorId, null, null, SqlDateTime.MinValue.Value, true, noPaginationStart, noPaginationCount, SortedLiveNewsfeedPosts.Reverse().ToList(), 0);

            // Paginate forwards from middle with different page size and page index.
            await parameterizedTest(
                CreatorId, CreatorId, null, null, SqlDateTime.MinValue.Value, true, NonNegativeInt.Parse(5), PositiveInt.Parse(10), SortedLiveNewsfeedPosts.Reverse().Skip(5).Take(10).ToList(), 0);
        }

        private async Task CreateEntitiesAsync(TestDatabaseContext testDatabase, bool createLivePosts, bool createFuturePosts)
        {
            using (var databaseContext = testDatabase.CreateContext())
            {
                await this.CreateUserAsync(databaseContext, UnsubscribedUserId);
                await this.CreateUserAsync(databaseContext, SubscribedUserId);
                await this.CreateUserAsync(databaseContext, SubscribedLowPriceUserId);
                await this.CreateUserAsync(databaseContext, SubscribedHighPriceUserId);
                await this.CreateUserAsync(databaseContext, SubscribedUserIdNoBalance);
                await this.CreateUserAsync(databaseContext, SubscribedUserIdZeroBalance);
                await this.CreateUserAsync(databaseContext, SubscribedUserIdZeroBalancePaymentInProgress);
                await this.CreateUserAsync(databaseContext, GuestListUserId);

                var channelSubscriptions = new List<ChannelSubscription>();
                var calculatedAccountBalances = new List<CalculatedAccountBalance>();
                var freeAccessUsers = new List<FreeAccessUser>();
                
                var channels = new Dictionary<ChannelId, List<CollectionId>>();
                var files = new List<FileId>();
                var images = new List<FileId>();
                var channelEntities = new List<Channel>();
                var collectionEntities = new List<Collection>();
                var postEntities = new List<Post>();
                var origins = new List<UserPaymentOrigin>();


                if (createLivePosts || createFuturePosts)
                {
                    channelSubscriptions.Add(new ChannelSubscription(ChannelIds[0].Value, null, SubscribedUserId.Value, null, ChannelPrice, Now, Now));
                    channelSubscriptions.Add(new ChannelSubscription(ChannelIds[1].Value, null, SubscribedUserId.Value, null, ChannelPrice, Now, Now));
                    calculatedAccountBalances.Add(new CalculatedAccountBalance(SubscribedUserId.Value, LedgerAccountType.Fifthweek, Now, 10));
                    calculatedAccountBalances.Add(new CalculatedAccountBalance(SubscribedUserId.Value, LedgerAccountType.Fifthweek, Now.AddDays(-1), 0));

                    channelSubscriptions.Add(new ChannelSubscription(ChannelIds[0].Value, null, SubscribedUserIdNoBalance.Value, null, ChannelPrice, Now, Now));
                    channelSubscriptions.Add(new ChannelSubscription(ChannelIds[1].Value, null, SubscribedUserIdNoBalance.Value, null, ChannelPrice, Now, Now));
                    origins.Add(new UserPaymentOrigin(SubscribedUserIdNoBalance.Value, null, null, null, null, null, null, PaymentStatus.Failed));

                    // The query should round down to zero for account balance.
                    channelSubscriptions.Add(new ChannelSubscription(ChannelIds[0].Value, null, SubscribedUserIdZeroBalance.Value, null, ChannelPrice, Now, Now));
                    channelSubscriptions.Add(new ChannelSubscription(ChannelIds[1].Value, null, SubscribedUserIdZeroBalance.Value, null, ChannelPrice, Now, Now));
                    calculatedAccountBalances.Add(new CalculatedAccountBalance(SubscribedUserIdZeroBalance.Value, LedgerAccountType.Fifthweek, Now.AddDays(-1), 10));
                    calculatedAccountBalances.Add(new CalculatedAccountBalance(SubscribedUserIdZeroBalance.Value, LedgerAccountType.Fifthweek, Now, 0.8m));

                    channelSubscriptions.Add(new ChannelSubscription(ChannelIds[0].Value, null, SubscribedUserIdZeroBalancePaymentInProgress.Value, null, ChannelPrice, Now, Now));
                    channelSubscriptions.Add(new ChannelSubscription(ChannelIds[1].Value, null, SubscribedUserIdZeroBalancePaymentInProgress.Value, null, ChannelPrice, Now, Now));
                    calculatedAccountBalances.Add(new CalculatedAccountBalance(SubscribedUserIdZeroBalancePaymentInProgress.Value, LedgerAccountType.Fifthweek, Now.AddDays(-1), 10));
                    calculatedAccountBalances.Add(new CalculatedAccountBalance(SubscribedUserIdZeroBalancePaymentInProgress.Value, LedgerAccountType.Fifthweek, Now, 0.8m));
                    origins.Add(new UserPaymentOrigin(SubscribedUserIdZeroBalancePaymentInProgress.Value, null, null, null, null, null, null, PaymentStatus.Retry1));

                    channelSubscriptions.Add(new ChannelSubscription(ChannelIds[0].Value, null, SubscribedLowPriceUserId.Value, null, ChannelPrice / 2, Now, Now));
                    channelSubscriptions.Add(new ChannelSubscription(ChannelIds[1].Value, null, SubscribedLowPriceUserId.Value, null, ChannelPrice / 2, Now, Now));
                    calculatedAccountBalances.Add(new CalculatedAccountBalance(SubscribedLowPriceUserId.Value, LedgerAccountType.Fifthweek, Now, 10));
                    
                    channelSubscriptions.Add(new ChannelSubscription(ChannelIds[0].Value, null, SubscribedHighPriceUserId.Value, null, ChannelPrice * 2, Now, Now));
                    channelSubscriptions.Add(new ChannelSubscription(ChannelIds[1].Value, null, SubscribedHighPriceUserId.Value, null, ChannelPrice * 2, Now, Now));
                    calculatedAccountBalances.Add(new CalculatedAccountBalance(SubscribedHighPriceUserId.Value, LedgerAccountType.Fifthweek, Now, 10));
                    
                    channelSubscriptions.Add(new ChannelSubscription(ChannelIds[0].Value, null, GuestListUserId.Value, null, 0, Now, Now));
                    channelSubscriptions.Add(new ChannelSubscription(ChannelIds[1].Value, null, GuestListUserId.Value, null, 0, Now, Now));

                    freeAccessUsers.Add(new FreeAccessUser(BlogId.Value, GuestListUserId.Value + "@test.com"));


                    foreach (var newsfeedPost in SortedNewsfeedPosts)
                    {
                        if (createLivePosts && !createFuturePosts && newsfeedPost.LiveDate > Now)
                        {
                            continue;
                        }

                        if (!createLivePosts && createFuturePosts && newsfeedPost.LiveDate <= Now)
                        {
                            continue;
                        }

                        if (newsfeedPost.FileId != null)
                        {
                            files.Add(newsfeedPost.FileId);
                        }

                        if (newsfeedPost.ImageId != null)
                        {
                            images.Add(newsfeedPost.ImageId);
                        }

                        if (!channels.ContainsKey(newsfeedPost.ChannelId))
                        {
                            channels.Add(newsfeedPost.ChannelId, new List<CollectionId>());
                        }

                        if (newsfeedPost.CollectionId != null)
                        {
                            channels[newsfeedPost.ChannelId].Add(newsfeedPost.CollectionId);
                        }

                        postEntities.Add(new Post(
                            newsfeedPost.PostId.Value,
                            newsfeedPost.ChannelId.Value,
                            null,
                            newsfeedPost.CollectionId == null ? (Guid?)null : newsfeedPost.CollectionId.Value,
                            null,
                            newsfeedPost.FileId == null ? (Guid?)null : newsfeedPost.FileId.Value,
                            null,
                            newsfeedPost.ImageId == null ? (Guid?)null : newsfeedPost.ImageId.Value,
                            null,
                            newsfeedPost.Comment == null ? null : newsfeedPost.Comment.Value,
                            Random.Next(2) == 0,
                            newsfeedPost.LiveDate,
                            newsfeedPost.CreationDate));
                    }
                }

                foreach (var channelKvp in channels)
                {
                    var channelId = channelKvp.Key;

                    var channel = ChannelTests.UniqueEntity(Random);
                    channel.Id = channelId.Value;
                    channel.BlogId = BlogId.Value;
                    channel.PriceInUsCentsPerWeek = ChannelPrice;

                    channelEntities.Add(channel);

                    foreach (var collectionId in channelKvp.Value)
                    {
                        var collection = CollectionTests.UniqueEntity(Random);
                        collection.Id = collectionId.Value;
                        collection.ChannelId = channelId.Value;

                        collectionEntities.Add(collection);
                    }
                }

                var fileEntities = files.Select(fileId =>
                {
                    var file = FileTests.UniqueEntity(Random);
                    file.Id = fileId.Value;
                    file.UserId = CreatorId.Value;
                    file.FileNameWithoutExtension = FileName;
                    file.FileExtension = FileExtension;
                    file.BlobSizeBytes = FileSize;
                    return file;
                });

                var imageEntities = images.Select(fileId =>
                {
                    var file = FileTests.UniqueEntity(Random);
                    file.Id = fileId.Value;
                    file.UserId = CreatorId.Value;
                    file.FileNameWithoutExtension = FileName;
                    file.FileExtension = FileExtension;
                    file.BlobSizeBytes = FileSize;
                    file.RenderWidth = FileWidth;
                    file.RenderHeight = FileHeight;
                    return file;
                });

                await databaseContext.CreateTestBlogAsync(CreatorId.Value, BlogId.Value);
                await databaseContext.Database.Connection.InsertAsync(channelEntities);
                await databaseContext.Database.Connection.InsertAsync(collectionEntities);
                await databaseContext.Database.Connection.InsertAsync(fileEntities);
                await databaseContext.Database.Connection.InsertAsync(imageEntities);
                await databaseContext.Database.Connection.InsertAsync(postEntities);
                await databaseContext.Database.Connection.InsertAsync(channelSubscriptions);
                await databaseContext.Database.Connection.InsertAsync(calculatedAccountBalances);
                await databaseContext.Database.Connection.InsertAsync(freeAccessUsers);
                await databaseContext.Database.Connection.InsertAsync(origins);
            }
        }

        private async Task CreateUserAsync(FifthweekDbContext databaseContext, UserId userId)
        {
            var user = UserTests.UniqueEntity(this.random);
            user.Id = userId.Value;
            user.Email = userId.Value + "@test.com";

            databaseContext.Users.Add(user);
            await databaseContext.SaveChangesAsync();
        }

        private static IEnumerable<NewsfeedPost> GetSortedNewsfeedPosts()
        {
            // Half the posts will be in the future relative to Now. Days move one day every two posts.
            var day = ChannelsPerCreator * CollectionsPerChannel * Posts / 2;

            var result = new List<NewsfeedPost>();
            for (var channelIndex = 0; channelIndex < ChannelsPerCreator; channelIndex++)
            {
                var channelId = ChannelIds[channelIndex];
                for (var collectionIndex = 0; collectionIndex < CollectionsPerChannel; collectionIndex++)
                {
                    var collectionId = CollectionIds[channelIndex][collectionIndex];
                    for (var i = 0; i < Posts * 2; i++)
                    {
                        DateTime liveDate;
                        DateTime creationDate;
                        if (i % 2 == 0)
                        {
                            // Ensure we have one post that is `now` (i.e. AddDays(0)).
                            liveDate = new SqlDateTime(Now.AddDays(day--)).Value;
                            creationDate = liveDate;
                        }
                        else
                        {
                            liveDate = new SqlDateTime(Now.AddDays(day)).Value;
                            creationDate = new SqlDateTime(liveDate.AddMinutes(-1)).Value;
                        }

                        result.Add(
                        new NewsfeedPost(
                            CreatorId,
                            new PostId(Guid.NewGuid()),
                            BlogId,
                            channelId,
                            collectionId,
                            i % 2 == 0 ? Comment : null,
                            i % 3 == 1 ? new FileId(Guid.NewGuid()) : null,
                            i % 3 == 2 ? new FileId(Guid.NewGuid()) : null,
                            liveDate,
                            i % 3 == 1 ? FileName : null,
                            i % 3 == 1 ? FileExtension : null,
                            i % 3 == 1 ? FileSize : (long?)null,
                            i % 3 == 2 ? FileName : null,
                            i % 3 == 2 ? FileExtension : null,
                            i % 3 == 2 ? FileSize : (long?)null,
                            i % 3 == 2 ? FileWidth : (int?)null,
                            i % 3 == 2 ? FileHeight : (int?)null,
                            creationDate));
                    }
                }
            }

            return result.OrderByDescending(_ => _.LiveDate).ThenByDescending(_ => _.CreationDate);
        }
    }
}