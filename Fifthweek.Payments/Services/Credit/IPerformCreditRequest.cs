namespace Fifthweek.Payments.Services.Credit
{
    using System.Threading.Tasks;

    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Payments.Services.Credit.Taxamo;

    public interface IPerformCreditRequest
    {
        Task<StripeTransactionResult> HandleAsync(
            UserId userId,
            TaxamoTransactionResult taxamoTransaction,
            UserPaymentOriginResult origin);
    }
}