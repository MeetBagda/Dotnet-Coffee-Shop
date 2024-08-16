using Microsoft.AspNetCore.Mvc;

namespace coffee_shop.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult ProductList()
        {
            return View();
        }
    }
}
