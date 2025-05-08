
using Ecommerce.Models;

namespace Ecommerce.Application.Contracts
{
   public interface IOrderDetailRepo : IGenericRepo<OrderDetail>
    {
        //public Task<OrderDetail> GetOrderDetailById(int id);
        //public Task<IEnumerable<OrderDetail>> GetOrderDetailsByOrderId(int orderId);
    }
   
}
