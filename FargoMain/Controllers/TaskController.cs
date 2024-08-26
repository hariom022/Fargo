using Microsoft.AspNetCore.Mvc;

namespace FargoMain.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
