using Ecommerce.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services.CartItemServices
{
    interface ICartItemServices
    {
        public void addToCartItem(CartItemCreateDto cartItem);
        public void removeFromCartItem(int cartItemId);
        public void updateCartItem(CartItemCreateDto cartItem, int cartItemId);
        public CartItemDto getCartItem(int cartItemId);
        public List<CartItemDto> getAllUserCartItems(int userId);


    }
}
