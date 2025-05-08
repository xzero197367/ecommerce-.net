using Ecommerce.Application.Contracts;
using Ecommerce.DTOs;

namespace Ecommerce.Application.Services.CartItemServices
{
    class CartItemServices : ICartItemServices
    {
        private readonly ICartItemRepo _cartItemRepo;
        public CartItemServices(ICartItemRepo cartItemRepo)
        {
            _cartItemRepo = cartItemRepo;
        }
        void ICartItemServices.addToCartItem(CartItemCreateDto cartItem)
        {
            throw new NotImplementedException();
        }

        List<CartItemDto> ICartItemServices.getAllUserCartItems(int userId)
        {
            throw new NotImplementedException();
        }

        CartItemDto ICartItemServices.getCartItem(int cartItemId)
        {
            throw new NotImplementedException();
        }

        void ICartItemServices.removeFromCartItem(int cartItemId)
        {
            throw new NotImplementedException();
        }

        void ICartItemServices.updateCartItem(CartItemCreateDto cartItem, int cartItemId)
        {
            throw new NotImplementedException();
        }
    }
}
