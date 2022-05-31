using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Post.Infrastructure.Commands.Users;
using Post.Infrastructure.Services;

namespace Post.API.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            throw new NotImplementedException();
        }

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
        public async Task<IActionResult> Post(Register command)
        {
            await _userService.RegisterAsync(Guid.NewGuid(), command.UserNumber, command.UserLogin,
                command.Password, command.PhoneNumber, command.Email, command.Role);

            return Created("/account",null);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Post(Login command)
        {
            throw new NotImplementedException();
        }
    }
}