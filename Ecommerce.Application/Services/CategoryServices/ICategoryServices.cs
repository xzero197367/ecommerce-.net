using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.DTOs;

namespace Ecommerce.Application.Services.CategoryServices
{
   public  interface ICategoryServices

    {

        Task<(bool status, string message)> DeleteCategoryAsync(int id);

        Task<List<CategoryDto>> GetCategoriesAsync();

        Task<CategoryDto?> GetCategoryById(int categoryId);
        Task<CategoryDto?> GetCategoryByName(string name);
        Task<CategoryDto> CreateCategoryAsync(CategoryCreateDto categoryDto);
        Task<CategoryDto> UpdateCategoryAsync(int id, CategoryCreateDto dto);
        Task<int> GetCategoryCount();
        Task<int> GetProductCountInCategory(int categoryId);
    }
}
