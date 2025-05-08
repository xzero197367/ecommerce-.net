using Ecommerce.Application.Contracts;
using Ecommerce.Application.Mapping;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services.ProductServices
{
    class ProductServices : IProductServices
    {
        private readonly IGenericRepo<Product> _productRepo;

        public ProductServices(IGenericRepo<Product> productRepo)
        {
            _productRepo = productRepo ;
        }
        public IEnumerable<AvailableProductsDTO> GetAvailableProducts()
        {
            var AvailableProducts = _productRepo.GetAll()
                .Where(p => p.UnitsInStock > 0)
                .Select(p => new AvailableProductsDTO
                {
                    Name = p.Name,
                    Price = p.Price,
                    CategoryName = p.Category.Name,

                }).ToList();

            return AvailableProducts;


        }   
        
        
    }
}
