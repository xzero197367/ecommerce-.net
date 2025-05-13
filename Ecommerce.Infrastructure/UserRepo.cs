
using Ecommerce.Application.Contracts;
using Ecommerce.Context;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure
{
    public class UserRepo : GenericRepo<User>, IUserRepo
    {
        private readonly ContextDB _context;
        private DbSet<User> _dbSet;

        public UserRepo(ContextDB context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<User>();
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<List<User>> GetAllAdminUsers()
        {
            return await _dbSet
               .Where(u => u.UserRole == UserRole.Admin)
               .ToListAsync();
        }

        public async Task<List<User>> GetAllClientUsers()
        {
            return await _dbSet
                           .Where(u => u.UserRole == UserRole.Client)
                           .ToListAsync();
        }

        public async Task<User?> GetUserByEmailOrUsername(string email, string username)
        {
            return await _dbSet
                .FirstOrDefaultAsync(u => u.UserEmail == email || u.UserName == username);
        }

    }
}
