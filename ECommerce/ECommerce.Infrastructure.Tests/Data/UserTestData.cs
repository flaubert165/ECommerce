using System.Collections.Generic;
using ECommerce.Domain.Entities;

namespace ECommerce.Infrastructure.Tests.Data
{
    public class UserTestData
    {
        public static User GetById(){

            return new User("bla", "bbla","blablba");
        }

        public static List<User> GetAll()
        {
            return new List<User>
            {
                new User("bla", "bbla","blablba"),
                new User("bla", "bbla", "blablba"),
                new User("bla", "bbla", "blablba"),
                new User("bla", "bbla", "blablba")
            };
        }
    }
}
