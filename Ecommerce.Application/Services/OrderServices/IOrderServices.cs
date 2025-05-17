
using Ecommerce.Application.Services.GenericServices;
using Ecommerce.DTOs;
using Ecommerce.Models;

namespace Ecommerce.Application.Services.OrderServices
{
    public interface IOrderServices: IGenericService<OrderDto, Order>
    {
       
    }
}
