using Microsoft.AspNetCore.Mvc;

namespace coffee_shop.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
