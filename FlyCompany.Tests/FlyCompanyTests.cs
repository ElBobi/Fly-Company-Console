using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.IdentityModel.Logging;
using FlyCompanyConsoleApp.View;
using FlyCompanyConsoleApp.Controller;
using FlyCompanyConsoleApp.Models;

namespace FlyCompany.Tests
{
    [TestFixture]
    public class FlyCompanyTests
    {
        [TestCase(null,"password")]
        [TestCase("username",null)]
        [TestCase(null,null)]
        public void LoginMethodShouldReturnFalseWhenGivenANullValue(string username, string password)
        {
            var logger = new LoggerController();
            Assert.IsFalse(logger.Login(username,password));
        }
        [TestCase]
        public void LoginMethodShouldReturnFalseWhenGivenFalseData()
        {
            var logger = new LoggerController();
            Assert.IsFalse(logger.Login("username","password"));
        }
        [TestCase]
        public void LoginMethodShouldReturnTrueWhenGivenExistingData()
        {
            var logger = new LoggerController();
            Assert.IsTrue(logger.Login("borisradin@abv.bg", "bobi45"));
        }
    }
}
