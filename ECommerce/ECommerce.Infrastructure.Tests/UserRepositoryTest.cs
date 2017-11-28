﻿using ECommerce.Domain.Entities;
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
            var user = new User { Id = 5, Username = "ble", FirstName = "blebleble", LastName = "blebleble" };

            var totalBeforeInsert = _repository.GetAll().Count;
            var userSuccecedAdded = _repository.Create(user);
            var totalAfterInsert = _repository.GetAll().Count;

            Assert.IsNotNull(userSuccecedAdded);
            Assert.AreNotEqual(totalBeforeInsert, totalAfterInsert);
        }

        [TestMethod]
        public void GetById()
        {
            var user = _repository.GetById(1);
            Assert.AreEqual(user.Id, 1);
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
