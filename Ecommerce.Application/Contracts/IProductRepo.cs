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
        //02 Admin shall be able to view a list of all product categories. 
        IQueryable<Product> GetProductByCategory(int categoryId);
        //08 Admin shall be able to update the details of an existing product (name, description, price, stock, category). 
        IQueryable<Product> SearchProduct(string Term);
        /*04 Admin shall be able to update the details of an existing product category.*/
        /*05 Admin shall be able to delete a product category (Consider implications: disallow if products exist). 
*/
    }

}
