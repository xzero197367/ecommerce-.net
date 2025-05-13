using Autofac;
using Ecommerce.AdminFront.Classes.AutoFac;
using Ecommerce.Application.Services.CartItemServices;
using Ecommerce.DTOs;
using System;


namespace Ecommerce.AdminFront.Pages.CartItems
{
    public class CartItemHandler
    {
        private ICartItemServices cartItemServices;
        private CartItemHandler()
        {
            var container = AutoFac.Inject();
            cartItemServices = container.Resolve<ICartItemServices>();
        }

        private static CartItemHandler? _instance;

        public static CartItemHandler GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CartItemHandler();
            }
            return _instance;
        }


        public async Task<(bool status, string message)> DeleteCartItem(int id)
        {
            try
            {
                var res = await cartItemServices.removeFromCartItem(id);
                return res;
            }
            catch (Exception ex)
            {
                return (false, "something went wrong");
            }
        }

        public async Task<(bool status, string message)> onUpdateCartItem(int id, CartItemCreateDto dto)
        {
            var res = await cartItemServices.updateCartItem(dto, id);

            if (res == null)
            {
                return (false, "something went wrong");
            }
            return (true, "CartItem updated successfully");
        }

        public async Task<(bool status, string message)> CreateCartItem(CartItemCreateDto dto)
        {
            try
            {
                cartItemServices.addToCartItem(dto);
                return (true, "CartItem created successfully");
            }
            catch (Exception ex)
            {
                return (false, $"${ex.Message}");
            }
        }

        public async Task<List<CartItemDto>> GetCartItems()
        {
            return cartItemServices.getAllUserCartItems(MainWindowEntry.currentUser.UserID);
        }


    }
}
