using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private readonly IGenericRepo<Category> _categoryRepo;

        private readonly ContextDB _context;
        public CategoryServices(IGenericRepo<Category> categoryRepo ,  ContextDB context)
        {
            _categoryRepo = categoryRepo;
            _context = context;
        }

        public async Task CreateCategoryAsync(CategoryCreateDto dto)
        {
            var category = dto.Adapt<Category>(); // Mapster
            await _categoryRepo.CreateAsync(category);
            await _categoryRepo.SaveChangesAsync();

        }

        public async Task<List<CategoryDto>> GetCategoriesAsync()
        {
            return await _context.categories
                .Include(c => c.Products) 
                .Select(c => new CategoryDto
                {
                    CategoryId = c.CategoryId,
                    Name = c.Name,
                    Description = c.Description,
                    Products = c.Products.Select(p => new ProductDto
                    {
                        ProductId = p.ProductId,
                        Name = p.Name
                    }).ToList()
                })
                .ToListAsync();
        }
    }
    
}
