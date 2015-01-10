﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fifthweek.Api.Persistence.Tests.Shared
{
    public abstract class PersistenceTestsBase
    {
        private TemporaryDatabase temporaryDatabase;
        private DatabaseState databaseState;

        public virtual void Initialize()
        {
            this.temporaryDatabase = TemporaryDatabase.CreateNew();
            this.databaseState = new DatabaseState(temporaryDatabase);
        }

        public virtual void Cleanup()
        {
            this.temporaryDatabase.Dispose();
        }

        protected IFifthweekDbContext NewDbContext()
        {
            return this.temporaryDatabase.NewDbContext();
        }

        protected Task TakeSnapshotAsync()
        {
            return this.databaseState.TakeSnapshotAsync();
        }

        protected Task AssertNoSideEffectsAsync()
        {
            return this.databaseState.AssertNoSideEffectsAsync();
        }

        protected Task AssertNoUnexpectedSideEffectsAsync(
            IReadOnlyList<object> expectedInserts,
            IReadOnlyList<object> expectedUpdates,
            IReadOnlyList<object> expectedDeletions)
        {
            return this.databaseState.AssertNoUnexpectedSideEffectsAsync(expectedInserts, expectedUpdates, expectedDeletions);
        }
    }
}