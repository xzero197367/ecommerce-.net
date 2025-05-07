using Ecommerce.DTOs;
using Ecommerce.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Mapping
{
    public class MappesterConfig
    {
        public void Congfigure()
        {
            TypeAdapterConfig<User, UserCreateDto>.NewConfig()
                      .Map(dest => dest.FirstName, src => src.FirstName)
                      .Map(dest => dest.LastName, src => src.LastName)
                      .Map(dest => dest.Email, src => src.UserEmail)
                      .Map(dest => dest.Username, src => src.UserName)
                      .Map(dest => dest.Role, src => src.UserRole)
                      .Map(dest => dest.Password, src => src.UserPassword);
                        

            //TypeAdapterConfig<User, UserUpdateDto>.NewConfig()
            //          .Map(dest => dest.FirstName, src => src.FirstName)
            //          .Map(dest => dest.LastName, src => src.LastName)
            //          .Map(dest => dest.Email, src => src.UserEmail);
        }
    }
}
