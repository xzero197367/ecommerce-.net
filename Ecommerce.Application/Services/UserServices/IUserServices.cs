using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.DTOs;
using Ecommerce.Models;

namespace Ecommerce.Application.Services.UserServices
{
    public interface IUserServices 

    {
    //    UserDto? Login(string email, string password);

        Task<UserDto?> LoginAsync(string email, string password);

        Task<UserDto> RegisterAsync(UserCreateDto user);

      //  UserDto Register(UserCreateDto user);

        string HashPassword(string password);

        bool VerifyPassword(string password, string storedHash);
    }
}
