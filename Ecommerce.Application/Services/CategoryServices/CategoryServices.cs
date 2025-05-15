


using Ecommerce.Application.Contracts;
using Ecommerce.Application.Services.GenericServices;
using Ecommerce.DTOs;
using Ecommerce.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Application.Services.CategoryServices
{
   public class CategoryServices: GenericServices<CategoryDto, CategoryCreateDto, Category> ,ICategoryServices
         
    {
        private readonly ICategoryRepo _categoryRepo;

        public CategoryServices(ICategoryRepo categoryRepo ): base(categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public override async Task<List<CategoryDto>> GetAllAsync()
        {
            var items = await _categoryRepo.GetAllAsync().Select(c=>new CategoryDto()
            {
                CategoryId = c.CategoryId,
                Name = c.Name,
                Description = c.Description,
                ProductCount = c.Products.Count()
            }).ToListAsync();
            if (items == null)
                return null;
            return items;
        }

    }

}
    
    
