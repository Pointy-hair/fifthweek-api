﻿namespace Fifthweek.Api.Collections
{
    using Autofac;

    using Fifthweek.Api.Collections.Shared;
    using Fifthweek.Shared;

    public class AutofacRegistration : IAutofacRegistration
    {
        public void Register(ContainerBuilder builder)
        {
            builder.RegisterType<CollectionOwnership>().As<ICollectionOwnership>();
            builder.RegisterType<CollectionSecurity>().As<ICollectionSecurity>();
            builder.RegisterType<GetNewQueuedPostLiveDateLowerBoundDbStatement>().As<IGetNewQueuedPostLiveDateLowerBoundDbStatement>();
            builder.RegisterType<GetCollectionWeeklyReleaseTimesDbStatement>().As<IGetCollectionWeeklyReleaseTimesDbStatement>();
            builder.RegisterType<QueuedPostLiveDateCalculator>().As<IQueuedPostLiveDateCalculator>();
            builder.RegisterType<GetChannelsAndCollectionsDbStatement>().As<IGetChannelsAndCollectionsDbStatement>();
            builder.RegisterType<DeleteCollectionDbStatement>().As<IDeleteCollectionDbStatement>();
        }
    }
}