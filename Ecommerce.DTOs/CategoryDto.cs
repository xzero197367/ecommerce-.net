

using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Ecommerce.DTOs
{
   public class CategoryCreateDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        //public List<ProductDto> Products { get; set; }
        public int ProductCount {get; set;}
    }

}
