using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Repositories;
using ECommerce.Infrastructure.Tests.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ECommerce.Infrastructure.Tests
{
    [TestClass]
    public class UserRepositoryTest
    {
        private readonly RepositoryList<User> _repository;

        public UserRepositoryTest()
        {
            _repository = new RepositoryList<User>(UserTestData.GetAll());

        }

        [TestMethod]
        public void GetAll()
        {
            var list = _repository.GetAll();
            Assert.AreNotEqual(0, list.Count);
            Assert.IsNotNull(list);
        }

    }
}
