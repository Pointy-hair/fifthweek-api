﻿namespace Fifthweek.Api.Collections.Shared
{
    using System;

    using Fifthweek.CodeGeneration;

    [AutoPrimitive]
    public partial class CollectionId
    {
        public Guid Value { get; private set; }
    }
}