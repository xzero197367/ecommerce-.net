
using Ecommerce.Application.Contracts;
using Ecommerce.DTOs;
using Ecommerce.Models;
using Mapster;

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
            Product resProduct = await _productRepo.CreateAsync(product);
            await _productRepo.SaveChangesAsync();
            return resProduct.Adapt<ProductDto>();
        }

        public ProductDto UpdateProduct(Product product)
        {
            var existingProduct = _productRepo.getById(product.ProductId) ?? throw new Exception("Product not found");
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.UnitsInStock = product.UnitsInStock;
            existingProduct.CategoryID = product.CategoryID;
            existingProduct.ImagePath = product.ImagePath;

            var updatedProduct = _productRepo.update(existingProduct);
            _productRepo.saveChanges();
            return updatedProduct.Adapt<ProductDto>();
        }

        public void DeleteProduct(int id)
        {
            var product = _productRepo.getById(id) ?? throw new Exception("Product not found");
            _productRepo.delete(product);
            _productRepo.saveChanges();
        }

        public ProductDto GetProductById(int id)
        {
            var product = _productRepo.getById(id) ?? throw new Exception("Product not found");
            return product.Adapt<ProductDto>();
        }

        public Task<List<ProductDto>> GetAllProducts()
        {
            //return await _productRepo.getall()
            //    .ToList()
            //    .Adapt<List<ProductDto>>();
            return Task.FromResult(new List<ProductDto>());
        }

        public List<ProductDto> SearchProducts(string keyword)
        {
            return _productRepo.SearchProduct(keyword)
                .ToList()
                .Adapt<List<ProductDto>>();
        }

        public List<ProductDto> GetProductsByCategory(int categoryId)
        {
            return _productRepo.GetProductByCategory(categoryId)
                .ToList()
                .Adapt<List<ProductDto>>();
        }

   

    }
}
