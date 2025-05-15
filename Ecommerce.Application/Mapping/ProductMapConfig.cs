
using Ecommerce.DTOs;
using Ecommerce.Models;
using Mapster;

namespace Ecommerce.Application.Mapping
{
    public class ProductMapConfig
    {
        public static void Config()
        {
            // DTO → Domain
            TypeAdapterConfig<ProductDto, Product>
                .NewConfig()
                .Map(dest => dest.ProductId, src => src.ProductId)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.Price, src => src.Price)
                .Map(dest => dest.UnitsInStock, src => src.UnitsInStock)
                .Map(dest => dest.ImagePath, src => src.ImagePath)
                .Map(dest => dest.CategoryID, src => src.CategoryID)
                .Map(dest => dest.Category,
                     src => src.Category != null
                         ? src.Category.Adapt<Category>()
                         : null)
                .Map(dest => dest.OrderDetails,
                     src => src.OrderDetails != null
                         ? src.OrderDetails.Adapt<ICollection<OrderDetail>>()
                         : new List<OrderDetail>());

            // CreateDto → Domain
            TypeAdapterConfig<ProductCreateDto, Product>
                .NewConfig()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.Price, src => src.Price)
                .Map(dest => dest.UnitsInStock, src => src.UnitsInStock)
                .Map(dest => dest.ImagePath, src => src.ImagePath)
                .Map(dest => dest.CategoryID, src => src.CategoryID);

            // Domain → DTO
            TypeAdapterConfig<Product, ProductDto>
                .NewConfig()
                .Map(dest => dest.Category,
                     src => src.Category != null
                         ? src.Category.Adapt<CategoryDto>()
                         : null)
                .Map(dest => dest.OrderDetails,
                     src => src.OrderDetails != null
                         ? src.OrderDetails.Adapt<ICollection<OrderDetailsDto>>()
                         : new List<OrderDetailsDto>());
        }
    }
}
