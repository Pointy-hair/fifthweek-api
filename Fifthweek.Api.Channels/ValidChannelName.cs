﻿namespace Fifthweek.Api.Channels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Fifthweek.CodeGeneration;

    [AutoEqualityMembers]
    public partial class ValidChannelName
    {
        public static readonly string ForbiddenCharacters = "\r\n\t";
        public static readonly int MinLength = 1;
        public static readonly int MaxLength = 25;

        private const string ForbiddenCharacterMessage = "Must not contain new lines or tabs";
        private static readonly HashSet<char> ForbiddenCharactersHashSet = new HashSet<char>(ForbiddenCharacters);

        private ValidChannelName()
        {
        }

        public string Value { get; protected set; }

        public static bool IsEmpty(string value)
        {
            // Whitespace is considered a value, since values are not trimmed/normalized.
            return string.IsNullOrEmpty(value); // Trimmed types use IsNullOrWhiteSpace
        }

        public static ValidChannelName Parse(string value)
        {
            ValidChannelName retval;
            if (!TryParse(value, out retval))
            {
                throw new ArgumentException("Invalid channel name", "value");
            }

            return retval;
        }

        public static bool TryParse(string value, out ValidChannelName channelName)
        {
            IReadOnlyCollection<string> errorMessages;
            return TryParse(value, out channelName, out errorMessages);
        }

        public static bool TryParse(string value, out ValidChannelName channelName, out IReadOnlyCollection<string> errorMessages)
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
                    errorMessageList.Add(ForbiddenCharacterMessage);
                }
            }

            if (errorMessageList.Count > 0)
            {
                channelName = null;
                return false;
            }

            channelName = new ValidChannelName
            {
                Value = value
            };

            return true;
        }
    }
}