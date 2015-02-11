﻿namespace Fifthweek.Api.Persistence.Tests.Shared
{
    using System;
    using System.Data.Common;
    using System.Threading.Tasks;
    using System.Transactions;

    using Fifthweek.CodeGeneration;

    public abstract partial class PersistenceTestsBase
    {
        protected async Task DatabaseTestAsync(Func<TestDatabaseContext, Task<ExpectedSideEffects>> databaseTest)
        {
            var database = await TestDatabase.CreateNewAsync();
            var databaseSnapshot = new TestDatabaseSnapshot(database);
            var databaseContext = new TestDatabaseContext(database, databaseSnapshot);
            
            using (new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var sideEffects = await databaseTest(databaseContext);
                await databaseSnapshot.AssertSideEffectsAsync(sideEffects);
            }
        }

        [AutoConstructor]
        public partial class TestDatabaseContext : IFifthweekDbConnectionFactory
        {
            private readonly TestDatabase testDatabase;
            private readonly TestDatabaseSnapshot testDatabaseSnapshot;

            public Task TakeSnapshotAsync()
            {
                return this.testDatabaseSnapshot.InitializeAsync();
            }

            public DbConnection CreateConnection()
            {
                return this.testDatabase.CreateConnection();
            }

            public FifthweekDbContext CreateContext()
            {
                return this.testDatabase.CreateContext();
            }
        }
    }
}