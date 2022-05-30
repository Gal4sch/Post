using System;

namespace Post.Infrastructure.Commands.Users
{
    public class Register
    {
        public Guid UserId { get; set; }
        public int UserNumber { get; set; }
        public string UserLogin { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}