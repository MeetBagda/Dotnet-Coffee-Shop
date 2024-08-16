using Microsoft.AspNetCore.Mvc;

namespace coffee_shop.Controllers
{
    public class UserController : Controller
    {
        private IConfiguration configuration;

        public UserController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public IActionResult UserList()
        {
            return View();
        }
    }
}
