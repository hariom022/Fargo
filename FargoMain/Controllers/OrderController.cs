using CITApplication.Interfaces;
using CITApplication.Services;
using CITApplication.ViewModels;
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
        public async Task<IActionResult> Index()
        {
            int ResourceId = 4;
            OrderResponse orderVM = new OrderResponse();
            orderVM = await _OrderService.GetOrderData(ResourceId);
            return View();
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] OrderModel order)
        {
            var task = _OrderService.CreateOrder(order);
            var result = task.Result;
            return View();
        }
    }
}
