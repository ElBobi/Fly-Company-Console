using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyCompany;
using FlyCompanyConsoleApp.Controller;

namespace FlyCompany.Tests
{
    [TestFixture]
    public class LoggingTests
    {
        [Test]
        public void Login_ValidUsernameAndPassword_ReturnsTrue()
        {
            // Arrange
            var loggerController = new LoggerController();
            var username = "bobi";
            var password = "05";

            // Act
            var result = loggerController.Login(username, password);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void Login_InvalidUsername_ReturnsFalse()
        {
            // Arrange
            var loggerController = new LoggerController();
            var username = "nonexistentuser";
            var password = "testpassword";

            // Act
            var result = loggerController.Login(username, password);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void Login_InvalidPassword_ReturnsFalse()
        {
            // Arrange
            var loggerController = new LoggerController();
            var username = "testuser";
            var password = "wrongpassword";

            // Act
            var result = loggerController.Login(username, password);

            // Assert
            Assert.That(result, Is.False);
        }





    }
}
