using System.Collections.Generic;
using ECommerce.Domain.Services;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Repositories;
using ECommerce.Helpers.Validaton;
using ECommerce.Helpers.Resources;
using System;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace ECommerce.Application.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new Exception(Errors.UserNotFound);
            }
            else
            {
                var user = _repository.GetByUserName(username);

                if (user == null)
                    throw new Exception();

                if (!PasswordHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                    throw new Exception(Errors.PasswordDoesNotMatch);
                
                return user;    
            }
        }

        public string GenerateSessionToken(User user, string secret)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        //CREATE
        public User Create(User user, string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new Exception(Errors.NullUserPassword);

            if (_repository.GetByUserName(user.Username) != null)
                throw new Exception(Errors.DuplicateUsername);

            byte[] passwordHash, passwordSalt;
            PasswordHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

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
