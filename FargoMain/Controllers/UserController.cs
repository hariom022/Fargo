using CITApplication.Interfaces;
using CITDomain.Model;
using Microsoft.AspNetCore.Mvc;

namespace FargoMain.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string username)
        {
            UserModel userModel = new UserModel();
            userModel = await _userService.GetUserDetails(username);
            return Redirect("/Order/Index");
            //return View();
        }

        //public async Task<UserModel> GetLoginDetails(string username)
        //{
        //    userModel = await GetLoginDetails(username);
        //}
    }
}
