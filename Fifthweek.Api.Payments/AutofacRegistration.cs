﻿namespace Fifthweek.Api.Payments
{
    using Autofac;

    using Fifthweek.Api.Payments.Commands;
    using Fifthweek.Payments.Services.Credit;
    using Fifthweek.Payments.Services.Credit.Stripe;
    using Fifthweek.Payments.Services.Credit.Taxamo;
    using Fifthweek.Shared;

    public class AutofacRegistration : IAutofacRegistration
    {
        public void Register(ContainerBuilder builder)
        {
            builder.RegisterType<SetUserPaymentOriginDbStatement>().As<ISetUserPaymentOriginDbStatement>();
            builder.RegisterType<CommitTestUserCreditToDatabase>().As<ICommitTestUserCreditToDatabase>();
            builder.RegisterType<SetTestUserAccountBalanceDbStatement>().As<ISetTestUserAccountBalanceDbStatement>();
            builder.RegisterType<DeleteUserPaymentInformationDbStatement>().As<IDeleteUserPaymentInformationDbStatement>();
        }
    }
}