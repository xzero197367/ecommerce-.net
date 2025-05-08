using System;
using System.Collections.Generic;
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
}
