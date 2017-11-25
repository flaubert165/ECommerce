namespace ECommerce.Domain.Entities
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public User()
        {
        }

        public User(string fName, string lName, string uName)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.Username = uName;
        }
    }
}