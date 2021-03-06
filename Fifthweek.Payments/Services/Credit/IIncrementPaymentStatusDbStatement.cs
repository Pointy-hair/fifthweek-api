namespace Fifthweek.Payments.Services.Credit
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fifthweek.Api.Identity.Shared.Membership;

    public interface IIncrementPaymentStatusDbStatement
    {
        Task ExecuteAsync(IReadOnlyList<UserId> userIds);
    }
}