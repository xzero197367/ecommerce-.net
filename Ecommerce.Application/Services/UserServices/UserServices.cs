using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Application.Contracts;
using Ecommerce.Models;

namespace Ecommerce.Application.Services.UserServices
{
   public class UserServices : IUserServices

    {
        private readonly IUserRepo _userRepo;
        public UserServices(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<User?> LoginAsync(string email, string password)
        {
            return await _userRepo.GetAsync(u => u.UserEmail == email && u.UserPassword == password);
        }

        public async Task RegisterAsync(User user)
        {
            _userRepo.CreateAsync(user);
            await _userRepo.SaveChangesAsync(); 
        }
    }
}
