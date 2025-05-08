

namespace Ecommerce.DTOs
{
   public class OrderDetailsCreateDto
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
