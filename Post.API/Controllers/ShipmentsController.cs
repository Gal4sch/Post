using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
    }
}