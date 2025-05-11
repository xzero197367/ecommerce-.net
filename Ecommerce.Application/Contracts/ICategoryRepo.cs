
using Ecommerce.Models;

namespace Ecommerce.Application.Contracts
{
    public interface ICategoryRepo : IGenericRepo<Category>
    {

        //public IQueryable<Category> FilterCategory(Func<Category, bool> condition);


        //Category GetByName(string name);
        IQueryable<Category> SearchCategory(string term);
        IQueryable<Category> FindCategory(Func<Category, bool> condition);
        IQueryable<Category> FindCategory(int categoryId);
        bool HasProduct(int categoryId);
        void DeleteCategory(int categoryId);
        IQueryable<Category> GetAllCategories();
    }
}
