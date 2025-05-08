

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
                //.Map(dest => dest.OrderID, src => Guid.NewGuid())
                .Map(dest => dest.UserID, src => src.UserID)
                .Map(dest => dest.OrderDate, _ => DateTime.UtcNow)
                .Map(dest => dest.TotalAmount, src => src.TotalAmount)
                .Map(dest => dest.Status, src => src.Status);


        }
    }
}
