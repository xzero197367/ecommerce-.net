

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

        public ICategoryServices CategoryService => _categoryService;


        public async Task<(bool status, string message)> DeleteCategory(int id)
        {
            try
            {
                var res = await _categoryService.DeleteAsync(id);
                return (res, res ? "Category deleted successfully" : "something went wrong");
            }
            catch (Exception ex)
            {
                return (false, "something went wrong");
            }
        }

        public async Task<(bool status, string message)> onUpdateCategory(CategoryDto category)
        {
            
            var res = await _categoryService.UpdateAsync(category);

            if (res == null)
            {
                return (false, "something went wrong");
            }
            return (true, "Category updated successfully");
        }

        public async Task<(bool status, string message)> CreateCategory(CategoryDto dto)
        {
            try
            {
               await _categoryService.AddAsync(dto);
               return (true, "Category created successfully");
            }
            catch (Exception ex)
            {
                return (false, "something went wrong");
            }
        }

        public async Task<List<CategoryDto>> GetCategories()
        {
            return  await _categoryService.GetAllAsync();
        }

    }
}
