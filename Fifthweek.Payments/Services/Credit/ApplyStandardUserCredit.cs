namespace Fifthweek.Payments.Services.Credit
{
    using System;
    using System.Runtime.ExceptionServices;
    using System.Threading.Tasks;

    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Payments.Services.Credit.Taxamo;
    using Fifthweek.Payments.Stripe;
    using Fifthweek.Shared;

    using Newtonsoft.Json;

    [AutoConstructor]
    public partial class ApplyStandardUserCredit : IApplyStandardUserCredit
    {
        private readonly IInitializeCreditRequest initializeCreditRequest;
        private readonly IPerformCreditRequest performCreditRequest;
        private readonly ICommitCreditToDatabase commitCreditToDatabase;
        private readonly IFifthweekRetryOnTransientErrorHandler retryOnTransientFailure;
        private readonly ICommitTaxamoTransaction commitTaxamoTransaction;

        public async Task ExecuteAsync(UserId userId, PositiveInt amount, PositiveInt expectedTotalAmount)
        {
            userId.AssertNotNull("userId");
            amount.AssertNotNull("amount");

            // We split this up into three phases that have individual retry handlers.
            // The first phase can be retried without issue if there are transient failures.
            var initializeResult = await this.retryOnTransientFailure.HandleAsync(
                () => this.initializeCreditRequest.HandleAsync(userId, amount, expectedTotalAmount));

            // This phase could be put at the end of the first phase, but it runs the risk of someone inserting
            // a statement afterwards that causes a transient failure, so for safety it has been isolated.
            var stripeTransactionResult = await this.retryOnTransientFailure.HandleAsync(
                () => this.performCreditRequest.HandleAsync(
                    userId,
                    initializeResult.TaxamoTransaction,
                    initializeResult.Origin,
                    UserType.StandardUser));

            try
            {
                // Finally we commit to the local database...
                var commitToDatabaseTask = this.retryOnTransientFailure.HandleAsync(
                    () => this.commitCreditToDatabase.HandleAsync(
                        userId,
                        initializeResult.TaxamoTransaction,
                        initializeResult.Origin,
                        stripeTransactionResult));

                // ... and commit taxamo transaction.
                var commitToTaxamoTask = this.retryOnTransientFailure.HandleAsync(
                    () => this.commitTaxamoTransaction.ExecuteAsync(initializeResult.TaxamoTransaction.Key));

                // We run the two committing tasks in parallel as even if one fails we would like the other to try and succeed.
                await Task.WhenAll(commitToDatabaseTask, commitToTaxamoTask);
            }
            catch (Exception t)
            {
                var json = JsonConvert.SerializeObject(
                    new
                    {
                        UserId = userId,
                        InitializeResult = initializeResult,
                        StripeTransactionResult = stripeTransactionResult,
                    });

                throw new FailedToApplyCreditException(json, t);
            }
        }
    }
}