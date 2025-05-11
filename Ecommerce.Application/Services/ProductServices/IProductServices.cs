using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.DTOs;
using Ecommerce.Models;

namespace Ecommerce.Application.Services.ProductServices
{
   public interface IProductServices
    {
        Task<ProductDto> CreateProductAsync(ProductCreateDto product);

        Task<ProductDto> UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
        Task<List<ProductDto>> GetAllProducts();
        List<ProductDto> SearchProducts(string keyword);
        List<ProductDto> GetProductsByCategory(int categoryId);
        Task<ProductDto> GetProductById(int id);
    }
}
