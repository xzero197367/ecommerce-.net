

using Autofac;
using Ecommerce.AdminFront.Classes.AutoFac;
using Ecommerce.Application.Services.CategoryServices;
using Ecommerce.DTOs;

namespace Ecommerce.AdminFront.Pages.Categories
{
    class CategoryHandler
    {
        private readonly ICategoryServices _categoryService;
        private CategoryHandler()
        {
            var container = AutoFac.Inject();
            _categoryService = container.Resolve<ICategoryServices>();
        }

        private static CategoryHandler? _instance;

        public static CategoryHandler GetInstance()
        {
            if(_instance == null)
            {
                _instance = new CategoryHandler();
            }
            return _instance;
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

        public async Task<(bool status, string message)> onUpdateCategory(int id, CategoryCreateDto dto)
        {
            var res = await _categoryService.UpdateCategoryAsync(id, dto);

            if (res == null)
            {
                return (false, "something went wrong");
            }
            return (true, "Category updated successfully");
        }

        public async Task<(bool status, string message)> CreateCategory(CategoryCreateDto dto)
        {
            try
            {
               await _categoryService.CreateCategoryAsync(dto);
               return (true, "Category created successfully");
            }
            catch (Exception ex)
            {
                return (false, "something went wrong");
            }
        }

        public async Task<List<CategoryDto>> GetCategories()
        {
            return  await _categoryService.GetCategoriesAsync();
        }

    }
}
