using System.Collections.Generic;
using ECommerce.Domain.Entities;

namespace ECommerce.Infrastructure.Tests.Data
{
    public class UserTestData
    {
        public static List<User> GetAll()
        {
            return new List<User>
            {
                new User{Id = 1, Username = "bla", FirstName = "bbla", LastName = "blablba"},
                new User{Id = 2, Username = "bla", FirstName = "bbla", LastName = "blablba"},
                new User{Id = 3, Username = "bla", FirstName = "bbla", LastName = "blablba"},
                new User{Id = 4, Username = "bla", FirstName = "bbla", LastName = "blablba"}
            };
        }
    }
}
