using CITApplication.Interfaces;
using CITApplication.ViewModels;
using CITDomain.Interfaces;
using CITDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITApplication.Services
{
    public class OrderService : IOrderService
    {
        public readonly IOrderRepository _IOrderRepository;

        public OrderService(IOrderRepository IOrderrepository)
        {
            _IOrderRepository = IOrderrepository;
        }
        public async Task<int> CreateOrder(OrderModel orderModel)
        {
            return await _IOrderRepository.CreateOrder(orderModel);       
        }
        public async Task<OrderResponse> GetOrderData(int resourceId)
        {
            return await _IOrderRepository.GetOrderData(resourceId);
        }

        //Task<OrderVM> IOrderService.GetOrderData(int ResourceId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
