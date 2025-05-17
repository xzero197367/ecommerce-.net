using Ecommerce.Models;

namespace Ecommerce.DTOs
{
    public class UserDto
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string ImagePath { get; set; } = string.Empty; // Store the relative path of the image
        public string UserEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserRole UserRole { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime? LastLoginDate { get; set; }
        public ICollection<CartItemDto> CartItems { get; set; }
        public ICollection<OrderDto> Orders { get; set; }
    }
}
