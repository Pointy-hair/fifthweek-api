﻿namespace Fifthweek.Api.Payments.Commands
{
    using System.Runtime.ExceptionServices;
    using System.Threading.Tasks;

    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Payments;
    using Fifthweek.Payments.Services.Credit;
    using Fifthweek.Shared;

    [AutoConstructor]
    [Decorator(OmitDefaultDecorators = true)]  // Turn off default retry policy so we don't repeatedly charge card if transient failure in Sql Azure.
    public partial class ApplyCreditRequestCommandHandler : ICommandHandler<ApplyCreditRequestCommand>
    {
        private readonly IRequesterSecurity requesterSecurity;
        private readonly IFifthweekRetryOnTransientErrorHandler retryOnTransientFailure;
        private readonly IApplyStandardUserCredit applyStandardUserCredit;
        private readonly ICommitTestUserCreditToDatabase commitTestUserCreditToDatabase;
        private readonly IFailPaymentStatusDbStatement failPaymentStatus;

        public async Task HandleAsync(ApplyCreditRequestCommand command)
        {
            command.AssertNotNull("command");
            await this.requesterSecurity.AuthenticateAsAsync(command.Requester, command.UserId);

            if (command.Amount.Value < TopUpUserAccountsWithCredit.MinimumPaymentAmount)
            {
                throw new BadRequestException("You cannot credit your account with less than the minimum payment.");
            }

            var userType = await this.requesterSecurity.GetUserTypeAsync(command.Requester);
            if (userType == UserType.TestUser)
            {
                // For a test user we just update their account balance directly, 
                // as we don't want the credit to affect the Fifthweek accounts
                // or VAT related accounts.
                await this.retryOnTransientFailure.HandleAsync(() =>
                    this.commitTestUserCreditToDatabase.HandleAsync(
                        command.UserId,
                        command.Amount));

                return;
            }

            ExceptionDispatchInfo exceptionDispatchInfo = null;
            try
            {
                await this.applyStandardUserCredit.ExecuteAsync(
                    command.UserId,
                    command.Amount,
                    command.ExpectedTotalAmount);
            }
            catch (StripeChargeFailedException t)
            {
                exceptionDispatchInfo = ExceptionDispatchInfo.Capture(t);
            }
    
            if (exceptionDispatchInfo != null)
            {
                await this.retryOnTransientFailure.HandleAsync(() => this.failPaymentStatus.ExecuteAsync(command.UserId));
                exceptionDispatchInfo.Throw();
            }
        }
    }
}