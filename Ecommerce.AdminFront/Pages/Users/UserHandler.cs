using Autofac;
using Ecommerce.AdminFront.Classes.AutoFac;
using Ecommerce.AdminFront.Pages.Categories;
using Ecommerce.Application.Services.UserServices;
using Ecommerce.DTOs;
using System;


namespace Ecommerce.AdminFront.Pages.Users
{
    public class UserHandler
    {
        private IUserServices userServices;
        private UserHandler()
        {
            var container = AutoFac.Inject();
            userServices = container.Resolve<IUserServices>();
        }

        private static UserHandler? _instance;

        public static UserHandler GetInstance()
        {
            if (_instance == null)
            {
                _instance = new UserHandler();
            }
            return _instance;
        }


        public async Task<(bool status, string message)> DeleteUser(int id)
        {
            try
            {
                var res = await userServices.DeleteAsync(id);
                return (res, res ? "Category deleted successfully" : "something went wrong");
            }
            catch (Exception ex)
            {
                return (false, "something went wrong");
            }
        }

        public async Task<(bool status, string message)> onUpdateUser(int id, UserCreateDto dto)
        {
            var user = new UserDto()
            {
                UserID = id,
                UserName = dto.UserName,
                UserPassword = dto.UserPassword,
                UserEmail = dto.UserEmail,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                UserRole = dto.UserRole
            };
            var res = await userServices.UpdateAsync(user);

            if (res == null)
            {
                return (false, "something went wrong");
            }
            return (true, "User updated successfully");
        }

        public async Task<(bool status, string message)> CreateUser(UserCreateDto dto)
        {
            try
            {
                await userServices.RegisterAsync(dto);
                return (true, "User created successfully");
            }
            catch (Exception ex)
            {
                return (false, "something went wrong");
            }
        }

        public async Task<List<UserDto>> GetUsers()
        {
            return await userServices.GetAllAsync();
        }


    }
}
