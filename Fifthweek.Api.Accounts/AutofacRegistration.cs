﻿namespace Fifthweek.Api.Accounts
{
    using Autofac;

    using Fifthweek.Api.Core;
    using Fifthweek.Shared;

    public class AutofacRegistration : IAutofacRegistration
    {
        public void Register(ContainerBuilder builder)
        {
            builder.RegisterType<GetAccountSettingsDbStatement>().As<IGetAccountSettingsDbStatement>();
            builder.RegisterType<UpdateAccountSettingsDbStatement>().As<IUpdateAccountSettingsDbStatement>();
        }
    }
}