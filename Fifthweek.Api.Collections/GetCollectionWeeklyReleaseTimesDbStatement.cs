﻿namespace Fifthweek.Api.Collections
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Dapper;

    using Fifthweek.Api.Core;
    using Fifthweek.Api.Persistence;
    using Fifthweek.CodeGeneration;

    [AutoConstructor]
    public partial class GetCollectionWeeklyReleaseTimesDbStatement : IGetCollectionWeeklyReleaseTimesDbStatement
    {
        private static readonly string Sql = string.Format(
            @"SELECT * 
            FROM    {0} 
            WHERE   {1}=@CollectionId",
            WeeklyReleaseTime.Table,
            WeeklyReleaseTime.Fields.CollectionId);
        
        private readonly IFifthweekDbContext databaseContext;

        public async Task<IReadOnlyList<WeeklyReleaseTime>> ExecuteAsync(CollectionId collectionId)
        {
            collectionId.AssertNotNull("collectionId");

            var parameters = new
            {
                CollectionId = collectionId.Value
            };

            var releaseTimes = await this.databaseContext.Database.Connection.QueryAsync<WeeklyReleaseTime>(Sql, parameters);

            // We sort in memory. It's only a small collection of items, so seems like an unnecessary potential strain to put on DB.
            var ascendingReleaseTimes = releaseTimes.OrderBy(_ => _.DayOfWeek).ThenBy(_ => _.TimeOfDay).ToList();

            return ascendingReleaseTimes;
        }
    }
}