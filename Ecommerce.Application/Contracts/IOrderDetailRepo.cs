
using Ecommerce.Models;

namespace Ecommerce.Application.Contracts
{
   public interface IOrderDetailRepo : IGenericRepo<OrderDetails>
    {
        //public Task<OrderDetail> GetOrderDetailById(int id);
        //public Task<IEnumerable<OrderDetail>> GetOrderDetailsByOrderId(int orderId);
    }
   
}
