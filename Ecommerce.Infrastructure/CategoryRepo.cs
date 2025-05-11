using Ecommerce.Application.Contracts;
using Ecommerce.Context;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure
{
    public class CategoryRepo : GenericRepo<Category>, ICategoryRepo
    {
        private readonly ContextDB _context;
        private readonly DbSet<Category> _dbset;

        public CategoryRepo(ContextDB context) : base(context)
        {
            _context = context;
            _dbset = context.Set<Category>();
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
    
        public IQueryable<Category> GetAllCategories()
        {
            return _dbset;
        }

        IQueryable<Category> ICategoryRepo.FindCategory(Func<Category, bool> condition)
        {
            return _dbset.Where(condition).AsQueryable();
        }

        IQueryable<Category> ICategoryRepo.FindCategory(int categoryId)
        {
            return _dbset.Where(c => c.CategoryId == categoryId).AsQueryable();
        }
    }
}
