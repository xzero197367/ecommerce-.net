using Ecommerce.Application.Contracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services.UserServices
{
    public class PasswordHasherService : IPasswordHasher
    {
        private readonly PasswordHasher<object> _hasher = new();

        public string HashPassword(string password)
        {
            return _hasher.HashPassword(null, password);
        }

        public bool VerifyPassword(string hashedPassword, string inputPassword)
        {
            var result = _hasher.VerifyHashedPassword(null, hashedPassword, inputPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}
