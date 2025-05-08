using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Application.Mapping;


namespace Ecommerce.Application.Services.ProductServices
{
    interface IProductServices
    {
        public IEnumerable<AvailableProductsDTO> GetAvailableProducts();
    }
}
