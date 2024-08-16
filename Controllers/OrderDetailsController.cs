using Microsoft.AspNetCore.Mvc;

namespace coffee_shop.Controllers
{
    public class OrderDetailsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
