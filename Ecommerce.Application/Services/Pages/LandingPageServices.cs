using Ecommerce.Application.Services.CategoryServices;
using Ecommerce.Application.Services.ProductServices;
using Ecommerce.DTOs.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services.Pages
{
    public class LandingPageServices
    {
        private readonly ICategoryServices categoryServices;
        private readonly IProductServices productServices;

        public LandingPageServices(ICategoryServices categoryServices, IProductServices productServices)
        {
            this.categoryServices = categoryServices;
            this.productServices = productServices;
        }
        public async Task<LandingPageDto> GetLandingPageData()
        {
            var categories = await categoryServices.GetAllAsync();
            var products = await productServices.GetAllAsync();
            return new LandingPageDto
            {
                Categories = categories,
                Products = products
            };
        }
    }
}
