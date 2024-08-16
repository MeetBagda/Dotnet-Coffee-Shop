using Microsoft.AspNetCore.Mvc;

namespace coffee_shop.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult CustomerList()
        {
            return View();
        }
    }
}
