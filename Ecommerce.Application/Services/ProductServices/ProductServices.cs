
using Ecommerce.Application.Contracts;
using Ecommerce.DTOs;
using Ecommerce.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Application.Services.ProductServices
{
   public class ProductServices : IProductServices

        
    {
        private readonly IProductRepo _productRepo;

        public ProductServices(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }


        public async Task<ProductDto> CreateProductAsync(ProductCreateDto dto)
        {
            var product = dto.Adapt<Product>();
            Product resProduct = await _productRepo.create(product);
            await _productRepo.saveChanges();
            return resProduct.Adapt<ProductDto>();
        }

        public async Task<ProductDto> UpdateProductAsync(Product product)
        {
            var existingProduct = await _productRepo.getById(product.ProductId);
            if (existingProduct == null)
                throw new Exception("Product not found");

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.UnitsInStock = product.UnitsInStock;
            existingProduct.CategoryID = product.CategoryID;
            existingProduct.ImagePath = product.ImagePath;

            await _productRepo.update(existingProduct);
            await _productRepo.saveChanges();

            return existingProduct.Adapt<ProductDto>();
        }


        public async Task DeleteProductAsync(int id)
        {
            var product = await _productRepo.getById(id);
            if (product == null)
                return;

            _productRepo.delete(product);
            await _productRepo.saveChanges();
        }

        public async Task<List<ProductDto>> GetAllProducts()
        {
            var products = await _productRepo.getAll();
            return products.Adapt<List<ProductDto>>();
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            var product = await _productRepo.getById(id);
            if (product == null)
                throw new Exception("Product not found");

            return product.Adapt<ProductDto>();
        }

        public List<ProductDto> GetProductsByCategory(int categoryId)
        {
            var products = _productRepo.GetProductByCategory(categoryId).ToList();
            return products.Adapt<List<ProductDto>>();
        }

        public List<ProductDto> SearchProducts(string keyword)
        {
            return _productRepo.SearchProduct(keyword)
                .ToList()
                .Adapt<List<ProductDto>>();
        }
    }
}
