using System;

namespace Post.Core.Domain
{
    public class User : Entity
    {
        public int UserNumber { get; protected set; }
        public string Role { get; protected set; }
        public string UserLogin { get; protected set; }
        public string Password { get; protected set; }
        public string PhoneNumber { get; protected set; }
        public string Email { get; protected set; }
        public string Name { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        protected User()
        {
        }
        public User(Guid id, int userNumber, string role, string userLogin, string email,
            string password, string phoneNumber, string name)
        {
            Id = id;
            UserNumber = userNumber;
            Role = role;
            UserLogin = userLogin;
            Email = email;
            Password = password; 
            PhoneNumber = phoneNumber;
            Name = name; 
            CreatedAt = DateTime.Now;
        }
    }
}