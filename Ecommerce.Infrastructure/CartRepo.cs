using Ecommerce.Context;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Application.Contracts;
using Microsoft.EntityFrameworkCore;


namespace Ecommerce.Infrastructure
{
    public class CartRepo : GenericRepo<CartItem>, ICartItemRepo
    {
        #region 
        public CartRepo(ContextDB context) : base(context)
        {
        }
        #endregion


        #region
        public List<CartItem> GetCartItemsByID(int userId, List<int> cartItemsId)
        {
            return _dbSet
                .Include(ci => ci.Product) // we include product here so I can calculate the total price
                .Where(ci => ci.UserID == userId && cartItemsId.Contains(ci.CartItemID))
                .ToList();
        }
        #endregion

        #region
        public void RemoveCartItems(List<int> cartItemsId)
        {
            var cartItems = _dbSet.Where(ci => cartItemsId.Contains(ci.CartItemID)).ToList();
            _dbSet.RemoveRange(cartItems);

            SaveChanges();
        }
        #endregion

        // I changed _dbset in generic repo to public instead of private , is this right ?
        // Should I add those functions into Generic or not ? , for now let them be in CartRepo and ICartRepo
        // is save changes in remove is wrong ?
    }
}
