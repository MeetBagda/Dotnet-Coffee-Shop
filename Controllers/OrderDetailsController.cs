using Microsoft.AspNetCore.Mvc;

namespace coffee_shop.Controllers
{
    public class OrderDetailsController : Controller
    {
        private IConfiguration configuration;

        public OrderDetailsController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public IActionResult OrderDetailsList()
        {
            return View();
        }
    }
}
