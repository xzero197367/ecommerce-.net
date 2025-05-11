using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.DTOs;
using Ecommerce.Models;

namespace Ecommerce.Application.Services.OrderServices
{
    public interface IOrderServices
    {
       
        Task<OrderCreateDto> CreateOrderAsync(OrderCreateDto dto);

      
        Task<List<OrderDto>> GetAllOrdersAsync();
        Task<OrderDto?> GetOrderByIdAsync(int orderId);


        Task<OrderDto> UpdateOrderAsync(int orderId, OrderDto dto);         
        Task UpdateOrderStatusAsync(int orderId, OrderStatus status);   

       
        Task DeleteOrderAsync(int orderId);
    }
}
