using ECommerce.Helpers.Validation;

namespace ECommerce.Domain.Entities
{
    public class User : Entity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Username { get; private set; }
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }

        public User()
        {
        }

        public User(string firstName, string lastName, string userName)
        {
            SetFirstName(firstName);
            SetLastName(lastName);
            SetUsername(userName);
        }

        public void SetFirstName(string firstName)
        {
            Guard.ForNullOrEmptyDefaultMessage(firstName, "");
            Guard.StringLength("", firstName, 30);
            this.FirstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            Guard.ForNullOrEmptyDefaultMessage(lastName, "");
            Guard.StringLength("", lastName, 30);
            this.LastName = lastName;
        }

        public void SetUsername(string userName)
        {
            Guard.ForNullOrEmptyDefaultMessage(userName, "");
            Guard.StringLength("", userName, 20);
            this.Username = userName;
        }

        public void SetPassword(string password)
        {
            Guard.ForNullOrEmptyDefaultMessage(password, "");
            byte[] passwordHash, passwordSalt;
            SecurityHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            this.PasswordHash = passwordHash;
            this.PasswordSalt = passwordSalt;
        }

    }
}