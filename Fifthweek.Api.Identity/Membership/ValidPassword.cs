﻿namespace Fifthweek.Api.Identity.Membership
{
    using System;
    using System.Collections.Generic;

    public class ValidatedPassword : Password
    {
        public static readonly int MinLength = 6;

        public static readonly int MaxLength = 100;

        protected ValidatedPassword(string value)
            : base(value)
        {
        }

        public static bool IsEmpty(string value)
        {
            // Whitespace is considered a value. It is handled differently from null.
            return string.IsNullOrEmpty(value); // Trimmed types use IsNullOrWhiteSpace
        }

        public static ValidatedPassword Parse(string value)
        {
            ValidatedPassword retval;
            if (!TryParse(value, out retval))
            {
                throw new ArgumentException("Invalid password", "value");
            }

            return retval;
        }

        public static bool TryParse(string value, out ValidatedPassword password)
        {
            IReadOnlyCollection<string> errorMessages;
            return TryParse(value, out password, out errorMessages);
        }

        public static bool TryParse(string value, out ValidatedPassword password, out IReadOnlyCollection<string> errorMessages)
        {
            var errorMessageList = new List<string>();
            errorMessages = errorMessageList;

            if (IsEmpty(value))
            {
                // Method should never fail, so report null as an error instead of ArgumentNullException.
                errorMessageList.Add("Value required");
            }
            else if (value.Length < MinLength || value.Length > MaxLength)
            {
                errorMessageList.Add(string.Format("Length must be from {0} to {1} characters", MinLength, MaxLength));
            }

            if (errorMessageList.Count > 0)
            {
                password = null;
                return false;
            }

            password = new ValidatedPassword(value);

            return true;
        }
    }
}