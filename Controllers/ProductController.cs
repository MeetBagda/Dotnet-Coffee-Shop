using Microsoft.AspNetCore.Mvc;

namespace coffee_shop.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
