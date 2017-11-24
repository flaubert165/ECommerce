using System.Collections.Generic;
using ECommerce.Domain.Entities;

namespace ECommerce.Domain.Services
{
    public interface IUserService
    {
        string GenerateSessionToken(User user, string secret);
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(int id);
    }
}
