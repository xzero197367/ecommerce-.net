
using Ecommerce.Models;

namespace Ecommerce.DTOs
{

    public class UserCreateDto
    {

        public string UserName { set; get; }
        public string UserPassword { set; get; }
        public string UserEmail { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public UserRole UserRole { get; set; }
    }

    public class UserDto
    {
        public int UserID { set; get; }

        public string UserName { set; get; }
        public string UserPassword { set; get; }
        public string UserEmail { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public UserRole UserRole { set; get; }
        public bool IsActive { set; get; } = true;
        public DateTime DateCreated { set; get; }
        public DateTime? LastLoginDate { set; get; }
        public ICollection<CartItemDto> CartItems { set; get; }
        public ICollection<OrderDto> Orders { set; get; }
    }

  

}
