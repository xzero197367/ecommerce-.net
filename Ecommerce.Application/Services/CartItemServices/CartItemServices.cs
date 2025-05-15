using Ecommerce.Application.Contracts;
using Ecommerce.Application.Services.GenericServices;
using Ecommerce.DTOs;
using Ecommerce.Models;
using Mapster;

namespace Ecommerce.Application.Services.CartItemServices
{
    class CartItemServices: GenericServices<CartItemDto, CartItemCreateDto, CartItem>, ICartItemServices
    {
        private readonly ICartItemRepo _cartItemRepo;
        public CartItemServices(ICartItemRepo cartItemRepo): base(cartItemRepo)
        {
            _cartItemRepo = cartItemRepo;
        }
        
    }
}
