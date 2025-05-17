using Ecommerce.Application.Contracts;
using Ecommerce.Application.Services.GenericServices;
using Ecommerce.DTOs;
using Ecommerce.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Application.Services.CartItemServices
{
   public class CartItemServices: GenericServices<CartItemDto, CartItemCreateDto, CartItem>, ICartItemServices
    {
        private readonly ICartItemRepo _cartItemRepo;
        public CartItemServices(ICartItemRepo cartItemRepo) : base(cartItemRepo)
        {
            _cartItemRepo = cartItemRepo;
        }
        public async Task<bool> AddOrUpdate(CartItemDto cartItemDto)
        {
            var existingItem = await _cartItemRepo
                .GetWithConditionAsync(c => c.UserID == cartItemDto.UserID && c.ProductID == cartItemDto.ProductID)
                .FirstOrDefaultAsync();
            if (existingItem != null)
            {
              existingItem.Quantity = cartItemDto.Quantity;
              _cartItemRepo.UpdateAsync(existingItem);
            }
            else
            {
                var newItem = cartItemDto.Adapt<CartItem>();
                await _cartItemRepo.AddAsync(newItem);
            }
            return await _cartItemRepo.SaveChangesAsync();

        }

        public async Task<List<CartItemDto>> GetCartItemsByUserId(int userId)
        {
            var items = await _cartItemRepo
                .GetWithConditionAsync(c => c.UserID == userId)
            .Include(c => c.Product)
             .Include(c => c.User)
                .ToListAsync();
            return items.Adapt<List<CartItemDto>>();

        }

        public async Task<bool> RemoveCartItem(int cartItemId)
        {
            var item = await _cartItemRepo.GetByIdAsync(cartItemId);
            if (item == null)
                return false;

            await _cartItemRepo.DeleteAsync(cartItemId);
            return await _cartItemRepo.SaveChangesAsync();
        }

        public async Task<bool> UpdateQuantity(int cartItemId, int newQuantity)
        {
            var item = await _cartItemRepo.GetByIdAsync(cartItemId);
            if (item == null)
                return false;

            item.Quantity = newQuantity;
            _cartItemRepo.UpdateAsync(item);
            return await _cartItemRepo.SaveChangesAsync();
        }
    }
}
