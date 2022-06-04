using System;

namespace Post.Infrastructure.Commands.Users
{
    public class Login
    {
        public Guid UserId { get; set; }
        public int UserNumber { get; set; }
        public string UserLogin { get; set; }
        public string Password { get; set; }
    }
}