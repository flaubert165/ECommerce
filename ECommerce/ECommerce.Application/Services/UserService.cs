using System.Collections.Generic;
using ECommerce.Domain.Contracts;
using ECommerce.Domain.Entities;
using ECommerce.Helpers.Helpers;
using ECommerce.Infrastructure.Data;
using System.Linq;
using System;

namespace ECommerce.Application.Services
{
    public class UserService : IUserService
    {
        private DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public User Authenticate(string username, string password)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                var user = _context.Users.SingleOrDefault(x => x.Username == username);

                if (user == null)
                {
                    throw new Exception();
                }

                if (!PasswordHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                {
                    throw new Exception();
                }

                return user;

            }
            else
            {
                throw new ArgumentNullException();    
            }
        }

        public User Create(User user, string password)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(User user, string password = null)
        {
            throw new System.NotImplementedException();
        }
    }
}
