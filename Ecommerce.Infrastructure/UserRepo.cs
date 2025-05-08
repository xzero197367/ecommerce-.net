
using Ecommerce.Application.Contracts;
using Ecommerce.Context;
using Ecommerce.Models;

namespace Ecommerce.Infrastructure
{
<<<<<<< HEAD
    public class UserRepo: GenericRepo<User> 
=======
    public class UserRepo: GenericRepo<User>, IUserRepo
>>>>>>> ezz
    {
        private readonly ContextDB _context;

        public UserRepo(ContextDB context) : base(context)
        {
            _context =  context;
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
            return _context.users.Where(u => u.UserRole == UserRole.Admin);

        }

        public IQueryable<User> GetAllClients()
        {
            return _context.users.Where(u => u.UserRole == UserRole.Client);

        }

        public User GetByUserName(string userName)
        {
            return _context.users.FirstOrDefault(u => u.UserName == userName);
        }

        public User GetByEmail(string email)
        {
            return _context.users.FirstOrDefault(u => u.UserEmail == email);
        }

    }
}
