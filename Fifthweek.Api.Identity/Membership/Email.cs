﻿using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace Fifthweek.Api.Identity.Membership
{
    [AutoEqualityMembers]
    public partial class Email
    {
        protected Email()
        {
        }

        public string Value { get; protected set; }

        public static Email Parse(string value)
        {
            Email retval;
            if (!TryParse(value, out retval))
            {
                throw new ArgumentException("Invalid email address", "value");
            }

            return retval;
        }

        public static bool TryParse(string value, out Email email)
        {
            IReadOnlyCollection<string> errorMessages;
            return TryParse(value, out email, out errorMessages);
        }

        public static bool TryParse(string value, out Email email, out IReadOnlyCollection<string> errorMessages)
        {
            var errorMessageList = new List<string>();
            errorMessages = errorMessageList;

            if (value == null)
            {
                // Method should never fail, so report null as an error instead of ArgumentNullException.
                errorMessageList.Add("Value required");
            }
            else
            {
                try
                {
                    if (new MailAddress(value).Address != value.Trim())
                    {
                        errorMessageList.Add("Invalid format");
                    }
                }
                catch
                {
                    errorMessageList.Add("Invalid format");
                }

                if (value.Contains("\""))
                {
                    // Quoted names are valid, but to keep things sane we're not accepting them.
                    errorMessageList.Add("Must not contain quotes");
                }
            }

            if (errorMessageList.Count > 0)
            {
                email = null;
                return false;
            }

            email = new Email
            {
                Value = value
            };

            return true;
        }
    }
}