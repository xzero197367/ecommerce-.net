using Ecommerce.Application.Contracts;
using Ecommerce.Context;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure
{
    public class CategoryRepo : GenericRepo<Category>, ICategoryRepo
    {
        private readonly ContextDB _context;

        public CategoryRepo(ContextDB context) : base(context)
        {
            _context = context;
        }

        public async Task<Category?> GetByName(string name)
        {
            return await _context.categories.FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task<bool> HasProduct(int categoryId)
        {
            return await _context.products.AnyAsync(p => p.CategoryID == categoryId);
        }

        public async Task DeleteCategory(int categoryId)
        {
            var category = await _context.categories.FindAsync(categoryId);
            if (!await HasProduct(categoryId))
            {
                _context.categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> GetCategoryCount()
        {
            return await _context.categories.CountAsync();
        }

        public async Task<int> GetProductCountInCategory(int categoryId)
        {
            return await _context.products.CountAsync(p => p.CategoryID == categoryId);
        }

       
    }
}
    
