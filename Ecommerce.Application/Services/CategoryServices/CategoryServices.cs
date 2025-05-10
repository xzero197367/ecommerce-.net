using Ecommerce.Application.Contracts;
using Ecommerce.DTOs;
using Ecommerce.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services.CategoryServices
{
    class CategoryServices:ICategoryServices
    {
        private readonly ICategoryRepo _categoryRepo;

        public CategoryServices(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<CategoryDto> CreateCategory(CategoryCreateDto categoryDto)
        {
            var category = categoryDto.Adapt<Category>();
            var created = _categoryRepo.create(category);
            await _categoryRepo.saveChanges();
            return created.Adapt<CategoryDto>();
        }

        public async Task<CategoryDto?> UpdateCategory(int categoryId, CategoryCreateDto categoryDto)
        {
            var existing = await _categoryRepo.getById(categoryId);
            existing.Name = categoryDto.Name;
            existing.Description = categoryDto.Description;

            _categoryRepo.update(existing);
            await _categoryRepo.saveChanges();

            return existing.Adapt<CategoryDto>();
        }

        public async Task<CategoryDto?> DeleteCategory(int categoryId)
        {
            var category = await _categoryRepo.getById(categoryId);
            if (await _categoryRepo.HasProduct(categoryId))
                return null;
            _categoryRepo.delete(category);
            await _categoryRepo.saveChanges();
            return category.Adapt<CategoryDto>();
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



        public async Task<bool> CategoryHasProduct(int categoryId)
        {
            return await _categoryRepo.HasProduct(categoryId);
        }

        public async Task<int> GetCategoryCount()
        {
            return await _categoryRepo.GetCategoryCount();
        }

        public async Task<int> GetProductCountInCategory(int categoryId)
        {
            return await _categoryRepo.GetProductCountInCategory(categoryId);

        }

        public async Task SaveChanges()
        {
            await _categoryRepo.saveChanges();
        }
    }
}