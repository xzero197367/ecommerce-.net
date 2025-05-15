
using Ecommerce.Application.Services.GenericServices;
using Ecommerce.DTOs;
using Ecommerce.Models;

namespace Ecommerce.Application.Services.UserServices
{
    public interface IUserServices : IGenericService<UserDto, UserCreateDto, User>

    {
        Task<UserDto?> LoginAsync(string email, string password);

        Task<UserDto> RegisterAsync(UserCreateDto user);
    }

}
