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
        public void Create()
        {
            var user = new User("bla", "bbla", "blablba");

            var totalBeforeInsert = _repository.GetAll().Count;
            var userSuccecedAdded = _repository.Create(user);
            var totalAfterInsert = _repository.GetAll().Count;

            Assert.IsNotNull(userSuccecedAdded);
            Assert.AreNotEqual(totalBeforeInsert, totalAfterInsert);
        }

        /*[TestMethod]
        public void GetById()
        {
            var user = _repository.GetById(1);
            Assert.AreEqual(user.Id, 1);
        }*/

        [TestMethod]
        public void GetAll()
        {
            var list = _repository.GetAll();
            Assert.AreNotEqual(0, list.Count);
            Assert.IsNotNull(list);
        }

        [TestMethod]
        public void Update()
        {
            var user = new User("bla", "bbla", "blablba");
            var totalBeforeInsert = _repository.GetAll().Count;
            _repository.Update(user);
            var totalAfterInsert = _repository.GetAll().Count;
            Assert.AreEqual(totalBeforeInsert, totalAfterInsert);
            Assert.AreEqual(user.Username, _repository.GetById(user.Id).Username);
        }

        [TestMethod]
        public void Delete()
        {
            _repository.Delete(1);
            Assert.IsNull(_repository.GetById(1));
        }

    }
}
