﻿namespace Fifthweek.Api.Collections
{
    using System;
    using System.Threading.Tasks;

    using Fifthweek.Api.Collections.Shared;
    using Fifthweek.Api.Core;
    using Fifthweek.CodeGeneration;

    [AutoConstructor]
    public partial class DefragmentQueueDbStatement : IDefragmentQueueDbStatement
    {
        private readonly IGetQueueSizeDbStatement getQueueSize;
        private readonly IQueuedPostLiveDateCalculator liveDateCalculator;
        private readonly IUpdateAllLiveDatesInQueueDbStatement updateAllLiveDatesInQueue;

        public async Task ExecuteAsync(CollectionId collectionId, WeeklyReleaseSchedule weeklyReleaseSchedule, DateTime now)
        {
            collectionId.AssertNotNull("collectionId");
            weeklyReleaseSchedule.AssertNotNull("weeklyReleaseSchedule");
            now.AssertUtc("now");

            var queueSize = await this.getQueueSize.ExecuteAsync(collectionId, now);

            if (queueSize == 0)
            {
                return;
            }
            
            var unfragmentedLiveDates = this.liveDateCalculator.GetNextLiveDates(now, weeklyReleaseSchedule, queueSize);
            
            await this.updateAllLiveDatesInQueue.ExecuteAsync(collectionId, unfragmentedLiveDates, now);
        }
    }
}