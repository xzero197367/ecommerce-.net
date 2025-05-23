﻿

using Ecommerce.DTOs;
using Ecommerce.Models;
using Mapster;

namespace Ecommerce.Application.Mapping
{
    public class CategoryMapConfig
    {
        public static void Config()
        {

            // CategoryDto → Category
            TypeAdapterConfig<CategoryDto, Category>.NewConfig()
                .Map(dest => dest.CategoryId, src => src.CategoryId)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Description, src => src.Description);

            // Category -> CategoryDto
            TypeAdapterConfig<Category, CategoryDto>.NewConfig()
                .Map(dest => dest.CategoryId, src => src.CategoryId)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Description, src => src.Description);
                // .Map(dest => dest.ProductCount, src => src.Products != null ? src.Products.Count : 0);


        }
    }
}
