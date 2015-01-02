﻿using Fifthweek.Api.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fifthweek.Api.Tests.Models
{
    [TestClass]
    public class PasswordResetRequestDataTests
    {
        [TestMethod]
        public void ItShouldRecogniseEqualObjects()
        {
            var registration1 = NewPasswordResetRequestData();
            var registration2 = NewPasswordResetRequestData();

            Assert.AreEqual(registration1, registration2);
        }

        [TestMethod]
        public void ItShouldRecogniseDifferentEmail()
        {
            var registration1 = NewPasswordResetRequestData();
            var registration2 = NewPasswordResetRequestData();
            registration2.Email = "Different";

            Assert.AreNotEqual(registration1, registration2);
        }

        [TestMethod]
        public void ItShouldRecogniseDifferentUsername()
        {
            var registration1 = NewPasswordResetRequestData();
            var registration2 = NewPasswordResetRequestData();
            registration2.Username = "Different";

            Assert.AreNotEqual(registration1, registration2);
        }

        public static PasswordResetRequestData NewPasswordResetRequestData()
        {
            return new PasswordResetRequestData
            {
                Email = "test@test.com",
                Username = "TestUsername",
            };
        }
    }
}