using System;
using System.Threading.Tasks;
using Post.Infrastructure.DTO;

namespace Post.Infrastructure.Services
{
    public interface IUserService
    {
        Task<AccountDto> GetAccountAsync(Guid userId);
        Task RegisterAsync(Guid userId, int userNumber, string userLogin, string password,
            string phoneNumber, string email, string name, string role = "user");

        Task<TokenDto> LoginAsync(int userNumber, string userLogin, string password);
    }
}