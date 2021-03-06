﻿namespace Fifthweek.Api.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http.Dependencies;

    using Fifthweek.Shared;

    public static class Extensions
    {
        public static TResult GetService<TResult>(this IDependencyResolver resolver)
        {
            return (TResult)resolver.GetService(typeof(TResult));
        }

        public static void AssertBodyProvided(this object value, string argumentName)
        {
            if (value == null)
            {
                throw new BadRequestException("The value '" + argumentName + "' must be provided in the request body.");
            }
        }

        public static void AssertUrlParameterProvided(this object value, string argumentName)
        {
            if (value == null)
            {
                throw new BadRequestException("The value '" + argumentName + "' must be provided in the request URL.");
            }
        }

        public static void AssertUrlParameterProvided(this string value, string argumentName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new BadRequestException("The value '" + argumentName + "' must be provided in the request URL.");
            }
        }
    }
}