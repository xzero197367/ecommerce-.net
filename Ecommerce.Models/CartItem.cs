

namespace Ecommerce.Models
{
    public class CartItem
    {
        public int CartItemID { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
        public DateTime DateAdded { get; set; }
        
 
    }

}
