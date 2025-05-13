using Ecommerce.Application.Contracts;
using Ecommerce.DTOs;
using Ecommerce.Models;
using Mapster;

namespace Ecommerce.Application.Services.CartItemServices
{
    class CartItemServices : ICartItemServices
    {
        private readonly ICartItemRepo _cartItemRepo;
        public CartItemServices(ICartItemRepo cartItemRepo)
        {
            _cartItemRepo = cartItemRepo;
        }
        CartItemDto ICartItemServices.addToCartItem(CartItemCreateDto cartItem)
        {
            CartItem cart = cartItem.Adapt<CartItem>();
            cart.DateAdded = DateTime.Now;
            var result = _cartItemRepo.create(cart);
            if (result == null)
            {
                throw new Exception("Failed to add cart item");
            }
            
            return result.Adapt<CartItemDto>();

        }

        List<CartItemDto> ICartItemServices.getAllUserCartItems(int userId)
        {
            throw new NotImplementedException();
        }

        CartItemDto ICartItemServices.getCartItem(int cartItemId)
        {
            throw new NotImplementedException();
        }

        async Task<(bool status, string message)> ICartItemServices.removeFromCartItem(int cartItemId)
        {
           var cartItem = await _cartItemRepo.getById(cartItemId);
            if (cartItem == null)
            {
                return (false, "Cart item not found");
            }
            var result = await _cartItemRepo.delete(cartItem);

            return (true, "Cart item deleted successfully");
        }

        async Task<CartItemDto> ICartItemServices.updateCartItem(CartItemCreateDto cartItem, int cartItemId)
        {
            var existingCartItem = await _cartItemRepo.getById(cartItemId);
            if (existingCartItem == null)
            {
                throw new Exception("Cart item not found");
            }
            existingCartItem.Quantity = cartItem.Quantity;
            existingCartItem.UserID = cartItem.UserID;
            existingCartItem.ProductID = cartItem.ProductID;

            var updatedCartItem = await _cartItemRepo.update(existingCartItem);
            if (updatedCartItem == null)
            {
                throw new Exception("Failed to update cart item");
            }
            return new CartItemDto
            {
                CartItemID = updatedCartItem.CartItemID,
                UserID = updatedCartItem.UserID,
                ProductID = updatedCartItem.ProductID,
                Quantity = updatedCartItem.Quantity,
                DateAdded = updatedCartItem.DateAdded
            };
        }
    }
}
