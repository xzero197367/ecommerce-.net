
using Ecommerce.Application.Contracts;
using Ecommerce.Application.Services.GenericServices;
using Ecommerce.DTOs;
using Ecommerce.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ecommerce.Application.Services.ProductServices
{
   public class ProductServices : GenericServices<ProductDto, Product>, IProductServices


    {
        private readonly IProductRepo productRepo;

        public ProductServices(IProductRepo productRepo): base(productRepo)
        {
            this.productRepo = productRepo;
        }

        public override async Task<List<ProductDto>> GetAllAsync()
        {
            try
            {
                var items = await productRepo.GetAllAsync()
                        .Include(x => x.Category)
                    .AsNoTracking()
                    .ToListAsync();
                if (items == null)
                    return null;
                return items.Adapt<List<ProductDto>>();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting all items", ex);
            }
        }
        public override async Task<List<ProductDto>> GetWithConditionAsync(Expression<Func<Product, bool>> predicate)
        {
            try
            {

                var items = await productRepo.GetWithConditionAsync(predicate)
                    .Include(x => x.Category)
                    .AsNoTracking()
                    .ToListAsync();
                return items.Adapt<List<ProductDto>>();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting items with condition", ex);
            }
        }
    }
}
