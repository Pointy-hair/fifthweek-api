﻿namespace Fifthweek.Api.Collections
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fifthweek.Api.Persistence;

    /// <remarks>
    /// Entities are sorted ascending by: DayOfWeek, TimeOfDay.
    /// </remarks>
    public interface IGetCollectionWeeklyReleaseTimesDbStatement
    {
        Task<IReadOnlyList<WeeklyReleaseTime>> ExecuteAsync(CollectionId collectionId);
    }
}