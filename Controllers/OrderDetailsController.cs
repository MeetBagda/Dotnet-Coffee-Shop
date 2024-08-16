using Microsoft.AspNetCore.Mvc;

namespace coffee_shop.Controllers
{
    public class OrderDetailsController : Controller
    {
        public IActionResult OrderDetailsList()
        {
            return View();
        }
    }
}
