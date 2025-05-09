using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Models;

namespace Ecommerce.Application.Contracts
{
   public interface IOrderRepo : IGenericRepo<Order>

    {
        IQueryable<Order> GetOrdersByStatus(OrderStatus status);
        void ApproveOrder(int orderId);
        void DenyOrder(int orderId);
    }
}
