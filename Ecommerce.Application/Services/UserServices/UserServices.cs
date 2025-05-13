using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
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

        public async Task<UserDto?> LoginAsync(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || !IsValidEmail(email))
            {
                return null;
            }

            // Find user by email using ToLower()
            User? user = (await _userRepo.getAll())
                .FirstOrDefault(u => u.UserEmail.ToLower() == email.ToLower());

            if (user == null)
            {
                return null;
            }

            // Verify password
            bool isPasswordValid = VerifyPassword(password, user.UserPassword);
            if (!isPasswordValid)
            {
                return null;
            }

            // Map to DTO
            return user.Adapt<UserDto>();
        }
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            // Regex pattern for email validation
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }
        public UserDto? Login(string email, string password)
        {
            // Corrected the usage of _userRepo to call the appropriate method
            User? user = _userRepo.getAll()
                                  .Result
                                  .FirstOrDefault(u => u.UserEmail == email && u.UserPassword == password);

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

        public async Task<UserDto> UpdateUserAsync(int id, UserCreateDto user)
        {
            var existingUser = await _userRepo.getById(id);
            if (existingUser == null)
            {
                throw new Exception("User not found");
            }

            // Update the properties of the existing user
            existingUser.UserName = user.UserName;
            existingUser.UserEmail = user.UserEmail;
            existingUser.UserPassword = HashPassword(user.UserPassword);
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.UserRole = user.UserRole;

            await _userRepo.saveChanges();

            return existingUser.Adapt<UserDto>();
        }

        public async Task<List<UserDto>> GetUsersAsync()
        {
            var items =  await _userRepo.GetAllUsers();

            return items.Adapt<List<UserDto>>();
        }

        public async Task<UserDto?> GetUserByIdAsync(int id)
        {
            var user = await _userRepo.getById(id);
            return user?.Adapt<UserDto>();
        }

        public async Task<(bool status, string message)> DeleteUserAsync(int id)
        {
            var user = await _userRepo.getById(id);
            if (user == null)
            {
                return (false, "User not found");
            }

            await _userRepo.delete(user);
            await _userRepo.saveChanges();

            return (true, "User deleted successfully");
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