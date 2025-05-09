using Ecommerce.Application.Contracts;
using Ecommerce.Context;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure
{
    public class OrderRepo : GenericRepo<Order>, IOrderRepo
    {
        private readonly ContextDB _context;

        public OrderRepo(ContextDB context) : base(context)
        {
            _context = context;
        }

        public void ApproveOrder(int orderId)
        {
            var order = _context.orders.Find(orderId);
            if (order != null && order.Status == OrderStatus.Pending)
            {
                order.Status = OrderStatus.Approved;

            }
        }

        public void DenyOrder(int orderId)
        {
            var order = _context.orders.Find(orderId);
            if (order != null && order.Status == OrderStatus.Pending)
            {
                order.Status = OrderStatus.Denied;

            }
        }

        public IQueryable<Order> GetOrdersByStatus(OrderStatus status)
        {
            return _context.orders.Where(o => o.Status == status);
        }


    }

}
