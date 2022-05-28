using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
    }
}