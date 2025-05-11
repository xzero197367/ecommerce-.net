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
        Task<CategoryDto> CreateCategoryAsync(CategoryCreateDto dto);

        Task<CategoryDto> UpdateCategoryAsync(int id, CategoryCreateDto dto);

        Task<(bool status, string message)> DeleteCategoryAsync(int id);

        Task<List<CategoryDto>> GetCategoriesAsync();
    }
}
