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
    public class OrderRepo : GenericRepo<Order> , IOrderRepo
    {
        public OrderRepo(ContextDB context) : base(context)
        {
        }

        public void SaveOrder(Order order)
        {
            _dbSet.Add(order);


        }

        // comeback to save order ok ??
    }
}
