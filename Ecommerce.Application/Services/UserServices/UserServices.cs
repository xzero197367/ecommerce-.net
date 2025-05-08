using Ecommerce.Application.Contracts;
using Ecommerce.Application.Mapping;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services.UserServices
{
    class UserServices : IUserServices
    {
        private readonly IUserRepo _userRepo; // access db 
        public UserServices(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        #region req1 
        public void Register(UserRegisterDTO dto)
        {
            var ExistingUser = _userRepo.GetAll().FirstOrDefault(u => u.UserEmail == dto.Email);
           
            if(ExistingUser != null)
            {
                throw new Exception("User already exists.");
            }

            //var user1 = dto.adapt<User>();

            var user = new User
            {
                UserName = dto.Username,
                UserEmail = dto.Email,
                UserPassword = dto.Password ,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                UserRole = UserRole.Client, // default role for sign-up
                IsActive = true,
                DateCreated = DateTime.UtcNow

            };

            _userRepo.create(user);
            _userRepo.SaveChanges();


        }

        // hash the password 
        // password confirmation
        // confirmation with username too
        #endregion
       
        #region req2
        public void Login(UserLoginDTO dto)
        {
            var ExistingUser = _userRepo.GetAll().FirstOrDefault(u => u.UserEmail == dto.Email);

            if(ExistingUser == null)
            {
                throw new Exception("User not found.");
            }

            if(dto.Password != ExistingUser.UserPassword)
            {
                throw new Exception("Incorrect password.");
            }

            ExistingUser.LastLoginDate = DateTime.UtcNow;

            _userRepo.update(ExistingUser);
            _userRepo.SaveChanges();

        }
        #endregion


    }
}
