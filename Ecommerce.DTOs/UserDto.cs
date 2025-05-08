
using Ecommerce.Models;

namespace Ecommerce.DTOs
{
<<<<<<< HEAD

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
=======

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
>>>>>>> ezz
    }

  

}
