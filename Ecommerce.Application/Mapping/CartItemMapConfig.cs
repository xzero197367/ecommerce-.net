
using Ecommerce.DTOs;
using Ecommerce.Models;
using Mapster;

namespace Ecommerce.Application.Mapping
{
    public class CartItemMapConfig
    {
        public static void Config()
        {
            TypeAdapterConfig<CartItemCreateDto, CartItem>.NewConfig()
                .Map(dest => dest.ProductID, src => src.ProductID)
                .Map(dest => dest.Quantity, src => src.Quantity)
                .Map(dest => dest.DateAdded, _ => DateTime.UtcNow);

            TypeAdapterConfig<CartItemDto, CartItem>.NewConfig()
                .Map(dest => dest.ProductID, src => src.ProductID)
                .Map(dest => dest.Quantity, src => src.Quantity)
                .Map(dest => dest.UserID, src => src.UserID)
                .Map(dest => dest.User, src => src.User.Adapt<User>())
                .Map(dest => dest.Product, src => src.Product.Adapt<Product>())
                .Map(dest => dest.CartItemID, src => src.CartItemID)
                .Map(dest => dest.DateAdded, src => src.DateAdded);
        }
    }
}
