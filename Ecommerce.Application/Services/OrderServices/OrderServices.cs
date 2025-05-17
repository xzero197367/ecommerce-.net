
using Ecommerce.Application.Contracts;
using Ecommerce.Application.Services.GenericServices;
using Ecommerce.DTOs;
using Ecommerce.Models;
using Mapster;

namespace Ecommerce.Application.Services.OrderServices
{
    public class OrderServices: GenericServices<OrderDto, Order>, IOrderServices
    {
        private readonly IOrderRepo orderRepo;

        public OrderServices(IOrderRepo orderRepo): base(orderRepo)
        {
            this.orderRepo = orderRepo;
        }

       
    }
}

