using Microsoft.AspNetCore.Mvc;

namespace coffee_shop.Controllers
{
    public class BillController : Controller
    {
        public IActionResult BillList()
        {
            return View();
        }
    }
}
