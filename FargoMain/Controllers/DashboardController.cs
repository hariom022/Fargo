using Microsoft.AspNetCore.Mvc;

namespace FargoMain.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Overview()
        {
            return View();
        }
    }
}
