

using Ecommerce.DTOs;
using Ecommerce.Models;
using Mapster;

namespace Ecommerce.Application.Mapping
{
    public class OrderDetailsMapConfig
    {
        public static void Config()
        {
            TypeAdapterConfig<OrderDetailsCreateDto, OrderDetail>.NewConfig()
                .Map(dest => dest.OrderID, src => src.OrderID)
                .Map(dest => dest.ProductId, src => src.ProductId)
                .Map(dest => dest.Quantity, src => src.Quantity);

            TypeAdapterConfig<OrderDetailsDto, OrderDetail>.NewConfig()
                .Map(dest => dest.OrderID, src => src.OrderID)
                .Map(dest => dest.ProductId, src => src.ProductId)
                .Map(dest => dest.Quantity, src => src.Quantity)
                .Map(dest => dest.OrderDetailID, src => src.OrderDetailID)
                .Map(dest => dest.Order, src => src.Order.Adapt<Order>())
                .Map(dest => dest.Product, src => src.Product.Adapt<Product>());
        }
    }
}
