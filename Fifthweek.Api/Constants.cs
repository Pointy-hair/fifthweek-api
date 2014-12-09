﻿namespace Fifthweek.Api
{
    using System.Net.Mail;

    using Fifthweek.Api.Services;

    public static class Constants
    {
        public const string AdministratorUsers = "Admin";

        public const string DefaultAllowedOrigin = "*";
        
        public const string AllowedOriginHeaderKey = "Access-Control-Allow-Origin";

        public const string TokenAllowedOriginKey = "fifthweek:clientAllowedOrigin";

        public const string TokenRefreshTokenLifeTimeKey = "fifthweek:clientRefreshTokenLifeTime";

        public const string TokenClientIdKey = "fifthweek:client_id";

        public const string ErrorEmailAddress = "services@fifthweek.com";

        public static readonly string FifthweekWebsiteOrigin = GetWebsiteOrigin();

        public static readonly MailAddress FifthweekEmailAddress = new MailAddress("hello@fifthweek.com", "Fifthweek");

        // This is used for reporting errors, as we can't rely on AutoFac being in a good state.
        public static readonly ISendEmailService DefaultSendEmailService = new SendGridEmailService();

        // This is used for reporting errors, as we can't rely on AutoFac being in a good state.
        public static readonly IReportingService DefaultReportingService = System.Diagnostics.Debugger.IsAttached 
            ? (IReportingService)new TraceReportingService()
            : (IReportingService)new AggregateReportingService(new TraceReportingService(), new EmailReportingService(DefaultSendEmailService));

        private static string GetWebsiteOrigin()
        {
            return System.Configuration.ConfigurationManager.AppSettings["ACCESS_CONTROL_ALLOW_ORIGIN"];
        }
    }
}