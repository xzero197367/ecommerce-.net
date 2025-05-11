
using Ecommerce.Application.Contracts;
using Ecommerce.Context;
using Ecommerce.DTOs;
using Ecommerce.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Application.Services.CategoryServices
{
   public class CategoryServices : ICategoryServices
         
    {
        private readonly ICategoryRepo _categoryRepo;

        public CategoryServices(ICategoryRepo categoryRepo )
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<CategoryDto> CreateCategoryAsync(CategoryCreateDto dto)
        {
            var category = dto.Adapt<Category>(); // Mapster
            Category resCategory = await _categoryRepo.CreateAsync(category);
            await _categoryRepo.SaveChangesAsync();
            return resCategory.Adapt<CategoryDto>();
        }

        public async Task<List<CategoryDto>> GetCategoriesAsync()
        {
            List<Category> categories = await _categoryRepo.GetAllCategories().ToListAsync();

            return categories.Adapt<List<CategoryDto>>(); // Mapster
                //.Include(c => c.Products) 
                //.Select(c => new CategoryDto
                //{
                //    CategoryId = c.CategoryId,
                //    Name = c.Name,
                //    Description = c.Description,
                //    Products = c.Products.Select(p => new ProductDto
                //    {
                //        ProductId = p.ProductId,
                //        Name = p.Name
                //    }).ToList()
                //})
                //.ToListAsync();
        }

        async Task<(bool status, string message)> ICategoryServices.DeleteCategoryAsync(int id)
        {
            try
            {
                Category category = await _categoryRepo.FindCategory(id).Include(c=>c.Products).FirstOrDefaultAsync();
                if(category == null)
                {
                    return (false, "Deleted successfully");
                }else if(category.Products.Count > 0)
                {
                    return (false, "this category has products, delete them first");
                }
                _categoryRepo.DeleteCategory(id);

                return (true, "Deleted successfully");
            }
            catch
            {
                return (false, "deleted failed");
            }
        }

        Task<CategoryDto> ICategoryServices.UpdateCategoryAsync(int id, CategoryCreateDto dto)
        {
            throw new NotImplementedException();
        }
    }
    
}
