using Ecommerce.Models;


namespace Ecommerce.DTOs
{
   public class OrderCreateDto
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime? DateProcessed { get; set; }
    }
}
