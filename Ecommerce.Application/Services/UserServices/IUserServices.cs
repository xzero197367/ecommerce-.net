
using Ecommerce.DTOs;
using Ecommerce.Models;

namespace Ecommerce.Application.Services.UserServices
{
    public interface IUserServices 

    {
    //    UserDto? Login(string email, string password);

        Task<UserDto?> LoginAsync(string email, string password);

        Task<UserDto> RegisterAsync(UserCreateDto user);

        Task<UserDto> UpdateUserAsync(int id, UserCreateDto user);
        
        Task<List<UserDto>> GetUsersAsync();

        Task<UserDto?> GetUserByIdAsync(int id);

        Task<(bool status, string message)> DeleteUserAsync(int id);



      //  UserDto Register(UserCreateDto user);

        //string HashPassword(string password);

        //bool VerifyPassword(string password, string storedHash);


    }

}
