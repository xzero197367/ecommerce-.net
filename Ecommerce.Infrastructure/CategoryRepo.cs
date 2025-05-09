using Ecommerce.Application.Contracts;
using Ecommerce.Context;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure
{
    public class CategoryRepo : GenericRepo<Category>, ICategoryRepo
    {
        private readonly ContextDB _context;

        public CategoryRepo(ContextDB context) : base(context)
        {
            _context = context;
        }

        public void DeleteCategory(int categoryId)
        {
            var category = _context.categories.Find(categoryId);

            if (!HasProduct(categoryId))
            {
                _context.categories.Remove(category);
                _context.SaveChanges();
            }
        }

        //public Category GetByName(string name)
        //{
        //    throw new NotImplementedException();
        //}

        public bool HasProduct(int categoryId)
        {
            return _context.products.Any(p => p.CategoryID == categoryId);
        }

        public IQueryable<Category> SearchCategory(string term)
        {
            return _context.categories.Where(c => c.Name.Contains(term)
            || c.Description.Contains(term));
        }

        //Category ICategoryRepo.AddCategory(Category category)
        //{
        //    return null;
        //}

        //IQueryable<Category> ICategoryRepo.FilterCategory(Func<Category, bool> condition)
        //{
        //    return null;
        //}

        //IQueryable<Category> ICategoryRepo.GetAllCategories()
        //{
        //    return null;
        //}

        //Category ICategoryRepo.GetCategoryById(int id)
        //{
        //    return null;
        //}

        //Category ICategoryRepo.UpdateCategory(Category category)
        //{
        //    return null;
        //}
    }
}
