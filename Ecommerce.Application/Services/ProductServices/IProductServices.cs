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
       ProductDto CreateProduct(ProductDto product);

        Task CreateProductAsync(ProductCreateDto dto);
        ProductDto UpdateProduct(Product product);
        void DeleteProduct(int id);
        ProductDto GetProductById(int id);
        List<ProductDto> GetAllProducts();
        List<ProductDto> SearchProducts(string keyword);
        List<ProductDto> GetProductsByCategory(int categoryId);
    }
}
