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
             .Map(dest => dest.UserEmail, src => src.UserEmail)
             .Map(dest => dest.UserName, src => src.UserName)
             .Map(dest => dest.UserRole, src => src.UserRole)
             .Map(dest => dest.ImagePath, src => src.ImagePath) // Map the image path
             .Map(dest => dest.UserPassword, src => src.UserPassword)
             .Map(dest => dest.ImagePath, _ => string.Empty) // default image path
             .Map(dest => dest.DateCreated, _ => DateTime.UtcNow);

            TypeAdapterConfig<UserDto, User>.NewConfig().
              Map(dest => dest.UserID, src => src.UserID)
              .Map(dest => dest.UserName, src => src.UserName)
              .Map(dest => dest.UserEmail, src => src.UserEmail)
              .Map(dest => dest.FirstName, src => src.FirstName)
              .Map(dest=>dest.ImagePath, src => src.ImagePath) // Map the image path
              .Map(dest => dest.LastName, src => src.LastName)
              .Map(dest => dest.UserRole, src => src.UserRole);

        }
    }
}
