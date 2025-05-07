using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Application.Contracts;
using Ecommerce.DTOs;
using Ecommerce.Models;
using Mapster;

namespace Ecommerce.Application.Services.UserServices
{
   public class UserServices : IUserServices

    {
        private readonly IGenericRepo<User> _userRepo;
        public UserServices(IGenericRepo<User> userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<User?> LoginAsync(string email, string password)
        {
            return await _userRepo.GetAsync(u => u.UserEmail == email && u.UserPassword == password);
        }

        public async Task RegisterAsync(UserCreateDto user)
        {
            User user1 = user.Adapt<User>();
            //User user1 = new User()
            //{
            //    FirstName = user.FirstName,
            //    LastName = user.LastName,
            //    UserEmail = user.Email,
            //    UserRole = user.Role,
            //};

            _userRepo.CreateAsync(user1);
            await _userRepo.SaveChangesAsync(); 
        }
    }
}
