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
    public class OrderDetailsRepo : GenericRepo<OrderDetail>, IOrderDetailRepo
    {
        private readonly ContextDB _context;

        public OrderDetailsRepo(ContextDB context) : base(context)
        {
            _context = context;
        }
    }
}
