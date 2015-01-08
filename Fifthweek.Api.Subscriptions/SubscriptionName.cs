﻿using System;
using System.Collections.Generic;
using System.Linq;
using Fifthweek.Api.Core;

namespace Fifthweek.Api.Subscriptions
{
    [AutoEqualityMembers]
    public partial class SubscriptionName
    {
        public static readonly string ForbiddenCharacters = "\r\n\t";
        public static readonly int MinLength = 1;
        public static readonly int MaxLength = 25;

        private static readonly HashSet<char> ForbiddenCharactersHashSet = new HashSet<char>(ForbiddenCharacters);

        private SubscriptionName()
        {
        }

        public string Value { get; protected set; }

        public static bool IsEmpty(string value)
        {
            // Whitespace is considered a value, since values are not trimmed/normalized.
            return string.IsNullOrEmpty(value); // Trimmed types use IsNullOrWhiteSpace
        }

        public static SubscriptionName Parse(string value)
        {
            SubscriptionName retval;
            if (!TryParse(value, out retval))
            {
                throw new ArgumentException("Invalid subscription name", "value");
            }

            return retval;
        }

        public static bool TryParse(string value, out SubscriptionName subscriptionName)
        {
            IReadOnlyCollection<string> errorMessages;
            return TryParse(value, out subscriptionName, out errorMessages);
        }

        public static bool TryParse(string value, out SubscriptionName subscriptionName, out IReadOnlyCollection<string> errorMessages)
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

                if (value.Any(ForbiddenCharactersHashSet.Contains))
                {
                    errorMessageList.Add("Must not contain new lines or tabs");
                }
            }

            if (errorMessageList.Count > 0)
            {
                subscriptionName = null;
                return false;
            }

            subscriptionName = new SubscriptionName
            {
                Value = value
            };

            return true;
        }
    }
}