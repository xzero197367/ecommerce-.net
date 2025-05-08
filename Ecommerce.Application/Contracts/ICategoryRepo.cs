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
        public IQueryable<Category> GetAllCategories();
        public Category GetCategoryById(int id);
        public Category UpdateCategory(Category category);
        public Category AddCategory(Category category);
        public IQueryable<Category> FilterCategory(Func<Category, bool> condition);


        Category GetByName(string name);
        IQueryable<Category> SearchCategory(string term);
        bool HasProduct(int categoryId);
        void DeleteCategory(int categoryId);
    }
}
