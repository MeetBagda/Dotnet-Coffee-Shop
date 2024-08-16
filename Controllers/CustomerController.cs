using Microsoft.AspNetCore.Mvc;

namespace coffee_shop.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
