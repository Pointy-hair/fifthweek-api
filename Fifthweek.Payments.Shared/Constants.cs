﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifthweek.Payments.Shared
{
    public class Constants
    {
        public const string RequestSnapshotQueueName = "snapshot-requests";
        public const string RequestProcessPaymentsQueueName = "process-payments-requests";
        public const string ProcessPaymentsLeaseObjectName = "process-payments-lease-object";
    }
}
