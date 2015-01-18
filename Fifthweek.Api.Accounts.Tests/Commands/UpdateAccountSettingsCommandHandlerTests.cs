﻿namespace Fifthweek.Api.Accounts.Tests.Commands
{
    using System;
    using System.Threading.Tasks;

    using Fifthweek.Api.Accounts.Commands;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.FileManagement;
    using Fifthweek.Api.Identity.Membership;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class UpdateAccountSettingsCommandHandlerTests
    {
        private static readonly UserId UserId = new UserId(Guid.NewGuid());
        private static readonly Requester Requester = Requester.Authenticated(UserId);
        private static readonly FileId FileId = new FileId(Guid.NewGuid());
        private static readonly ValidUsername Username = ValidUsername.Parse("username");
        private static readonly ValidEmail Email = ValidEmail.Parse("test@testing.fifthweek.com");
        private static readonly ValidPassword Password = ValidPassword.Parse("passw0rd");

        private Mock<IAccountRepository> accountRepository;
        private Mock<IFileSecurity> fileSecurity;
        private UpdateAccountSettingsCommandHandler target;

        [TestInitialize]
        public void TestInitialize()
        {
            this.accountRepository = new Mock<IAccountRepository>();
            this.fileSecurity = new Mock<IFileSecurity>();

            this.target = new UpdateAccountSettingsCommandHandler(this.accountRepository.Object, this.fileSecurity.Object);
        }

        [TestMethod]
        public async Task WhenCalledWithValidData_ItShouldCallTheAccountRepository()
        {
            var command = new UpdateAccountSettingsCommand(
                Requester,
                UserId,
                Username,
                Email,
                Password,
                FileId);

            this.fileSecurity.Setup(v => v.AssertUsageAllowedAsync(UserId, FileId))
                .Returns(Task.FromResult(0));

            this.accountRepository.Setup(
                v =>
                v.UpdateAccountSettingsAsync(
                    UserId,
                    Username,
                    Email,
                    Password,
                    FileId)).ReturnsAsync(new AccountRepository.UpdateAccountSettingsResult(false))
                    .Verifiable();

            await this.target.HandleAsync(command);

            this.accountRepository.Verify();
        }

        [TestMethod]
        [ExpectedException(typeof(UnauthorizedException))]
        public async Task WhenCalledWithUnauthorizedFileId_ItShouldCallThrowAnUnauthroizedException()
        {
            var command = new UpdateAccountSettingsCommand(
                Requester,
                UserId,
                Username,
                Email,
                Password,
                FileId);

            this.fileSecurity.Setup(v => v.AssertUsageAllowedAsync(UserId, FileId))
                .Throws(new UnauthorizedException());

            await this.target.HandleAsync(command);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task WhenCalledWithoutACommand_ItShouldThrowAnException()
        {
            await this.target.HandleAsync(null);
        }
    }
}
