using Microsoft.AspNetCore.Mvc;

namespace coffee_shop.Controllers
{
    public class UserController : Controller
    {
        public IActionResult UserList()
        {
            return View();
        }
    }
}
