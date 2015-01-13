﻿namespace Fifthweek.Api.Subscriptions
{
    using System;
    using System.Collections.Generic;

    using Fifthweek.Api.Core;

    [AutoEqualityMembers]
    public partial class ValidDescription
    {
        public static readonly int MinLength = 1;
        public static readonly int MaxLength = 2000;

        private ValidDescription()
        {
        }

        public string Value { get; protected set; }

        public static bool IsEmpty(string value)
        {
            // Whitespace is considered a value, since values are not trimmed/normalized.
            return string.IsNullOrEmpty(value); // Trimmed types use IsNullOrWhiteSpace
        }

        public static ValidDescription Parse(string value)
        {
            ValidDescription retval;
            if (!TryParse(value, out retval))
            {
                throw new ArgumentException("Invalid description", "value");
            }

            return retval;
        }

        public static bool TryParse(string value, out ValidDescription description)
        {
            IReadOnlyCollection<string> errorMessages;
            return TryParse(value, out description, out errorMessages);
        }

        public static bool TryParse(string value, out ValidDescription description, out IReadOnlyCollection<string> errorMessages)
        {
            var errorMessageList = new List<string>();
            errorMessages = errorMessageList;

            if (IsEmpty(value))
            {
                // Method should never fail, so report null as an error instead of ArgumentNullException.
                errorMessageList.Add("Value required");
            }
            else
            {
                if (value.Length < MinLength || value.Length > MaxLength)
                {
                    errorMessageList.Add(string.Format("Length must be from {0} to {1} characters", MinLength, MaxLength));
                }
            }

            if (errorMessageList.Count > 0)
            {
                description = null;
                return false;
            }

            description = new ValidDescription
            {
                Value = value
            };

            return true;
        }
    }
}