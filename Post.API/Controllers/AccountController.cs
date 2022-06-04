using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Post.Infrastructure.Commands.Users;
using Post.Infrastructure.Services;

namespace Post.API.Controllers
{
    public class AccountController : ApiControllerBase
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Get()
            => Json(await _userService.GetAccountAsync(UserId));

        [HttpPost("shipments")]
        public async Task<IActionResult> CreateShipments()
        {
            throw new NotImplementedException();
        }
        [HttpPost("courierorder")]
        public async Task<IActionResult> CreateCourierOrder()
        {
            throw new NotImplementedException();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody]Register command)
        {
            await _userService.RegisterAsync(Guid.NewGuid(), command.UserNumber, command.UserLogin,
                command.Password, command.PhoneNumber, command.Email, command.Name, command.Role);

            return Created("/account",null);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody]Login command)
            => Json(await _userService.LoginAsync(command.UserNumber, command.UserLogin, command.Password));
    }
}