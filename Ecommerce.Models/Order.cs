using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visual_C__Final_Project_E_Commerce;

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
        public User User { get; set; }  
        public ICollection<OrderDetails> Details { get; set; }

        public static implicit operator Order(Order v)
        {
            throw new NotImplementedException();
        }
    }
}
