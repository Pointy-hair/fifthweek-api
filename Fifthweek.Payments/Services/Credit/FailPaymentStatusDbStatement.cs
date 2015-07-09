namespace Fifthweek.Payments.Services.Credit
{
    using System.Threading.Tasks;

    using Dapper;

    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Api.Persistence.Payments;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Shared;

    [AutoConstructor]
    public partial class FailPaymentStatusDbStatement : IFailPaymentStatusDbStatement
    {
        private readonly IFifthweekDbConnectionFactory connectionFactory;

        public async Task ExecuteAsync(UserId userId)
        {
            userId.AssertNotNull("userId");

            using (var connection = this.connectionFactory.CreateConnection())
            {
                await connection.UpsertAsync(
                    new UserPaymentOrigin
                    {
                        UserId = userId.Value,
                        PaymentStatus = PaymentStatus.Failed,
                    },
                    UserPaymentOrigin.Fields.PaymentStatus);
            }
        }
    }
}