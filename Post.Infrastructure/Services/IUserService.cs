using System;
using System.Threading.Tasks;

namespace Post.Infrastructure.Services
{
    public interface IUserService
    {
        Task RegisterAsync(Guid userId, int userNumber, string userLogin, string password, 
            string phoneNumber, string email, string role = "user");
    }
}