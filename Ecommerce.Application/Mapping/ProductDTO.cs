using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Mapping
{
    //    • Name(string)
    //• Description(string)
    //• Price(decimal)

    public class AvailableProductsDTO
    {
        
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }


    }
}
