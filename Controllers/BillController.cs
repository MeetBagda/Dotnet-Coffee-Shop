using Microsoft.AspNetCore.Mvc;

namespace coffee_shop.Controllers
{
    public class BillController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
