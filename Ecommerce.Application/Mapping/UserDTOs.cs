using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Mapping
{
    //public class MappesterConfig
    //{
    //    public void Congfigure()
    //    {
    //        //TypeAdapterConfig<Book, BookDTOs>.NewConfig()
    //        //          .Map(dest => dest.AuthorName, src => src.Auther.Name);
    //        //          .Map(dest => dest.Type, src => src.Type);
    //    }
    //}

    public class UserRegisterDTO
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class UserLoginDTO
    {
        //public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class CreateAdminUserDto
    {
        public string Username { get; set; }
        public string Password { get; set; } // plain text, will be hashed
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class AdminUserDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
    }

   
}
