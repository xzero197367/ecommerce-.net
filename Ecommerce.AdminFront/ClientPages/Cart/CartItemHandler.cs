using Autofac;
using Ecommerce.AdminFront.Classes.AutoFac;
using Ecommerce.Application.Services.CartItemServices;
using Ecommerce.DTOs;
using Ecommerce.Models;
using System;
using System.Linq.Expressions;


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
                var res = await cartItemServices.DeleteAsync(id);
                return (res, res ? "CartItem deleted successfully" : "something went wrong");
            }
            catch (Exception ex)
            {
                return (false, "something went wrong");
            }
        }

        public async Task<(bool status, string message)> onUpdateCartItem(CartItemDto dto)
        {
            
            var res = await cartItemServices.UpdateAsync(dto);

            if (res == null)
            {
                return (false, "something went wrong");
            }
            return (true, "CartItem updated successfully");
        }

        public async Task<(bool status, string message)> CreateCartItem(CartItemDto dto)
        {
            try
            {
                await cartItemServices.AddAsync(dto);
                return (true, "CartItem created successfully");
            }
            catch (Exception ex)
            {
                return (false, $"${ex.Message}");
            }
        }

        public async Task<List<CartItemDto>> GetCartItems()
        {
            return await cartItemServices.GetWithConditionAsync((cartItem)=>cartItem.UserID == MainWindowEntry.currentUser.UserID);
        }

        public async Task<bool> DeleteWithCondition(Expression<Func<CartItem, bool>> condition)
        {
            return await cartItemServices.DeleteWithConditionAsync(condition);
        }


    }
}
