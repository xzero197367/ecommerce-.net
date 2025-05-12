
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
        private readonly ICategoryRepo _categoryRepo;

        public CategoryServices(ICategoryRepo categoryRepo )
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<CategoryDto> CreateCategoryAsync(CategoryCreateDto dto)
        {
            var category = dto.Adapt<Category>();
            var created = await _categoryRepo.create(category);
            await _categoryRepo.saveChanges();
            return created.Adapt<CategoryDto>();
        }


        public async Task<(bool status, string message)> DeleteCategoryAsync(int id)
        {
            var category = await _categoryRepo.getById(id);
            if (category == null)
                return (false, "Category not found.");

            if (await _categoryRepo.HasProduct(id))
                return (false, "Cannot delete category because it has related products.");

            _categoryRepo.delete(category);
            await _categoryRepo.saveChanges();

            return (true, "Category deleted successfully.");
        }





        public async Task<CategoryDto?> UpdateCategoryAsync(int id, CategoryCreateDto dto)
        {
            var existing = await _categoryRepo.getById(id);
            existing.Name = dto.Name;
            existing.Description = dto.Description;

           await _categoryRepo.update(existing);
            await _categoryRepo.saveChanges();

            return existing.Adapt<CategoryDto>();
        }

      

        public async Task<CategoryDto?> GetCategoryById(int categoryId)
        {
            var category = await _categoryRepo.getById(categoryId);
            return category?.Adapt<CategoryDto>();
        }

        public async Task<CategoryDto?> GetCategoryByName(string name)
        {
            var category = await _categoryRepo.GetByName(name);
            return category?.Adapt<CategoryDto>();
        }

        public async Task<int> GetCategoryCount()
        {
            return await _categoryRepo.GetCategoryCount();
        }

        public async Task<int> GetProductCountInCategory(int categoryId)
        {
            return await _categoryRepo.GetProductCountInCategory(categoryId);

        }

        public async Task<List<CategoryDto>> GetCategoriesAsync()
        {
            var categories = await _categoryRepo.getAll();
            return categories.Adapt<List<CategoryDto>>();

        }

    }

}
    
    
