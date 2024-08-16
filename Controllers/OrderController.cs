using Microsoft.AspNetCore.Mvc;

namespace coffee_shop.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult OrderList()
        {
            return View();
        }
    }
}
