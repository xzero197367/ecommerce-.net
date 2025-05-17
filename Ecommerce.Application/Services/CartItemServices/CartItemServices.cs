using Ecommerce.Application.Contracts;
using Ecommerce.Application.Services.GenericServices;
using Ecommerce.DTOs;
using Ecommerce.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ecommerce.Application.Services.CartItemServices
{
    public class CartItemServices: GenericServices<CartItemDto, CartItem>, ICartItemServices
    {
        private readonly ICartItemRepo _cartItemRepo;
        public CartItemServices(ICartItemRepo cartItemRepo): base(cartItemRepo)
        {
            _cartItemRepo = cartItemRepo;
        }

        public override async Task<List<CartItemDto>> GetAllAsync()
        {
            var items = await _cartItemRepo.GetAllAsync()
                .Include(c => c.Product).ToListAsync();

            return items.Adapt<List<CartItemDto>>();
        }

        public override async Task<List<CartItemDto>> GetWithConditionAsync(Expression<Func<CartItem, bool>> condition)
        {
            var items = await _cartItemRepo.GetWithConditionAsync(condition)
                .Include(c => c.Product).ToListAsync();
            return items.Adapt<List<CartItemDto>>();
        }
    }
}
