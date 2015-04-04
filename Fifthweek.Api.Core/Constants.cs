﻿namespace Fifthweek.Api.Core
{
    using System;
    using System.Configuration;
    using System.Net.Mail;

    public class Constants
    {
        public const string DeveloperNameRequestHeaderKey = "developer-name";

        public const string DefaultAllowedOrigin = "*";

        public const string AllowedOriginHeaderKey = "access-control-allow-origin";

        public const string TokenAllowedOriginKey = "fifthweek:clientAllowedOrigin";

        public const string TokenRefreshTokenLifeTimeKey = "fifthweek:clientRefreshTokenLifeTime";

        public const string TokenClientIdKey = "fifthweek:client_id";

        public static readonly string FifthweekWebsiteOriginRegex = GetWebsiteOriginRegex();
        public static readonly string FifthweekWebsiteOriginDefault = GetWebsiteOriginDefault();
        public static readonly string FifthweekWebsiteBaseUrl = GetWebsiteBaseUrl();

        private static string GetWebsiteOriginDefault()
        {
            return ConfigurationManager.AppSettings["ACCESS_CONTROL_ALLOW_ORIGIN_DEFAULT"];
        }

        private static string GetWebsiteOriginRegex()
        {
            return ConfigurationManager.AppSettings["ACCESS_CONTROL_ALLOW_ORIGIN_REGEX"];
        }

        private static string GetWebsiteBaseUrl()
        {
            return ConfigurationManager.AppSettings["WEBSITE_BASE_URL"];
        }
    }
}