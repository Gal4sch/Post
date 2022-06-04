using System;
using System.Threading.Tasks;
using AutoMapper;
using Post.Core.Domain;
using Post.Core.Repositories;
using Post.Infrastructure.DTO;
using Post.Infrastructure.Extensions;

namespace Post.Infrastructure.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IJwtHandler jwtHandler,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _jwtHandler = jwtHandler;
            _mapper = mapper;
        }

        public async Task<AccountDto> GetAccountAsync(Guid userId)
        {
            var user = await _userRepository.GetOrFailUserAsync(userId);

            return _mapper.Map<AccountDto>(user);
        }
        public async Task RegisterAsync(Guid userId, int userNumber, string userLogin,
            string password, string phoneNumber, string email, string name, string role = "user")
        {
            var user = await _userRepository.GetAsync(userNumber);
            if (user != null)
            {
                throw new Exception($"User with number: '{userNumber}' already exists.");
            }
            user = new User(userId, userNumber, role, userLogin, email, password, phoneNumber, name);
            await _userRepository.AddAsync(user);
        }

        public async Task<TokenDto> LoginAsync(int userNumber, string userLogin, string password)
        {
            var user = await _userRepository.GetAsync(userNumber);
            
            if (user == null)
            {
                throw new Exception($"Invalid credentials.");
            }

            if (user.Password != password)
            {
                throw new Exception($"Invalid credentials.");
            }
            var jwt = _jwtHandler.CreateToken(user.Id, user.Role);

            return new TokenDto
            {
                Token = jwt.Token,
                Expires = jwt.Expires,
                Role = user.Role
            };
        }
    }
}