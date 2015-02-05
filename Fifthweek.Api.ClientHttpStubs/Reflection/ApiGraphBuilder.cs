﻿namespace Fifthweek.Api.ClientHttpStubs.Reflection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Web.Http;

    public class ApiGraphBuilder
    {
        private const string ControllerSuffix = "Controller";

        public ApiGraph Build(IEnumerable<Type> controllerTypes)
        {
            var controllers = new List<ControllerElement>();
            foreach (var controllerType in controllerTypes)
            {
                var methods = new List<MethodElement>();
                var methodInfos = controllerType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                foreach (var methodInfo in methodInfos)
                {
                    ParameterElement bodyParameter = null;
                    var urlParameters = new List<ParameterElement>();
                    var fullRoute = GetFullRoute(controllerType, methodInfo);
                    var methodName = methodInfo.Name.EndsWith("Async")
                        ? methodInfo.Name.Substring(0, methodInfo.Name.Length - 5)
                        : methodInfo.Name;

                    foreach (var parameter in methodInfo.GetParameters())
                    {
                        var parameterToken = "{" + parameter.Name + "}";
                        var parameterElement = new ParameterElement(parameter.Name);

                        if (parameter.GetCustomAttribute<FromUriAttribute>() != null || fullRoute.Contains(parameterToken))
                        {
                            urlParameters.Add(parameterElement);
                        }
                        else if (bodyParameter == null)
                        {
                            bodyParameter = parameterElement;
                        }
                        else
                        {
                            throw new Exception("Multiple body parameters detected.");
                        }
                    }

                    methods.Add(new MethodElement(
                        GetHttpMethod(methodInfo),
                        methodName,
                        fullRoute,
                        urlParameters,
                        bodyParameter));
                }

                var controllerName = controllerType.Name.Substring(0, controllerType.Name.Length - ControllerSuffix.Length);
                controllers.Add(new ControllerElement(controllerName, methods));
            }

            return new ApiGraph(controllers);
        }

        private static HttpMethod GetHttpMethod(MethodInfo methodInfo)
        {
            if (methodInfo.GetCustomAttribute<HttpGetAttribute>() != null)
            {
                return HttpMethod.Get;
            }

            if (methodInfo.GetCustomAttribute<HttpPostAttribute>() != null)
            {
                return HttpMethod.Post;
            }

            if (methodInfo.GetCustomAttribute<HttpDeleteAttribute>() != null)
            {
                return HttpMethod.Delete;
            }

            if (methodInfo.GetCustomAttribute<HttpPutAttribute>() != null)
            {
                return HttpMethod.Put;
            }

            var name = methodInfo.Name.ToLower();
            
            if (name.StartsWith("get"))
            {
                return HttpMethod.Get;
            }

            if (name.StartsWith("post"))
            {
                return HttpMethod.Post;
            }

            if (name.StartsWith("delete"))
            {
                return HttpMethod.Delete;
            }

            if (name.StartsWith("put"))
            {
                return HttpMethod.Put;
            }

            return HttpMethod.Get;
        }

        private static string GetFullRoute(Type controllerType, MethodInfo methodInfo)
        {
            var routePrefix = controllerType.GetCustomAttribute<RoutePrefixAttribute>();
            var routes = methodInfo.GetCustomAttributes<RouteAttribute>().ToArray();

            if (routes.Length > 1)
            {
                throw new Exception("Multiple routes not supported. Please use separate methods.");
            }

            if (routes.Length == 1 && routePrefix != null)
            {
                return routePrefix.Prefix + "/" + routes[0].Template;
            }

            if (routes.Length == 1)
            {
                return routes[0].Template;
            }

            if (routePrefix != null)
            {
                return routePrefix.Prefix;
            }

            throw new Exception("No route information found.");
        }
    }
}