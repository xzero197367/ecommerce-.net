
using Ecommerce.Application.Contracts;
using Ecommerce.Context;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure
{
    public class UserRepo: GenericRepo<User>, IUserRepo
    {
        private readonly ContextDB _context;
        private DbSet<User> _dbSet;

        public UserRepo(ContextDB context) : base(context)
        {
            _context =  context;
            _dbSet = context.Set<User>();
        }
        public void ActivateUser(int UserId)
        {
            var user = _context.users.Find(UserId);
            user.IsActive = true;
            _context.SaveChanges();
        }

        public void DeactivateUser(int UserId)
        {
            var user = _context.users.Find(UserId);
            user.IsActive = false;
            _context.SaveChanges();
        }

        public IQueryable<User> GetAllAdmins()
        {
            return _dbSet.Where(u => u.UserRole == UserRole.Admin);

        }

        public IQueryable<User> GetAllClients()
        {
            return _dbSet.Where(u => u.UserRole == UserRole.Client);

        }

        public User GetByUserName(string userName)
        {
            return _dbSet.FirstOrDefault(u => u.UserName == userName);
        }

        public User GetByEmail(string email)
        {
            return _dbSet.FirstOrDefault(u => u.UserEmail == email);
        }

        public User getUser(Func<User, bool> condition)
        {
            return _dbSet.FirstOrDefault(condition);
        }
    }
}
