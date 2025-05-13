using Ecommerce.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services.CartItemServices
{
    public interface ICartItemServices
    {
        public CartItemDto addToCartItem(CartItemCreateDto cartItem);
        public Task<(bool status, string message)> removeFromCartItem(int cartItemId);
        public Task<CartItemDto> updateCartItem(CartItemCreateDto cartItem, int cartItemId);
        public CartItemDto getCartItem(int cartItemId);
        public List<CartItemDto> getAllUserCartItems(int userId);


    }
}
