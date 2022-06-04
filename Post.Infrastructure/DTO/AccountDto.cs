using System;

namespace Post.Infrastructure.DTO
{
    public class AccountDto
    {
        public Guid Id { get; set; }
        public int UserNumber { get; set; }
        public string Role { get; set; }
        public string UserLogin { get; set; }
    }
}