﻿namespace Fifthweek.Api.Collections
{
    using System;
    using System.Threading.Tasks;

    using Fifthweek.Api.Collections.Shared;
    using Fifthweek.Api.Core;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Shared;

    [AutoConstructor]
    public partial class GetLiveDateOfNewQueuedPostDbStatement : IGetLiveDateOfNewQueuedPostDbStatement
    {
        private readonly IGetNewQueuedPostLiveDateLowerBoundDbStatement getNewQueuedPostLiveDateLowerBound;
        private readonly IGetWeeklyReleaseScheduleDbStatement getWeeklyReleaseSchedule;
        private readonly IQueuedPostLiveDateCalculator queuedPostLiveDateCalculator;

        public async Task<DateTime> ExecuteAsync(QueueId queueId)
        {
            queueId.AssertNotNull("queueId");

            var exclusiveLowerBound = await this.getNewQueuedPostLiveDateLowerBound.ExecuteAsync(queueId, DateTime.UtcNow);
            var weeklyReleaseSchedule = await this.getWeeklyReleaseSchedule.ExecuteAsync(queueId);

            return this.queuedPostLiveDateCalculator.GetNextLiveDate(
                exclusiveLowerBound,
                weeklyReleaseSchedule);
        }
    }
}