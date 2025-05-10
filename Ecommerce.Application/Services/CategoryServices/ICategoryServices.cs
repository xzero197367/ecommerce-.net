using Ecommerce.DTOs;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services.CategoryServices
{
    public interface ICategoryServices

    {
        Task<CategoryDto?> GetCategoryById(int categoryId);
        Task<CategoryDto?> GetCategoryByName(string name);
        Task<CategoryDto> CreateCategory(CategoryCreateDto categoryDto);
        Task<CategoryDto> UpdateCategory(int categoryId, CategoryCreateDto categoryDto);
        Task<CategoryDto?> DeleteCategory(int categoryId);
        Task<int> GetCategoryCount();
        Task<int> GetProductCountInCategory(int categoryId);
        Task SaveChanges();
    }
}
