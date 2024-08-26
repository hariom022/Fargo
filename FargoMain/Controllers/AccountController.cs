using Microsoft.AspNetCore.Mvc;

namespace FargoMain.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Registor()
        {
            return View();
        }
    }
}
