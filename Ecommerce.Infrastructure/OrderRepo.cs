using Ecommerce.Application.Contracts;
using Ecommerce.Context;
using Ecommerce.DTOs;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure
{
    public class OrderRepo : GenericRepo<Order> , IOrderRepo
    {
        public OrderRepo(ContextDB context) : base(context)
        {
        }

        public List<Order> GetOrdersByUserId(int userId)
        {
           return  _dbSet.Where(o => o.UserID == userId)
                          .OrderByDescending(o => o.OrderDate)
                          .ToList();
            
        }

       
    }
}
