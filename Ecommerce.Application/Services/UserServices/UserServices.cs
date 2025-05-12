
using System.Security.Cryptography;
using Ecommerce.Application.Contracts;
using Ecommerce.DTOs;
using Ecommerce.Models;
using Mapster;

namespace Ecommerce.Application.Services.UserServices
{
   public class UserServices : IUserServices

    {
        private readonly IUserRepo _userRepo;
        public UserServices(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        //public UserDto? Login(string email, string password)
        //{
        //    // Corrected the usage of _userRepo to call the appropriate method
        //    User? user = _userRepo.getAll()
        //                          .Result
        //                          .FirstOrDefault(u => u.UserEmail == email && u.UserPassword == password);

        //    return user is not null ? user.Adapt<UserDto>() : null;
        //}

        public async Task<UserDto?> LoginAsync(string email, string password)
        {
            var user = await _userRepo.GetAsync(u =>
                u.UserEmail == email && u.UserPassword == password);

            return user is not null ? user.Adapt<UserDto>() : null;
        }
        public UserDto Register(UserCreateDto user)
        {
            user.UserPassword = HashPassword(user.UserPassword);
            User user1 = user.Adapt<User>();

        
            User resultUser = _userRepo.create(user1).Result;

            UserDto u = resultUser.Adapt<UserDto>();
            _userRepo.saveChanges();

            return u;
        }
        public async Task<UserDto> RegisterAsync(UserCreateDto user)
        {
           
            user.UserPassword = HashPassword(user.UserPassword);

           
            User userEntity = user.Adapt<User>();

        
            User resultUser = await _userRepo.create(userEntity);
            await _userRepo.saveChanges();

            return resultUser.Adapt<UserDto>();
        }


        public string HashPassword(string password)
        {
            // Generate a random salt
            byte[] salt = RandomNumberGenerator.GetBytes(16);

            // Derive a 32-byte key using PBKDF2
            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(32);

            // Combine salt + hash and return as base64
            byte[] hashBytes = new byte[48];
            Buffer.BlockCopy(salt, 0, hashBytes, 0, 16);
            Buffer.BlockCopy(hash, 0, hashBytes, 16, 32);

            return Convert.ToBase64String(hashBytes);
        }



        public bool VerifyPassword(string password, string storedHash)
        {
            byte[] hashBytes = Convert.FromBase64String(storedHash);

            byte[] salt = new byte[16];
            Buffer.BlockCopy(hashBytes, 0, salt, 0, 16);

            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(32);

            for (int i = 0; i < 32; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                    return false;
            }
            return true;
        }

       

    }
}
