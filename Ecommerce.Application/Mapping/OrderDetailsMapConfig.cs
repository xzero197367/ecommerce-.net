

using Ecommerce.DTOs;
using Ecommerce.Models;
using Mapster;

namespace Ecommerce.Application.Mapping
{
    public class OrderDetailsMapConfig
    {
        public static void Config()
        {
            // Create DTO → Entity
            TypeAdapterConfig<OrderDetailsCreateDto, OrderDetail>
                .NewConfig()
                .Map(dest => dest.OrderID, src => src.OrderID)
                .Map(dest => dest.ProductId, src => src.ProductId)
                .Map(dest => dest.Quantity, src => src.Quantity);

            // Full DTO → Entity
            TypeAdapterConfig<OrderDetailsDto, OrderDetail>
                .NewConfig()
                .Map(dest => dest.OrderDetailID, src => src.OrderDetailID)
                .Map(dest => dest.OrderID, src => src.OrderID)
                .Map(dest => dest.ProductId, src => src.ProductId)
                .Map(dest => dest.Quantity, src => src.Quantity)
                .Map(dest => dest.Order, src => src.Order != null
                    ? src.Order.Adapt<Order>()
                    : null)
                .Map(dest => dest.Product, src => src.Product != null
                    ? src.Product.Adapt<Product>()
                    : null);

            // Optional: Entity → DTO if needed
            TypeAdapterConfig<OrderDetail, OrderDetailsDto>
                .NewConfig()
                .Map(dest => dest.OrderDetailID, src => src.OrderDetailID)
                .Map(dest => dest.OrderID, src => src.OrderID)
                .Map(dest => dest.ProductId, src => src.ProductId)
                .Map(dest => dest.Quantity, src => src.Quantity)
                .Map(dest => dest.Order, src => src.Order != null
                    ? src.Order.Adapt<OrderDto>()
                    : null)
                .Map(dest => dest.Product, src => src.Product != null
                    ? src.Product.Adapt<ProductDto>()
                    : null);
        }
    }
}
