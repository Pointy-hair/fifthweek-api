﻿using Fifthweek.Api.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fifthweek.Api.Tests.Models
{
    [TestClass]
    public class RegistrationDataTests
    {
        [TestMethod]
        public void ItShouldRecogniseEqualObjects()
        {
            var registration1 = NewRegistrationData();
            var registration2 = NewRegistrationData();

            Assert.AreEqual(registration1, registration2);
        }

        [TestMethod]
        public void ItShouldRecogniseDifferentExampleWork()
        {
            var registration1 = NewRegistrationData();
            var registration2 = NewRegistrationData();
            registration2.ExampleWork = "Different";

            Assert.AreNotEqual(registration1, registration2);
        }

        [TestMethod]
        public void ItShouldRecogniseDifferentEmail()
        {
            var registration1 = NewRegistrationData();
            var registration2 = NewRegistrationData();
            registration2.Email = "Different";

            Assert.AreNotEqual(registration1, registration2);
        }

        [TestMethod]
        public void ItShouldRecogniseDifferentUsername()
        {
            var registration1 = NewRegistrationData();
            var registration2 = NewRegistrationData();
            registration2.Username = "Different";

            Assert.AreNotEqual(registration1, registration2);
        }

        [TestMethod]
        public void ItShouldRecogniseDifferentPassword()
        {
            var registration1 = NewRegistrationData();
            var registration2 = NewRegistrationData();
            registration2.Password = "Different";

            Assert.AreNotEqual(registration1, registration2);
        }

        public static RegistrationData NewRegistrationData()
        {
            return new RegistrationData
            {
                ExampleWork = "TestExampleWork",
                Email = "test@test.com",
                Username = "TestUsername",
                Password = "TestPassword"
            };
        }
    }
}