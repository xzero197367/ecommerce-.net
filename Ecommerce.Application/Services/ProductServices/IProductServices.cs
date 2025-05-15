using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Application.Services.GenericServices;
using Ecommerce.DTOs;
using Ecommerce.Models;

namespace Ecommerce.Application.Services.ProductServices
{
   public interface IProductServices: IGenericService<ProductDto, ProductCreateDto, Product>
    {

    }
}
