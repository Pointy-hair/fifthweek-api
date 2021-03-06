﻿namespace Fifthweek.Api.Identity.Membership
{
    using Autofac;

    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Shared;

    public class AutofacRegistration : IAutofacRegistration
    {
        public void Register(ContainerBuilder builder)
        {
            builder.RegisterType<RegisterUserDbStatement>().As<IRegisterUserDbStatement>();
            builder.RegisterType<RequesterSecurity>().As<IRequesterSecurity>();
            builder.RegisterType<RequesterContext>().As<IRequesterContext>().InstancePerRequest();
            builder.RegisterType<GetAccountSettingsDbStatement>().As<IGetAccountSettingsDbStatement>();
            builder.RegisterType<UpdateAccountSettingsDbStatement>().As<IUpdateAccountSettingsDbStatement>();
            builder.RegisterType<ReservedUsernameService>().As<IReservedUsernameService>();

            builder.RegisterType<GetUserRolesDbStatement>().As<IGetUserRolesDbStatement>();
            builder.RegisterType<ImpersonateIfRequired>().As<IImpersonateIfRequired>();
            builder.RegisterType<GetFeedbackUserDataDbStatement>().As<IGetFeedbackUserDataDbStatement>();
        }
    }
}