using CITApplication.ViewModels;
using CITDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITApplication.Interfaces
{
    public interface IOrderService
    {
        Task<int> CreateOrder(OrderModel orderModel);
        Task<OrderResponse> GetOrderData(int ResourceId);
    }
}
