using Microsoft.AspNetCore.Mvc;

namespace FargoMain.Controllers
{
    public class NewTaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
