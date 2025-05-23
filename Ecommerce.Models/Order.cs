﻿

namespace Ecommerce.Models
{
   public enum OrderStatus
    {
        Pending,
        Approved,
        Denied,
        Shipped
    }
    public class Order
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime? DateProcessed { get; set; }
        public virtual User User { get; set; }  
        public virtual ICollection<OrderDetail> Details { get; set; }

        
    }
}
