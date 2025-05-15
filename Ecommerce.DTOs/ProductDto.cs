

namespace Ecommerce.DTOs
{

    public class ProductCreateDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int UnitsInStock { get; set; }
        public string ImagePath { get; set; }
        public int CategoryID { get; set; }
    }

    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int UnitsInStock { get; set; }
        public string ImagePath { get; set; }
        public int CategoryID { get; set; }
        public CategoryDto Category { get; set; }
        public ICollection<OrderDetailsDto> OrderDetails { get; set; }
        //public ICollection<CartItemDto> CartItems { get; set; }
    }
   
}
