

using Autofac;
using Ecommerce.AdminFront.Classes.AutoFac;
using Ecommerce.Application.Services.CategoryServices;
using Ecommerce.DTOs;

namespace Ecommerce.AdminFront.Pages.Categories
{
    class CategoryHandler
    {
        private readonly ICategoryServices _categoryService;
        public CategoryHandler()
        {
            var container = AutoFac.Inject();
            _categoryService = container.Resolve<ICategoryServices>();

        }

        public async Task<(bool status, string message)> DeleteCategory(int id)
        {
            try
            {
                var res = await _categoryService.DeleteCategoryAsync(id);
                return res;
            }
            catch (Exception ex)
            {
                return (false, "something went wrong");
            }
        }

        public async Task<bool> CreateCategory(CategoryCreateDto dto)
        {
            try
            {
                await _categoryService.CreateCategoryAsync(dto);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<CategoryDto>> GetCategories()
        {
            return  await _categoryService.GetCategoriesAsync();
        }

    }
}
