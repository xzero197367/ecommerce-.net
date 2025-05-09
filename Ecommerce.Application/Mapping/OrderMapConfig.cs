

using Ecommerce.DTOs;
using Ecommerce.Models;
using Mapster;

namespace Ecommerce.Application.Mapping
{
    public class OrderMapConfig
    {
        public static void Config()
        {
            TypeAdapterConfig<OrderCreateDto, Order>.NewConfig()
                .Map(dest => dest.UserID, src => src.UserID)
                .Map(dest => dest.OrderDate, _ => DateTime.UtcNow)
                .Map(dest => dest.TotalAmount, src => src.TotalAmount)
                .Map(dest => dest.Status, src => src.Status);

            TypeAdapterConfig<OrderDto, Order>.NewConfig()
                .Map(dest => dest.UserID, src => src.UserID)
                .Map(dest => dest.OrderDate, src => src.OrderDate)
                .Map(dest => dest.TotalAmount, src => src.TotalAmount)
                .Map(dest => dest.Status, src => src.Status)
                .Map(dest => dest.DateProcessed, src => src.DateProcessed)
                .Map(dest => dest.OrderID, src => src.OrderID)
                .Map(dest => dest.User, src => src.User.Adapt<User>())
                .Map(dest => dest.Details, src => src.Details.Adapt<List<OrderDetail>>())
                .IgnoreNullValues(true);

        }
    }
}
