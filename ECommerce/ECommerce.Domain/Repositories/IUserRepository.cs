using System.Collections.Generic;
using ECommerce.Domain.Entities;

namespace ECommerce.Domain.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        User GetByUserName(string username);
        User Create(User user);
        void Update(User user);
        void Delete(User id);
    }
}
