
using Ecommerce.Application.Services.GenericServices;
using Ecommerce.DTOs;
using Ecommerce.Models;

namespace Ecommerce.Application.Services.UserServices
{
    public interface IUserServices : IGenericService<UserDto, User>

    {
        Task<UserDto?> LoginAsync(string email, string password);

        Task<UserDto> RegisterAsync(UserDto user);
    }

}
