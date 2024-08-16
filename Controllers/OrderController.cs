using Microsoft.AspNetCore.Mvc;

namespace coffee_shop.Controllers
{
    public class OrderController : Controller
    {
        private IConfiguration configuration;

        public OrderController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public IActionResult OrderList()
        {
            return View();
        }
    }
}
