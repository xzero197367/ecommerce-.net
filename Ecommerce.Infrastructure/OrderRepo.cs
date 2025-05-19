using Ecommerce.Application.Contracts;
using Ecommerce.Context;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
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

        public async override Task<Order> UpdateAsync(Order entity)
        {
            Order oldOrder = await _context.orders.FindAsync(entity.OrderID!);
            if (oldOrder != null && oldOrder.Status != entity.Status)
            {
                var orderItems = await _context.ordersDetails.Where(oi => oi.OrderID == entity.OrderID).ToListAsync();
                string operation = "+";

                if ((entity.Status == OrderStatus.Approved && oldOrder.Status == OrderStatus.Pending) || entity.Status == OrderStatus.Shipped)
                {
                    operation = "none";
                }
                else if (entity.Status == OrderStatus.Pending || entity.Status == OrderStatus.Approved)
                {
                    operation = "-";
                }
                else if (entity.Status == OrderStatus.Denied)
                {
                    {
                        operation = "-";
                    }
                    foreach (var item in orderItems)
                    {
                        var product = await _context.products.FindAsync(item.ProductId);
                        if (product != null)
                        {
                            product.UnitsInStock = operation == "+" ? product.UnitsInStock + item.Quantity : operation == "none" ? product.UnitsInStock : product.UnitsInStock - item.Quantity;
                            _context.products.Update(product);
                        }
                    }

                    await SaveChangesAsync();
                }
                
            }
            return await base.UpdateAsync(entity);
        }

        public IQueryable<Order> GetOrdersByStatus(OrderStatus status)
        {
            return _context.orders.Where(o => o.Status == status);
        }


    }

}
