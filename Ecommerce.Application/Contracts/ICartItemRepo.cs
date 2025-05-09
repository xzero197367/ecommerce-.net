using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Models;

namespace Ecommerce.Application.Contracts
{
   public interface ICartItemRepo : IGenericRepo<CartItem>
    {
        List<CartItem> GetCartItemsByID(int userId, List<int> cartItemsId);
        void RemoveCartItems(List<int> cartItemsId);


    }
}
