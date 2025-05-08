

using Ecommerce.DTOs;
using Ecommerce.Models;
using Mapster;

namespace Ecommerce.Application.Mapping
{
    public class CategoryMapConfig
    {
        public static void Config()
        {
            TypeAdapterConfig<CategoryCreateDto, Category>.NewConfig()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Description, src => src.Description);

            TypeAdapterConfig<CategoryDto, Category>.NewConfig()
                .Map(dest => dest.CategoryId, src => src.CategoryId)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.Products, src => src.Products.Adapt<Product>());
        }
    }
}
