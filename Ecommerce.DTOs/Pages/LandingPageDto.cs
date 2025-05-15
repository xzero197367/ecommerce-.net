using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTOs.Pages
{
    public class LandingPageDto
    {
        public List<CategoryDto> Categories { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
