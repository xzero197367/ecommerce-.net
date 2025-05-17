


using Ecommerce.DTOs;
using Ecommerce.Models;
using Mapster;

namespace Ecommerce.Application.Mapping
{
    public class ProductMapConfig
    {
        public static void Config()
        {
    
            TypeAdapterConfig<ProductDto, Product>.NewConfig()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.Price, src => src.Price)
                .Map(dest => dest.UnitsInStock, src => src.UnitsInStock)
                .Map(dest => dest.ImagePath, src => src.ImagePath)
                .Map(dest => dest.CategoryID, src => src.CategoryID);

        }
    }
}
