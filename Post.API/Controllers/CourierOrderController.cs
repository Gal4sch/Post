using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Post.Infrastructure.Commands;
using Post.Infrastructure.Services;

namespace Post.API.Controllers
{
    [Route("[controller]")]
    public class CourierOrderController : Controller
    {
        private readonly ICourierOrderService _courierOrderService;

        public CourierOrderController(ICourierOrderService courierOrderService)
        {
            _courierOrderService = courierOrderService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string companyName)
        {
            var courierOrder = await _courierOrderService.BrowseAsync(companyName);

            return Json(courierOrder);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateCourierOrder command)
        {
            command.CourierOrderId = Guid.NewGuid();
            await _courierOrderService.CreateAsync(command.CourierOrderId, command.CourierOrderNumber, command.SenderCompanyName,
                command.SenderName, command.SenderStreet, command.SenderZipCode, command.SenderCity, command.SenderPhoneNumber, 
                command.SenderEmail, command.Description, command.NumberOfPackages);

                return Created($"/courierorder/{command.CourierOrderId}", null);
        }
    }
}