using Autofac;
using Ecommerce.AdminFront.Classes.AutoFac;
using Ecommerce.Application.Services.CartItemServices;
using Ecommerce.DTOs;
using System;


namespace Ecommerce.AdminFront.Pages.CartItems
{
    public class CartItemHandler
    {
        private ICartItemServices _cartItemServices;
        private CartItemHandler()
        {
            var container = AutoFac.Inject();
            _cartItemServices = container.Resolve<ICartItemServices>();
        }

        private static CartItemHandler? _instance;

        public static CartItemHandler GetInstance()
        {
            return _instance ??= new CartItemHandler();
        }

        public async Task<List<CartItemDto>> GetCartItemsByUserId(int userId)
        {
            return await _cartItemServices.GetCartItemsByUserId(userId);
        }

        public async Task<(bool status, string message)> RemoveCartItem(int cartItemId)
        {
            var res = await _cartItemServices.RemoveCartItem(cartItemId);
            return (res, res ? "Item removed successfully" : "Failed to remove item");
        }

        public async Task<(bool status, string message)> AddOrUpdate(CartItemDto dto)
        {
            var res = await _cartItemServices.AddOrUpdate(dto);
            return (res, res ? "Item added/updated successfully" : "Failed to add/update item");
        }

        public async Task<(bool status, string message)> UpdateQuantity(int cartItemId, int quantity)
        {
            var res = await _cartItemServices.UpdateQuantity(cartItemId, quantity);
            return (res, res ? "Quantity updated successfully" : "Failed to update quantity");
        }
    }
}
