using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Models;

namespace Ecommerce.Application.Contracts
{
    public interface ICategoryRepo : IGenericRepo<Category>
    {
        Category GetByName(string name);
        IQueryable<Category> SearchCategory(string term);
        /* Admin shall be able to delete a product category (Consider implications: disallow if products exist).*/
        bool HasProduct(int categoryId);
        void DeleteCategory(int categoryId);
    }
}
