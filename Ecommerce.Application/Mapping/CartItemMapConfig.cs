
using Ecommerce.DTOs;
using Ecommerce.Models;
using Mapster;

namespace Ecommerce.Application.Mapping
{
    public class CartItemMapConfig
    {
        public static void Config()
        {
            // DTO used for creating a new CartItem
            TypeAdapterConfig<CartItemCreateDto, CartItem>
                .NewConfig()
                .Map(dest => dest.ProductID, src => src.ProductID)
                .Map(dest => dest.Quantity, src => src.Quantity)
                .Map(dest => dest.DateAdded, _ => DateTime.UtcNow);

            // Full DTO → Entity mapping
            TypeAdapterConfig<CartItemDto, CartItem>
                .NewConfig()
                .Map(dest => dest.CartItemID, src => src.CartItemID)
                .Map(dest => dest.ProductID, src => src.ProductID)
                .Map(dest => dest.Quantity, src => src.Quantity)
                .Map(dest => dest.UserID, src => src.UserID)
                .Map(dest => dest.DateAdded, src => src.DateAdded)
                .Map(dest => dest.Product, src => src.Product != null
                    ? src.Product.Adapt<Product>()
                    : null)
                .Map(dest => dest.User, src => src.User != null
                    ? src.User.Adapt<User>()
                    : null);

            // Optional: Entity → DTO mapping if needed
            TypeAdapterConfig<CartItem, CartItemDto>
                .NewConfig()
                .Map(dest => dest.CartItemID, src => src.CartItemID)
                .Map(dest => dest.ProductID, src => src.ProductID)
                .Map(dest => dest.Quantity, src => src.Quantity)
                .Map(dest => dest.UserID, src => src.UserID)
                .Map(dest => dest.DateAdded, src => src.DateAdded)
                .Map(dest => dest.Product, src => src.Product != null
                    ? src.Product.Adapt<ProductDto>()
                    : null)
                .Map(dest => dest.User, src => src.User != null
                    ? src.User.Adapt<UserDto>()
                    : null);
        }
    }
}
