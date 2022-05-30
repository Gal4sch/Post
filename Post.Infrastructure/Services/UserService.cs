using System;
using System.Threading.Tasks;
using Post.Core.Domain;
using Post.Core.Repositories;

namespace Post.Infrastructure.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task RegisterAsync(Guid userId, int userNumber, string userLogin, 
            string password, string phoneNumber, string email, string role = "user")
        {
            var user = await _userRepository.GetAsync(userNumber);
            if(user != null)
            {
                throw new Exception($"User with number: '{userNumber}' already exists.");
            }
            user = new User(userId, userNumber, role, userLogin, email, password, phoneNumber);
            await _userRepository.AddAsync(user);
        }
    }
}