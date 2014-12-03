﻿namespace Fifthweek.Api
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;

    public static class RequestExceptionHandler
    {
        public static async Task<HttpResponseMessage> ReportExceptionAndCreateResponseAsync(
            HttpRequestMessage request,
            Exception exception)
        {
            // I don't want to use Autofac here as it may be the dependency resolution
            // causing the error.
            var reportingService = Constants.DefaultReportingService;
            var identifier = exception.GetExceptionIdentifier();
            try
            {
                await reportingService.ReportErrorAsync(exception, identifier);
            }
            catch (Exception t)
            {
                System.Diagnostics.Trace.WriteLine("Failed to report errors: " + t);

                return request.CreateErrorResponse(
                        HttpStatusCode.InternalServerError,
                        "An error occured and could not be reported: " + identifier);
            }

            if (exception is ModelValidationException || exception is BadRequestException)
            {
                // A bad request means there was a problem with the input, so we need
                // to tell them what the error was.
                // However we still report the issue above as the problem should have been picked up on
                // the client before sending the request, and so we need to fix it.
                return request.CreateErrorResponse(
                    HttpStatusCode.BadRequest,
                    exception.Message);
            }
            else
            {
                // For anything else we want to hide the error details.
                return request.CreateErrorResponse(
                        HttpStatusCode.InternalServerError,
                        "Something went wrong: " + identifier);
            }
        }
    }
}