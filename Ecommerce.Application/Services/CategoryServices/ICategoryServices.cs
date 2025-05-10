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
        Task CreateCategoryAsync(CategoryCreateDto dto);

        Task<List<CategoryDto>> GetCategoriesAsync();
    }
}
