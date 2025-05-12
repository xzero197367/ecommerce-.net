using Ecommerce.Application.Contracts;
using Ecommerce.Context;
using Ecommerce.Models;

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
