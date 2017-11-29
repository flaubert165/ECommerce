using System;
using ECommerce.Helpers.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ECommerce.Helpers.Tests
{
    [TestClass]
    public class GuardTests
    {

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_ForNullOrEmpty_Error_WhenInBlank()
        {
            Guard.ForNullOrEmpty("", "cara, tá em branco!");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_ForNullOrEmpty_Error_WhenIsNull()
        {
            Guard.ForNullOrEmpty(null, "cara, tá nulo!");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_ForNullOrWithWhiteSpaces_Error_WhenHasWhiteSpace()
        {
            Guard.ForNullOrStringWithWhiteSpaces(" ", "cara, tem espaço em branco!");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Guard_ForNullOrWithWhiteSpaces_Error_WhenIsNull()
        {
            Guard.ForNullOrStringWithWhiteSpaces(null, "cara, tá nulo!");
        }
    }
}
