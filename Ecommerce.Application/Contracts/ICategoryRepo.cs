
using Ecommerce.Models;

namespace Ecommerce.Application.Contracts
{
    public interface ICategoryRepo : IGenericRepo<Category>
    {

        //public IQueryable<Category> FilterCategory(Func<Category, bool> condition);


        //Category GetByName(string name);
        IQueryable<Category> SearchCategory(string term);
        bool HasProduct(int categoryId);
        void DeleteCategory(int categoryId);
    }
}
