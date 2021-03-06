﻿namespace Fifthweek.Api.Logging.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Web.Http;

    using Fifthweek.Api.Core;
    using Fifthweek.Shared;

    [RoutePrefix("log")]
    public class LogController : ApiController
    {
        private readonly IExceptionHandler exceptionHandler;

        private readonly ITraceService traceService;

        public LogController(IExceptionHandler exceptionHandler, ITraceService traceService)
        {
            this.exceptionHandler = exceptionHandler;
            this.traceService = traceService;
        }

        // POST: log
        [AllowAnonymous]
        public void Post(BrowserLogMessage logMessage)
        {
            try
            {
                string message = null;
                if (logMessage != null && logMessage.Payload != null)
                {
                    message = logMessage.Payload.ToString();
                }

                if (message == null)
                {
                    return;
                }

                TraceLevel level;
                switch (logMessage.Level.ToLower())
                {
                    case "verbose":
                    case "debug":
                        level = TraceLevel.Verbose;
                        break;

                    case "info":
                    case "information":
                        level = TraceLevel.Info;
                        break;

                    case "warn":
                    case "warning":
                        level = TraceLevel.Warning;
                        break;

                    default:
                        level = TraceLevel.Error;
                        break;
                }

                this.traceService.Log(level, "External log:");

                if (level == TraceLevel.Error)
                {
                    this.exceptionHandler.ReportExceptionAsync(new ExternalErrorException(logMessage.Payload.ToString()));
                }
                else
                {
                    this.traceService.Log(level, logMessage.Payload.ToString());
                }
            }
            catch (Exception t)
            {
                this.exceptionHandler.ReportExceptionAsync(t);
            }
        }
    }
}