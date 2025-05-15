using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Ecommerce.Application.Contracts;
using Ecommerce.Application.Services.GenericServices;
using Ecommerce.DTOs;
using Ecommerce.Models;
using Mapster;

namespace Ecommerce.Application.Services.OrderServices
{
    public class OrderServices: GenericServices<OrderDto, OrderCreateDto, Order>, IOrderServices
    {
        private readonly IOrderRepo orderRepo;

        public OrderServices(IOrderRepo orderRepo): base(orderRepo)
        {
            this.orderRepo = orderRepo;
        }

       
    }
}

