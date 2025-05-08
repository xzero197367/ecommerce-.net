using Ecommerce.DTOs;
using Ecommerce.Models;
using Mapster;

namespace Ecommerce.Application.Mapping
{
    public class UserMapConfig
    {
        public static void Config()
        {
            TypeAdapterConfig<UserCreateDto, User>.NewConfig()
             .Map(dest => dest.FirstName, src => src.FirstName)
             .Map(dest => dest.LastName, src => src.LastName)
             .Map(dest => dest.UserEmail, src => src.Email)
             .Map(dest => dest.UserName, src => src.Username)
             .Map(dest => dest.UserRole, src => src.Role)
             .Map(dest => dest.UserPassword, src => src.Password)
             .Map(dest => dest.DateCreated, _ => DateTime.UtcNow);

            TypeAdapterConfig<UserDto, User>.NewConfig().
              Map(dest => dest.UserID, src => src.UserID)
              .Map(dest => dest.UserName, src => src.Username)
              .Map(dest => dest.UserEmail, src => src.Email)
              .Map(dest => dest.FirstName, src => src.FirstName)
              .Map(dest => dest.LastName, src => src.LastName)
              .Map(dest => dest.UserRole, src => Enum.Parse<UserRole>(src.Role));

        }
    }
}
