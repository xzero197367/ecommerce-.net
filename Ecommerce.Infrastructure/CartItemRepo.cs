using Ecommerce.Context;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure
{
    public class CartItemRepo:GenericRepo<CartItem>
    {
        private readonly ContextDB _context;

        public CartItemRepo(ContextDB context) : base(context)
        {
            _context = context;
        }

    }
}
