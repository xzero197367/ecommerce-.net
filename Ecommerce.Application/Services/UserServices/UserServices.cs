using Ecommerce.Application.Contracts;
using Ecommerce.Application.Mapping;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace Ecommerce.Application.Services.UserServices
{
    class UserServices : IUserServices
    {
        private readonly IUserRepo _userRepo; // access db 
        private readonly IPasswordHasher<User> _passwordHasher; // Add a password hasher instance

        public UserServices(IUserRepo userRepo, IPasswordHasher<User> passwordHasher)
        {
            _userRepo = userRepo;
            _passwordHasher = passwordHasher; // Initialize the password hasher
        }

        public List<User> AdminViewsAllClientUsers()
        {
            var ClientUsers = _userRepo.GetAllClientUsers();
            return ClientUsers;

            // Admin will see eveything about user even password , change this according to business case
        }

        public bool AdminActivatesClientUserAccount(int userId)
        {
            var user = _userRepo.GetById(userId);

            if (user == null)
            {
                throw new Exception("User not found.");
            }

            if (user.UserRole != UserRole.Client)
            {
                throw new Exception("Cannot modify a non-admin user.");
            }

            if (user.IsActive == true)
            {
                return false;
            }

            user.IsActive = true;
            _userRepo.Update(user);
            _userRepo.SaveChanges();
            return true;
        }

        public bool AdminDeactivatesClientUserAccount(int userId)
        {
            var user = _userRepo.GetById(userId);

            if (user == null)
            {
                throw new Exception("User not found.");
            }

            if (user.UserRole != UserRole.Client)
            {
                throw new Exception("Cannot modify a non-admin user.");
            }

            if (user.IsActive == false)
            {
                return true;
            }

            user.IsActive = false;
            _userRepo.Update(user);
            _userRepo.SaveChanges();
            return true;
        }

        public bool AdminAddsAdminUser(CreateAdminUserDto dto)
        {
            var ExistingUser = _userRepo.GetUserByEmailOrUsername(dto.Email, dto.Username);

            if (ExistingUser != null)
            {
                throw new Exception("User with same username or email already exists.");
            }

            var hashedPassword = _passwordHasher.HashPassword(null, dto.Password); // Use the password hasher correctly

            var AdminUser = new User
            {
                UserName = dto.Username,
                UserEmail = dto.Email,
                UserPassword = hashedPassword,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                UserRole = UserRole.Admin, // Assign admin role
                IsActive = true,
                DateCreated = DateTime.UtcNow
            };

            _userRepo.Create(AdminUser);
            return true;
        }

        public List<AdminUserDto> AdminViewsAllAdminUsers()
        {
            var AdminUsers = _userRepo.GetAllAdminUsers().ToList();

            return AdminUsers.Select(a => new AdminUserDto
            {
                UserId = a.UserID,
                Username = a.UserName,
                Email = a.UserEmail,
                IsActive = a.IsActive,
                DateCreated = a.DateCreated
            }).ToList();
        }

        //public bool AdminActivatesAdminUserAccount(int userId)
        //{
        //    var user = _userRepo.GetById(userId);

        //    if (user == null)
        //    {
        //        throw new Exception("User not found.");
        //    }

        //    if (user.UserRole != UserRole.Admin)
        //    {
        //        throw new Exception("Cannot modify a non-admin user.");
        //    }

        //    if (user.IsActive == true)
        //    {
        //        return false;
        //    }

        //    user.IsActive = true;
        //    _userRepo.Update(user);
        //    _userRepo.SaveChanges();
        //    return true;
        //}

        //public bool AdminDeactivatesAdminUserAccount(int userId)
        //{
        //    var user = _userRepo.GetById(userId);

        //    if (user == null)
        //    {
        //        throw new Exception("User not found.");
        //    }

        //    if (user.UserRole != UserRole.Admin)
        //    {
        //        throw new Exception("Cannot modify a non-admin user.");
        //    }


        //    if (user.IsActive == false)
        //    {
        //        return true;
        //    }

        //    user.IsActive = false;
        //    _userRepo.Update(user);
        //    _userRepo.SaveChanges();
        //    return true;
        //}

        public bool AdminManagesOtherAmins(int adminTargetId, int AdminActorId, bool activate)
        {
            var target = _userRepo.GetById(adminTargetId);
            var actor = _userRepo.GetById(AdminActorId);

            if (target == null || actor == null) throw new Exception("User not found");

            if (target.UserRole!= UserRole.Admin) throw new Exception("Target is not admin");

            if (actor.UserRole != UserRole.Admin )
                throw new Exception("You are not authorized to manage admin accounts.");



            var firstAdmin = _userRepo.GetAllAdminUsers().OrderBy(a => a.DateCreated).FirstOrDefault();


            if (actor.UserID != firstAdmin.UserID)
                throw new Exception("Only the first admin can manage other admins");

            if (target.UserID == actor.UserID)
                throw new Exception("You cannot deactivate yourself");

            if (target.IsActive == activate) return false;

            target.IsActive = activate;
            _userRepo.Update(target);
            _userRepo.SaveChanges();

            return true;

            // handle both activation and deactivation of admin accounts.
            // targetId : The ID of the admin you want to activate / deactivate.
            // actorId : The ID of the admin performing the action.
            // activate : true to activate, false to deactivate.

        }



        public void Register(UserRegisterDTO dto)
        {
            var ExistingUser = _userRepo.GetAll().FirstOrDefault(u => u.UserEmail == dto.Email);

            if (ExistingUser != null)
            {
                throw new Exception("User already exists.");
            }

            var hashedPassword = _passwordHasher.HashPassword(null, dto.Password);

            var user = new User
            {
                UserName = dto.Username,
                UserEmail = dto.Email,
                UserPassword = hashedPassword,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                UserRole = UserRole.Client,
                IsActive = true,
                DateCreated = DateTime.UtcNow
            };

            _userRepo.Create(user);
            _userRepo.SaveChanges();
        }

        public void Login(UserLoginDTO dto)
        {
            var ExistingUser = _userRepo.GetAll().FirstOrDefault(u => u.UserEmail == dto.Email);

            if (ExistingUser == null)
            {
                throw new Exception("User not found.");
            }

            var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(null, ExistingUser.UserPassword, dto.Password);

            if (passwordVerificationResult != PasswordVerificationResult.Success)
            {
                throw new Exception("Incorrect password.");
            }

            ExistingUser.LastLoginDate = DateTime.UtcNow;

            _userRepo.Update(ExistingUser);
            _userRepo.SaveChanges();
        }

       
    }
}
  

