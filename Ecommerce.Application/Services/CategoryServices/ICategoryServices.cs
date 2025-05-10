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
        Task<CategoryDto?> GetCategoryByName(string name);
        Task<bool> CategoryHasProduct(int categoryId);
        Task<int> GetCategoryCount();
        Task<int> GetProductCountInCategory(int categoryId);
        Task SaveChanges();
    }
}
