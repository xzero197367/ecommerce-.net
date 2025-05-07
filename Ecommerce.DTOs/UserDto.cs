
using Ecommerce.Models;

namespace Ecommerce.DTOs
{

    //public enum UserRole
    //{
    //    Client,
    //    Admin
    //}

    public class UserCreateDto
    {
        public string Username { get; set; }
        public string Password { get; set; } // مش Hashed
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserRole Role { get; set; }
    }

    public class UserUpdateDto
    {
        public int UserID { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
    }

    public class UserDto
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Role { get; set; }

        // dto for orders
        // dto for cart items
    }

  

}
