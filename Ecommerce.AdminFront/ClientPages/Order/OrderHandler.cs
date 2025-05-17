

using Autofac;
using Ecommerce.AdminFront.Classes.AutoFac;
using Ecommerce.AdminFront.Pages.CartItems;
using Ecommerce.AdminFront.Pages.Products;
using Ecommerce.Application.Services.OrderServices;
using Ecommerce.DTOs;
using Ecommerce.Models;
using Wpf.Ui.Controls;

namespace Ecommerce.AdminFront.ClientPages.Order
{
    public class OrderHandler
    {
        private CartItemHandler cartItemHandler = CartItemHandler.GetInstance();
        private ProductHandler productHandler = ProductHandler.GetInstance();
        private readonly IOrderServices orderServices;
        public static OrderHandler Instance { get; } = new OrderHandler();


        private OrderHandler()
        {
            var container = AutoFac.Inject();
            orderServices = container.Resolve<IOrderServices>();
        }

        public async Task<List<OrderDto>> GetAllOrders()
        {
            return await orderServices.GetWithConditionAsync(o=>o.UserID == MainWindowEntry.currentUser.UserID);
        }

        public async Task<OrderDto> CreateOrder()
        {
            OrderDto order = new OrderDto();
            order.UserID = MainWindowEntry.currentUser.UserID;
            order.OrderDate = DateTime.Now;
            order.TotalAmount = MainWindowEntry.cartItems.Sum(item => item.Quantity * item.Product.Price);
            order.Status = OrderStatus.Pending;
            order.Details = new List<OrderDetailDto>();
            order.Details.AddRange(
                MainWindowEntry.cartItems.Select(item => new OrderDetailDto() { 
                    ProductId = item.ProductID, Quantity = item.Quantity}
                )
            );
            OrderDto result = await orderServices.AddAsync(order);
            if(result != null)
            {
                
                await cartItemHandler.DeleteWithCondition(
                    o=>o.UserID == MainWindowEntry.currentUser.UserID);
                await productHandler.UpdateProductAsync(MainWindowEntry.cartItems.Select(
                    item=>
                    {
                        var product = item.Product;
                        product.UnitsInStock -= item.Quantity;
                        return product;
                    }
                    ).ToList());
                
                MainWindowEntry.cartItems = new List<CartItemDto>();
            }
            return result;
        }

        public async Task<OrderDto> UpdateOrder(OrderDto order)
        {
            return await orderServices.UpdateAsync(order);
        }

        public async Task<bool> DeleteOrder(int id)
        {
            return await orderServices.DeleteAsync(id);
        }
    }
}
