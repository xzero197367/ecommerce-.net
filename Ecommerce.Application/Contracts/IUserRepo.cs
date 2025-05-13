
using Ecommerce.Models;

namespace Ecommerce.Application.Contracts
{
    public interface IUserRepo : IGenericRepo<User>

    {
        public Task<List<User>> GetAllClientUsers();

        public Task<List<User>> GetAllUsers();


        public Task<User?> GetUserByEmailOrUsername(string email, string username);

        public Task<List<User>> GetAllAdminUsers();

    }
}
