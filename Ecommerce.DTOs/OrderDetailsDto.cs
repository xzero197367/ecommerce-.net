
namespace Ecommerce.DTOs
{
   public class OrderDetailsCreateDto
    {
        public int OrderID { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class OrderDetailsDto
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public OrderDto Order { get; set; }
        public ProductDto Product { get; set; }
    }
}
