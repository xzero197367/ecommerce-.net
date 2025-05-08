
using Ecommerce.Models;

namespace Ecommerce.Application.Contracts
{
   public interface ICartItemRepo : IGenericRepo<CartItem>

    {
        IQueryable<CartItem> GetCartItemsByUserId(int userId);


    }
}
