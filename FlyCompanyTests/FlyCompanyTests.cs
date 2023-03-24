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
    public class FlyCompanyTests
    {
        [TestCase(null, "password")]
        [TestCase("username", null)]
        [TestCase(null, null)]
        public void LoginMethodShouldReturnFalseWhenGivenANullValue(string username, string password)
        {
            var logger = new LoggerController();
            Assert.IsFalse(logger.Login(username, password));
        }
        [TestCase("borisradin@abv.bg", "sdfsdf")]
        [TestCase("sdfsdf", "salam123")]
        public void LoginMethodShouldReturnFalseWhenGivenFalseData(string username, string password)
        {
            var logger = new LoggerController();
            Assert.IsFalse(logger.Login(username, password));
        }
        [TestCase]
        public void LoginMethodShouldReturnTrueWhenGivenExistingData()
        {
            var logger = new LoggerController();
            Assert.IsTrue(logger.Login("penchi", "05"));
        }
    }
}
