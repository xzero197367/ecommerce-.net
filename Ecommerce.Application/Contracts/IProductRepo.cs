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
        // Add any additional methods specific to Product repository if needed
        // For example:
        // IEnumerable<Product> GetProductsByCategory(int categoryId);
        // IEnumerable<Product> SearchProducts(string searchTerm);
    }
    
}
