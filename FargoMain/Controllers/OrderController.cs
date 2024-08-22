using Microsoft.AspNetCore.Mvc;

namespace FargoMain.Controllers
{
    public class OrderController : Controller
    {
        public  IActionResult Index()
        {
            return View();
        }
    }
}
