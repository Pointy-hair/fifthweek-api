﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Fifthweek.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Reflection;
    using System.Web.Http;

    using Autofac;
    using Autofac.Core;
    using Autofac.Integration.WebApi;

    using Fifthweek.Api.Core;
    using Fifthweek.Api.Logging;

    using Owin;

    public static class AutofacConfig
    {
        public static void Register(HttpConfiguration httpConfiguration, IAppBuilder app)
        {
            var container = CreateContainer();

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(httpConfiguration);

            var resolver = new ErrorLoggingWebApiDependencyResolver(new AutofacWebApiDependencyResolver(container), container);
            GlobalConfiguration.Configuration.DependencyResolver = httpConfiguration.DependencyResolver = resolver;
        }

        internal static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();

            RegisterControllerAssemblies(builder);
            RegisterHandlers(builder);
            RegisterModules(builder);

            builder.RegisterType<ExceptionHandler>().As<IExceptionHandler>().SingleInstance();
            builder.RegisterInstance(Constants.DefaultDeveloperRepository).As<IDeveloperRepository>().SingleInstance();
            builder.RegisterInstance(Constants.DefaultSendEmailService).As<ISendEmailService>().SingleInstance();
            builder.RegisterInstance(Constants.DefaultReportingService).As<IReportingService>().SingleInstance();

            builder.RegisterType<HttpClient>().InstancePerDependency();

            // Uncoment this to log Autofac requests to trace output.
            // builder.RegisterModule<LogRequestModule>();

            var container = builder.Build();
            return container;
        }

        private static void RegisterModules(ContainerBuilder builder)
        {
            var autofacRegistrationTypes = FifthweekAssembliesResolver.Assemblies
                .SelectMany(v => v.GetTypes())
                .Where(v => v.IsClass)
                .Where(v => typeof(IAutofacRegistration).IsAssignableFrom(v))
                .ToList();

            foreach (var t in autofacRegistrationTypes)
            {
                var instance = (IAutofacRegistration)Activator.CreateInstance(t);
                instance.Register(builder);
            }
        }

        private static void RegisterControllerAssemblies(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(FifthweekAssembliesResolver.Assemblies.ToArray());
        }

        private static void RegisterHandlers(
            ContainerBuilder builder)
        {
            var types = FifthweekAssembliesResolver.Assemblies.SelectMany(v => v.GetTypes()).ToList();

            var commandHandlers = (from t in types
                                   where t.IsClass
                                   from i in t.GetInterfaces()
                                   where i.IsClosedTypeOf(typeof(ICommandHandler<>))
                                   select new { Type = t, Interface = i, Decorators = GetDecoratorTypes(t) }).ToList();

            var queryHandlers = (from t in types
                                  where t.IsClass
                                  from i in t.GetInterfaces()
                                  where i.IsClosedTypeOf(typeof(IQueryHandler<,>))
                                 select new { Type = t, Interface = i, Decorators = GetDecoratorTypes(t) }).ToList();

            foreach (var item in commandHandlers.Concat(queryHandlers))
            {
                var decoratorTypes = GetDecoratorTypes(item.Type);

                if (decoratorTypes.Count == 0)
                {
                    builder.RegisterType(item.Type).As(item.Interface);
                }
                else
                {
                    builder.RegisterType(item.Type)
                        .As(new KeyedService(GetDecoratedTypeName(item.Type, decoratorTypes.Count), item.Interface));

                    var decoratedType = item.Interface.GetGenericTypeDefinition();
                    for (int i = decoratorTypes.Count - 1; i >= 0; i--)
                    {
                        var decorator = decoratorTypes[i];
                        builder.RegisterGenericDecorator(
                            decorator,
                            decoratedType,
                            GetDecoratedTypeName(item.Type, i + 1),
                            i == 0 ? null : GetDecoratedTypeName(item.Type, i));
                    }
                }
            }
        }

        private static List<Type> GetDecoratorTypes(Type item)
        {
            var result = new List<Type>();
            var decoratorAttribute = item.GetCustomAttribute<DecoratorAttribute>(false);
            if (decoratorAttribute != null)
            {
                result.AddRange(decoratorAttribute.DecoratorTypes);
            }

            return result;
        }

        private static string GetDecoratedTypeName(Type type, int level)
        {
            return type.FullName + "{" + level + "}";
        }
    }
}