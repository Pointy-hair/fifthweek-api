﻿namespace Fifthweek.Api.Subscriptions
{
    using Autofac;

    using Fifthweek.Api.Core;

    public class AutofacRegistration : IAutofacRegistration
    {
        public void Register(ContainerBuilder builder)
        {
            builder.RegisterType<SubscriptionOwnership>().As<ISubscriptionOwnership>();
            builder.RegisterType<SubscriptionSecurity>().As<ISubscriptionSecurity>();
            builder.RegisterType<ChannelOwnership>().As<IChannelOwnership>();
            builder.RegisterType<ChannelSecurity>().As<IChannelSecurity>();
        }
    }
}