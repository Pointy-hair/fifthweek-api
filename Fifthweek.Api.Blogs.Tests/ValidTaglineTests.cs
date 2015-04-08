﻿namespace Fifthweek.Api.Blogs.Tests
{
    using System.Collections.Generic;

    using Fifthweek.Api.Blogs.Shared;
    using Fifthweek.Tests.Shared;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ValidTaglineTests : ValidatedStringTests<ValidTagline>
    {
        public static readonly string InvalidValue = "!";

        protected override string ValueA
        {
            get { return "Web Comics and More"; }
        }

        protected override string ValueB
        {
            get { return "Web Comics and Much, Much More"; }
        }

        [TestMethod]
        public void ItShouldTreatNullAsEmpty()
        {
            var result = ValidTagline.IsEmpty(null);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ItShouldTreatEmptyStringAsEmpty()
        {
            var result = ValidTagline.IsEmpty(string.Empty);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ItShouldTreatStringWithOnlyWhiteSpaceCharactersAsNonEmpty()
        {
            var result = ValidTagline.IsEmpty(" ");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ItShouldTreatStringWithAtLeast1NonWhiteSpaceCharacterAsNonEmpty()
        {
            var result = ValidTagline.IsEmpty("a");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ItShouldAllowBasicTaglines()
        {
            this.GoodValue(this.ValueA);
            this.GoodValue(this.ValueB);
        }

        [TestMethod]
        public void ItShouldNotAllowNull()
        {
            this.BadValue(null);
        }

        [TestMethod]
        public void ItShouldAllowPunctuation()
        {
            this.AssertPunctuationAllowed();
        }

        [TestMethod]
        public void ItShouldNotAllowTaglinesUnder5Characters()
        {
            this.AssertMinLength(5);
        }

        [TestMethod]
        public void ItShouldNotAllowTaglinesOver55Characters()
        {
            this.AssertMaxLength(55);
        }

        [TestMethod]
        public void ItShouldNotAllowTabs()
        {
            this.AssertTabsNotAllowed();
        }

        [TestMethod]
        public void ItShouldNotAllowNewLines()
        {
            this.AssertNewLinesNotAllowed();
        }

        protected override ValidTagline Parse(string value)
        {
            return ValidTagline.Parse(value);
        }

        protected override bool TryParse(string value, out ValidTagline parsedObject)
        {
            return ValidTagline.TryParse(value, out parsedObject);
        }

        protected override bool TryParse(string value, out ValidTagline parsedObject, out IReadOnlyCollection<string> errorMessages)
        {
            return ValidTagline.TryParse(value, out parsedObject, out errorMessages);
        }

        protected override string GetValue(ValidTagline parsedObject)
        {
            return parsedObject.Value;
        }
    }
}