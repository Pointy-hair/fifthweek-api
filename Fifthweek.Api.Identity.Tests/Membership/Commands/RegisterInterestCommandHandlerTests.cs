﻿namespace Fifthweek.Api.Identity.Tests.Membership.Commands
{
    using System;
    using System.Threading.Tasks;

    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Membership.Commands;
    using Fifthweek.Api.Identity.Shared.Membership;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class RegisterInterestCommandHandlerTests
    {
        private static readonly string Name = "name";
        private static readonly ValidEmail ValidEmail = ValidEmail.Parse("name@test.com");
        private static readonly string Activity = "Registered Interest: name, name@test.com";

        private Mock<IFifthweekActivityReporter> activityReporter;
        private Mock<IExceptionHandler> exceptionHandler;

        private RegisterInterestCommandHandler target;

        [TestInitialize]
        public void Initialize()
        {
            this.activityReporter = new Mock<IFifthweekActivityReporter>(MockBehavior.Strict);
            this.exceptionHandler = new Mock<IExceptionHandler>(MockBehavior.Strict);

            this.target = new RegisterInterestCommandHandler(this.activityReporter.Object, this.exceptionHandler.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task WhenCommandIsNull_ItShouldThrowAnException()
        {
            await this.target.HandleAsync(null);
        }

        [TestMethod]
        public async Task WhenEmailIsFromTestDomain_ItShouldNotReport()
        {
            await this.target.HandleAsync(new RegisterInterestCommand(Name, ValidEmail.Parse("something" + Constants.TestEmailDomain)));
            // Test verification handled by strict behaviour.
        }

        [TestMethod]
        public async Task WhenReportingSucceeds_ItShouldCompleteSuccessfully()
        {
            this.activityReporter.Setup(v => v.ReportActivityAsync(Activity))
                .Returns(Task.FromResult(0))
                .Verifiable();

            await this.target.HandleAsync(new RegisterInterestCommand(Name, ValidEmail));

            this.activityReporter.Verify();
        }

        [TestMethod]
        public async Task WhenReportingFails_ItShouldLogErrorAndCompleteSuccessfully()
        {
            this.activityReporter.Setup(v => v.ReportActivityAsync(Activity))
                .Throws(new DivideByZeroException());

            this.exceptionHandler.Setup(v => v.ReportExceptionAsync(It.IsAny<Exception>())).Verifiable();

            await this.target.HandleAsync(new RegisterInterestCommand(Name, ValidEmail));

            this.exceptionHandler.Verify();
        }
    }
}