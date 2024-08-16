using Microsoft.AspNetCore.Mvc;

namespace coffee_shop.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
