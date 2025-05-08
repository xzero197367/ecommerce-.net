
namespace Ecommerce.DTOs
{
    public class CartItemCreateDto
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public DateTime DateAdded { get; set; }
    }
   public class CartItemDto
    {
        public int CartItemID { get; set; }

        public int UserID { get; set; }
        public UserDto User { get; set; }

        public int ProductID { get; set; }
        public ProductDto Product { get; set; }

        public int Quantity { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
