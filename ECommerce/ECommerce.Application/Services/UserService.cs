using System.Collections.Generic;
using ECommerce.Domain.Services;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Repositories;
using ECommerce.Helpers.Validation;
using ECommerce.Helpers.Resources;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace ECommerce.Application.Services
{
    public class UserService : IUserService
    {
        IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new Exception(Errors.InvalidCredentials);

            var user = _repository.GetByUserName(username);

            if (user == null)
                throw new Exception(Errors.UserNotFound);

            if (!SecurityHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                throw new Exception(Errors.PasswordDoesNotMatch);
                
            return user;    

        }


        //CREATE
        public User Create(User user, string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new Exception(Errors.NullUserPassword);

            if (_repository.GetByUserName(user.Username) != null)
                throw new Exception(Errors.DuplicateUsername);

            user.SetPassword(password);
            user.CreationDate = DateTime.UtcNow;

            _repository.Create(user);

            return user;
        }

        //READ
        public IEnumerable<User> GetAll()
        {
            return _repository.GetAll();
        }

        public User GetById(int id)
        {
            var user = _repository.GetById(id);

            if (user == null)
                throw new Exception(Errors.UserNotFound);

            return user;
        }

        //UPDATE
        public void Update(User userParam, string password = null)
        {
            var user = _repository.GetById(userParam.Id);
 
            if (user == null)
                throw new Exception(Errors.UserNotFound);
 
            if (userParam.Username != user.Username)
            {    
                if (_repository.GetByUserName(userParam.Username) != null)
                    throw new Exception(Errors.DuplicateUsername);
            }

            user.SetFirstName(userParam.FirstName);
            user.SetLastName(userParam.LastName);
            user.SetUsername(userParam.Username);

            if (!string.IsNullOrWhiteSpace(password))
            {
                user.SetPassword(password);
            }

            user.UpdateDate = DateTime.UtcNow;

            _repository.Update(user);
        }

        //DELETE
        public void Delete(int id)
        {
            var user = _repository.GetById(id);

            if (user == null)
                throw new Exception(Errors.UserNotFound);

            _repository.Delete(user);
        }

    }
}
