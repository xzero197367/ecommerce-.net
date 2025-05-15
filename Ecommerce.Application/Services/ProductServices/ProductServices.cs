
using Ecommerce.Application.Contracts;
using Ecommerce.Application.Services.GenericServices;
using Ecommerce.DTOs;
using Ecommerce.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Application.Services.ProductServices
{
   public class ProductServices : GenericServices<ProductDto, ProductCreateDto, Product>, IProductServices


    {
        private readonly IProductRepo productRepo;

        public ProductServices(IProductRepo productRepo): base(productRepo)
        {
            this.productRepo = productRepo;
        }


    }
}
