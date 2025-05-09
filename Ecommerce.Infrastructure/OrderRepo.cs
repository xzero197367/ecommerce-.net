using Ecommerce.Application.Contracts;
using Ecommerce.Context;
using Ecommerce.DTOs;
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
        public OrderRepo(ContextDB context) : base(context)
        {
        }

        public List<Order> GetOrdersByUserId(int userId)
        {
            return _dbSet.Where(o => o.UserID == userId)
                         .OrderByDescending(o => o.OrderDate)
                         .ToList();
        }

        public List<Order> GetOrdersByStatus(OrderStatus ? orderStatus = null)
        {
            // OrderStatus? is a nullable enum type (the question mark means it can also be null).
            // = null provides a default value for status — meaning if no status is provided, it will fetch all orders.

            var orders = _dbSet
                .Include(o => o.User)
                .Include(o => o.Details)
                .AsQueryable(); 

            if (orderStatus.HasValue)
            {
                return orders.Where(o => o.Status == orderStatus.Value).ToList();
            }
            else
            {
                return orders.ToList(); // Return all orders if no status is specified.
            }

           

        }
    }


}
