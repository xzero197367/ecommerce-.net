
using Ecommerce.Models;

namespace Ecommerce.Application.Contracts
{
    public interface ICategoryRepo : IGenericRepo<Category>
    {

        Task<Category?> GetByName(string name);
        Task<bool> HasProduct(int categoryId);
        Task DeleteCategory(int categoryId);
        Task<int> GetCategoryCount();
        Task<int> GetProductCountInCategory(int categoryId);  
    }
}
