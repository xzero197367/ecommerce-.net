using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Application.Contracts;
using Ecommerce.Context;
using Ecommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure
{
    public class UserRepo : GenericRepo<User>, IUserRepo
    {
        public UserRepo(ContextDB context) : base(context)
        {

        }

        public List<User> GetAllClientUsers()
        {
            return _dbSet
                   .Where(u => u.UserRole == UserRole.Client)
                   .ToList();
        }

        public User? GetUserByEmailOrUsername(string email, string username)
        {
            return _dbSet.FirstOrDefault(u => u.UserEmail == email || u.UserName == username);
        }

       public List<User> GetAllAdminUsers()
        {
            return _dbSet
                  .Where(u => u.UserRole == UserRole.Admin)
                  .ToList();
        }
    }
}
