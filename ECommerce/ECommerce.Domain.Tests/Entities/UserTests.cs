using System;
using ECommerce.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ECommerce.Domain.Tests.Entities
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void User_New_User_WithBlankParameters()
        {
            var user = new User("", "", "");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void User_New_User_WithNullParameters()
        {
            var user = new User(null, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void SetUserName_MaxValue()
        {
            var user = new User("", "", "123456789123456782345678123456789");
        }
    }
}
