using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Visual_C__Final_Project_E_Commerce
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // tells EF to auto-increment UserID.
        public int UserID { set; get; }

        // Uniqueness is with Fluent API not Data Annotation
        public string UserName { set; get; }

        // Hash the Password:
        public string UserPassword { set; get; }

        [EmailAddress]
        public string UserEmail { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }

        //defining an enum and using it as the type for UserRole
        public UserRole UserRole { set; get; }

        public bool IsActive { set; get; } = true;
        public DateTime DateCreated { set; get; }
        public DateTime? LastLoginDate { set; get; }
    }

    public enum UserRole
    {
        Client,
        Admin
    }
}

