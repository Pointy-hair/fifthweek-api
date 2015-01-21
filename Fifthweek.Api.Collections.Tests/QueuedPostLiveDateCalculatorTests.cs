﻿namespace Fifthweek.Api.Collections.Tests
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class QueuedPostLiveDateCalculatorTests
    {
        public static readonly DateTime TuesdayNight = new DateTime(2015, 1, 20, 18, 36, 12, DateTimeKind.Utc);
        public static readonly HourOfWeek Monday = new HourOfWeek(24);
        public static readonly HourOfWeek Tuesday = new HourOfWeek(48);
        public static readonly HourOfWeek Wednesday = new HourOfWeek(72);
        public static readonly HourOfWeek Thursday = new HourOfWeek(96);
        public static readonly IReadOnlyList<HourOfWeek> ReleaseSchedule = new[]
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday
        };

        public QueuedPostLiveDateCalculator target;

        [TestInitialize]
        public void Initialize()
        {
            this.target = new QueuedPostLiveDateCalculator();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ItShouldRequireUtcStartTime()
        {
            this.target.GetNextLiveDates(DateTime.Now, ReleaseSchedule, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ItShouldRequireNonEmptyReleaseTimes()
        {
            this.target.GetNextLiveDates(TuesdayNight, new HourOfWeek[0], 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ItShouldRequireAscendingReleaseTimes()
        {
            var nonAscendingReleaseSchedule = new[]
            {
                Tuesday,
                Monday,
                Wednesday,
                Thursday
            };

            this.target.GetNextLiveDates(TuesdayNight, nonAscendingReleaseSchedule, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ItShouldRequireAscendingReleaseTimes2()
        {
            var nonAscendingReleaseSchedule = new[]
            {
                Monday,
                Tuesday,
                Thursday,
                Wednesday
            };

            this.target.GetNextLiveDates(TuesdayNight, nonAscendingReleaseSchedule, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ItShouldRequireDistinctReleaseTimes()
        {
            var indistinctReleaseSchedule = new[]
            {
                Monday,
                Monday,
                Tuesday,
                Wednesday,
                Thursday
            };

            this.target.GetNextLiveDates(TuesdayNight, indistinctReleaseSchedule, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ItShouldRequireDistinctReleaseTimes2()
        {
            var indistinctReleaseSchedule = new[]
            {
                Monday,
                Tuesday,
                Wednesday,
                Thursday,
                Thursday
            };

            this.target.GetNextLiveDates(TuesdayNight, indistinctReleaseSchedule, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ItShouldRequireNonNegativeCount()
        {
            this.target.GetNextLiveDates(TuesdayNight, ReleaseSchedule, -1);
        }

        [TestMethod]
        public void ItShouldAllowZeroCount()
        {
            this.target.GetNextLiveDates(TuesdayNight, ReleaseSchedule, 0);
        }

        [TestMethod]
        public void ItShouldReturnListWithSameSizeAsCount()
        {
            Assert.AreEqual(0, this.target.GetNextLiveDates(TuesdayNight, ReleaseSchedule, 0).Count);
            Assert.AreEqual(1, this.target.GetNextLiveDates(TuesdayNight, ReleaseSchedule, 1).Count);
            Assert.AreEqual(10, this.target.GetNextLiveDates(TuesdayNight, ReleaseSchedule, 10).Count);
        }

        [TestMethod]
        public void ItShouldReturnDatesInUtc()
        {
            foreach (var result in this.target.GetNextLiveDates(TuesdayNight, ReleaseSchedule, 10))
            {
                Assert.AreEqual(result.Kind, DateTimeKind.Utc);    
            }
        }
    }
}