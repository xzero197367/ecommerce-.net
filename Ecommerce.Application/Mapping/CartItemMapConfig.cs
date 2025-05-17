
using Ecommerce.DTOs;
using Ecommerce.Models;
using Mapster;

namespace Ecommerce.Application.Mapping
{
    public class CartItemMapConfig
    {
        public static void Config()
        {
            TypeAdapterConfig<CartItemDto, CartItem>
                .NewConfig()
                .MapWith(src => new CartItem
                {
                    CartItemID = src.CartItemID,
                    ProductID = src.ProductID,
                    Quantity = src.Quantity,
                    UserID = src.UserID,
                    DateAdded = src.DateAdded
                });

            TypeAdapterConfig<CartItem, CartItemDto>
                .NewConfig()
                .MapWith(src => new CartItemDto
                {
                    CartItemID = src.CartItemID,
                    ProductID = src.ProductID,
                    Quantity = src.Quantity,
                    UserID = src.UserID,
                    DateAdded = src.DateAdded,
                    Product = src.Product != null ? src.Product.Adapt<ProductDto>() : null,
                    User = src.User != null ? src.User.Adapt<UserDto>() : null
                });


            // Full DTO → Entity mapping
            //TypeAdapterConfig<CartItemDto, CartItem>
            //    .NewConfig()
            //    .Map(dest => dest.CartItemID, src => src.CartItemID)
            //    .Map(dest => dest.ProductID, src => src.ProductID)
            //    .Map(dest => dest.Quantity, src => src.Quantity)
            //    .Map(dest => dest.UserID, src => src.UserID)
            //    .Map(dest => dest.DateAdded, src => src.DateAdded);
            //.Map(dest => dest.Product, src => src.Product != null ? src.Product.Adapt<Product>() : null);
            //.Map(dest => dest.User, src => src.User != null
            //    ? src.User.Adapt<User>()
            //    : null);

            // Optional: Entity → DTO mapping if needed
            //TypeAdapterConfig<CartItem, CartItemDto>
            //    .NewConfig()
            //    .Map(dest => dest.CartItemID, src => src.CartItemID)
            //    .Map(dest => dest.ProductID, src => src.ProductID)
            //    .Map(dest => dest.Quantity, src => src.Quantity)
            //    .Map(dest => dest.UserID, src => src.UserID)
            //    .Map(dest => dest.DateAdded, src => src.DateAdded)
            //    .Map(dest => dest.Product, src => src.Product != null ? src.Product.Adapt<ProductDto>() : null);
            //.MapWith(dest => dest.User, src => src.User != null
            //    ? src.User.Adapt<UserDto>()
            //    : null);
        }
    }
}
