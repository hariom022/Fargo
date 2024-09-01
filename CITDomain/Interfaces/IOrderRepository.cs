using CITDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CITDomain.Interfaces
{
    public interface IOrderRepository
    {
        Task<int> CreateOrder(OrderModel order);
    }
}
