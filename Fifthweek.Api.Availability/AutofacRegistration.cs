﻿namespace Fifthweek.Api.Availability
{
    using Autofac;

    using Fifthweek.Shared;

    public class AutofacRegistration : IAutofacRegistration
    {
        public void Register(ContainerBuilder builder)
        {
            builder.RegisterType<CountUsersDbStatement>().As<ICountUsersDbStatement>();
            builder.RegisterType<TestSqlAzureAvailabilityStatement>().As<ITestSqlAzureAvailabilityStatement>();
            builder.RegisterType<TestPaymentsAvailabilityStatement>().As<ITestPaymentsAvailabilityStatement>();
            
            // Single instance so we can track when we last prodded payments accross requests.
            builder.RegisterType<LastPaymentsRestartTimeContainer>().As<ILastPaymentsRestartTimeContainer>().SingleInstance();
        }
    }
}