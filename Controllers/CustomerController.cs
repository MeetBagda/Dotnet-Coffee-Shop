using Microsoft.AspNetCore.Mvc;

namespace coffee_shop.Controllers
{
    public class CustomerController : Controller
    {
        private IConfiguration configuration;

        public CustomerController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public IActionResult CustomerList()
        {
            return View();
        }
    }
}
