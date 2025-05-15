using Ecommerce.Application.Contracts;
using Ecommerce.Application.Services.GenericServices;
using Ecommerce.DTOs;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services.OrderDetailServices
{
    class OrderDetailServices:GenericServices<OrderDetailsDto, OrderDetailsCreateDto, OrderDetail>, IOrderDetailServices
    {

        private readonly IOrderDetailRepo orderDetailRepo;

        public OrderDetailServices(IOrderDetailRepo orderDetailRepo) : base(orderDetailRepo)
        {
            this.orderDetailRepo = orderDetailRepo;
        }
    }
}
