using Microsoft.AspNetCore.Mvc;

namespace coffee_shop.Controllers
{
    public class BillController : Controller
    {
        private IConfiguration configuration;

        public BillController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public IActionResult BillList()
        {
            return View();
        }
    }
}
