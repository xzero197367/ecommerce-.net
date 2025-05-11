using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Models;

namespace Ecommerce.Application.Contracts
{
   public interface IProductRepo : IGenericRepo<Product>
    {
        IQueryable<Product> GetProductByCategory(int categoryId);
        IQueryable<Product> SearchProduct(string Term);

    }

}
