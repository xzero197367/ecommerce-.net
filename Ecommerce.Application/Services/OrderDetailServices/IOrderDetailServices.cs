using Ecommerce.Application.Services.GenericServices;
using Ecommerce.DTOs;
using Ecommerce.Models;

namespace Ecommerce.Application.Services.OrderDetailServices
{
    interface IOrderDetailServices: IGenericService<OrderDetailDto, OrderDetail>
    {
    }
}
