

namespace Ecommerce.Models
{
    public class CartItem
    {
        public int CartItemID { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }

        public int ProductID { get; set; }
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
        public DateTime DateAdded { get; set; }
        
 
    }

}
