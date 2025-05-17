using Ecommerce.Application.Services.CategoryServices;
using Ecommerce.Application.Services.ProductServices;
using Ecommerce.DTOs.Pages;

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
