using CITApplication.Interfaces;
using CITDomain.Model;
using Microsoft.AspNetCore.Mvc;

namespace FargoMain.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _OrderService;
        public OrderController(IOrderService OrderService)
        {
            _OrderService = OrderService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(OrderModel model)
        {
            OrderModel ordermodel=new OrderModel();
            ordermodel = _OrderService.CreateOrder(model);
            return View(model);
        }
    }
}
