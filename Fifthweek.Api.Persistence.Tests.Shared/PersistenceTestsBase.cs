﻿using System.Threading.Tasks;

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

        protected Task SnapshotDatabaseAsync()
        {
            return this.databaseState.TakeSnapshotAsync();
        }

        protected Task AssertDatabaseAsync(ExpectedSideEffects sideEffects)
        {
            return this.databaseState.AssertSideEffectsAsync(sideEffects);
        }
    }
}