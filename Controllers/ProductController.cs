using Microsoft.AspNetCore.Mvc;

namespace coffee_shop.Controllers
{

    public class ProductController : Controller
    {
        private IConfiguration configuration;

        public ProductController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public IActionResult ProductList()
        {
            return View();
        }
    }
}
