using Microsoft.AspNetCore.Mvc;

namespace FargoMain.Controllers
{
    public class CalendarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GroupData()
        {
            return View();
        }
    }
}
