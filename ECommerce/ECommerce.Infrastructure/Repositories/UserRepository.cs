using System;
using System.Collections.Generic;
using System.Linq;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Repositories;
using ECommerce.Infrastructure.Data;

namespace ECommerce.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private MySQLDataContext _context;

        public UserRepository(MySQLDataContext context)
        {
            context.Database.EnsureCreated();
            _context = context;
        }

        //CREATE
        public User Create(User user)
        {
            if(user != null)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }

            return user;
        }

        //READ
        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int id)
        {
            return _context.Users.Find(id);;
        }

        public User GetByUserName(string username)
        {
            return _context.Users.SingleOrDefault(x => x.Username.Equals(username));;
        }

        //UPDATE
        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges(); 
        }

        //DELETE
        public void Delete(int id)
        {
            var user = _context.Users.Find(id);

            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

    }
}
