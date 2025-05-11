using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Ecommerce.Application.Contracts;
using Ecommerce.DTOs;
using Ecommerce.Models;
using Mapster;

namespace Ecommerce.Application.Services.OrderServices
{
    public class OrderServices : IOrderServices
    {
        private readonly IGenericRepo<Order> _orderRepo;

        public OrderServices(IGenericRepo<Order> orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public async Task<OrderCreateDto> CreateOrderAsync(OrderCreateDto dto)
        {
            var order = dto.Adapt<Order>();

            var createdOrder = await _orderRepo.create(order);
            await _orderRepo.saveChanges();
            return createdOrder.Adapt<OrderCreateDto>();
        }

        public async Task<OrderDto> UpdateOrderAsync(int orderId, OrderDto dto)
        {
            var existingOrder = await _orderRepo.getById(orderId);
            if (existingOrder == null) throw new Exception("order not found");
            existingOrder.OrderID = dto.OrderID;
            existingOrder.Status = dto.Status;
            await _orderRepo.update(existingOrder);
            await _orderRepo.saveChanges();
            return existingOrder.Adapt<OrderDto>();
        }

        public async Task<OrderDto> GetOrderByIdAsync(int orderId)
        {
            var order = await _orderRepo.getById(orderId);
            if (order == null) throw new Exception("order not found");
            return order.Adapt<OrderDto>();
        }

        public async Task<List<OrderDto>> GetAllOrdersAsync()
        {
            var orders = await _orderRepo.getAll();
            return orders.Adapt<List<OrderDto>>();
        }

        public async Task UpdateOrderStatusAsync(int orderId, OrderStatus status)
        {
            var order = await _orderRepo.getById(orderId);
            if (order == null) throw new Exception("order not found");

            order.Status = status;
            order.DateProcessed = DateTime.Now;

            await _orderRepo.saveChanges();
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            var order = await _orderRepo.getById(orderId);
            if (order == null) throw new Exception("order not found");

            await _orderRepo.delete(order);
            await _orderRepo.saveChanges();
        }
    }
}

