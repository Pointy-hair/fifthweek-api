﻿namespace Fifthweek.Api.Persistence.Tests.Shared
{
    using System;

    using Fifthweek.Api.Persistence;

    public static class FileTests
    {
        public static File UniqueEntity(Random random)
        {
            return new File(
                Guid.NewGuid(),
                null,
                default(Guid),
                (FileState)random.Next(0, 3),
                DateTime.UtcNow.AddDays(random.NextDouble() * -100),
                DateTime.UtcNow.AddDays(random.NextDouble() * -100),
                DateTime.UtcNow.AddDays(random.NextDouble() * -100),
                DateTime.UtcNow.AddDays(random.NextDouble() * -100),
                "File Name " + random.Next(),
                "File Extension " + random.Next(),
                random.Next(),
                "Purpose " + random.Next());
        }
    }
}