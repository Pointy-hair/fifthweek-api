namespace Fifthweek.Payments.Pipeline
{
    using System;
    using System.Collections.Generic;

    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Payments.Snapshots;

    public interface IMergeSnapshotsExecutor
    {
        IReadOnlyList<MergedSnapshot> Execute(
            UserId subscriberId,
            UserId creatorId,
            DateTime startTimeInclusive,
            IReadOnlyList<ISnapshot> snapshots);
    }
}