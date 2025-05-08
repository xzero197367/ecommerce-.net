using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.DTOs;
using Ecommerce.Models;
using Mapster;

namespace Ecommerce.Application.Mapping
{
    public class MappesterConfig
    {
        public void Congfigure()
        {
            TypeAdapterConfig<Product, ProductDto>.NewConfig()
                      .Map(dest => dest.Name, src => src.Name)
                      .Map(dest => dest.Price, src => src.Price)
                      .Map(dest => dest.UnitsInStock, src => src.UnitsInStock)
                      .Map(dest => dest.CategoryName, src => src.Category.Name)
                      .Map(dest => dest.ProductID, src => src.ProductId);

            TypeAdapterConfig<Product, ProductDetailDto>.NewConfig()
                        .Map(dest => dest.Name, src => src.Name)
                        .Map(dest => dest.Price, src => src.Price)
                        .Map(dest => dest.UnitsInStock, src => src.UnitsInStock)
                        .Map(dest => dest.CategoryName, src => src.Category.Name)
                        .Map(dest => dest.ProductID, src => src.ProductId)
                       // .Map(dest => dest.Description, src => src.Description)
                        .Map(dest => dest.ImagePath, src => src.ImagePath);
        }
    }
}
