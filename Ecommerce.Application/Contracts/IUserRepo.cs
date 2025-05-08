
using Ecommerce.Models;

namespace Ecommerce.Application.Contracts
{
    public interface IUserRepo : IGenericRepo<User>

    {
        User GetByUserName(string userName);
        User GetByEmail(string email);
        IQueryable<User> GetAllClients();
        IQueryable<User> GetAllAdmins();
        void ActivateUser(int UserId);
        void DeactivateUser(int UserId);
    }
}
