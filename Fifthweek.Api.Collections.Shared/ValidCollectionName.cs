﻿namespace Fifthweek.Api.Collections.Shared
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Fifthweek.CodeGeneration;

    [AutoEqualityMembers]
    public partial class ValidCollectionName
    {
        public static readonly string ForbiddenCharacters = "\r\n\t";
        public static readonly int MinLength = 1;
        public static readonly int MaxLength = 25;

        private const string ForbiddenCharacterMessage = "Must not contain new lines or tabs";
        private static readonly HashSet<char> ForbiddenCharactersHashSet = new HashSet<char>(ForbiddenCharacters);

        private ValidCollectionName()
        {
        }

        public string Value { get; protected set; }

        public static bool IsEmpty(string value)
        {
            // Whitespace is considered a value, since values are not trimmed/normalized.
            return string.IsNullOrEmpty(value); // Trimmed types use IsNullOrWhiteSpace
        }

        public static ValidCollectionName Parse(string value)
        {
            ValidCollectionName retval;
            if (!TryParse(value, out retval))
            {
                throw new ArgumentException("Invalid collection name", "value");
            }

            return retval;
        }

        public static bool TryParse(string value, out ValidCollectionName collectionName)
        {
            IReadOnlyCollection<string> errorMessages;
            return TryParse(value, out collectionName, out errorMessages);
        }

        public static bool TryParse(string value, out ValidCollectionName collectionName, out IReadOnlyCollection<string> errorMessages)
        {
            var errorMessageList = new List<string>();
            errorMessages = errorMessageList;

            if (IsEmpty(value))
            {
                // TryParse should never fail, so report null as an error instead of ArgumentNullException.
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
                collectionName = null;
                return false;
            }

            collectionName = new ValidCollectionName
            {
                Value = value
            };

            return true;
        }
    }
}