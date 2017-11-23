using System.Collections.Generic;
using ECommerce.Domain.Services;
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
            context.Database.EnsureCreated();
            _context = context;
        }

        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new Exception();
            }
            else
            {
                var user = _context.Users.SingleOrDefault(x => x.Username == username);

                if (user == null)
                    throw new Exception();

                if (!PasswordHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                    throw new Exception();
                

                return user;    
            }
        }

        //CREATE
        public User Create(User user, string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new Exception();

            if (_context.Users.Any(x => x.Username == user.Username))
                throw new Exception("Username " + user.Username + " já está em uso!");

            byte[] passwordHash, passwordSalt;
            PasswordHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        //READ
        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
                throw new Exception();

            return user;
        }

        //UPDATE
        public void Update(User userParam, string password = null)
        {
            var user = _context.Users.Find(userParam.Id);
 
            if (user == null)
                throw new Exception();
 
            if (userParam.Username != user.Username)
            {    
                if (_context.Users.Any(x => x.Username == userParam.Username))
                    throw new Exception("Username " + userParam.Username + " já está em uso!");
            }

            user.FirstName = userParam.FirstName;
            user.LastName = userParam.LastName;
            user.Username = userParam.Username;

            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                PasswordHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
 
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }
 
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
