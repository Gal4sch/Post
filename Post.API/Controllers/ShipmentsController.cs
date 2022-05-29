using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Post.Infrastructure.Commands;
using Post.Infrastructure.Services;

namespace Post.API.Controllers
{
    [Route("[controller]")]
    public class ShipmentsController : Controller
    {
        private readonly IShipmentsService _shipmentsService;

        public ShipmentsController(IShipmentsService shipmentsService)
        {
            _shipmentsService = shipmentsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string companyName)
        {
            var shipments = await _shipmentsService.BrowseAsync(companyName);

            return Json(shipments);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateShipments command)
        {
            command.ShipmentsId = Guid.NewGuid();
            await _shipmentsService.CreateAsync(command.ShipmentsId, command.ShipmentsNumber, command.SenderCompanyName, command.SenderName,
                command.SenderStreet, command.SenderZipCode, command.SenderCity, command.SenderPhoneNumber, command.SenderEmail, 
                command.RecipientCompanyName, command.RecipientName, command.RecipientStreet, command.RecipientZipCode, command.RecipientCity,
                command.RecipientPhoneNumber, command.RecipientEmail, command.Description);

            return Created($"/shipments/{command.ShipmentsId}", null);
        }
    }
}