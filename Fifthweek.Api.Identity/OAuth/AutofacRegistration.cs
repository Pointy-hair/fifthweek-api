﻿namespace Fifthweek.Api.Identity.OAuth
{
    using Autofac;

    using Fifthweek.Api.Core;

    public class AutofacRegistration : IAutofacRegistration
    {
        public void Register(ContainerBuilder builder)
        {
            builder.RegisterType<RefreshTokenRepository>().As<IRefreshTokenRepository>().InstancePerRequest();
            builder.RegisterType<ClientRepository>().As<IClientRepository>().InstancePerRequest();

            builder.RegisterType<FifthweekAuthorizationServerProvider>().SingleInstance();
            builder.RegisterType<FifthweekAuthorizationServerHandler>().As<IFifthweekAuthorizationServerHandler>().InstancePerRequest();
            builder.RegisterType<FifthweekRefreshTokenProvider>().SingleInstance();
            builder.RegisterType<FifthweekRefreshTokenHandler>().As<IFifthweekRefreshTokenHandler>().InstancePerRequest();
        }
    }
}