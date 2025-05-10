using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Models;

namespace Ecommerce.Application.Contracts
{
    public interface IUserRepo : IGenericRepo<User> 
    {
        public List<User> GetAllClientUsers();

        public User? GetUserByEmailOrUsername(string email, string username);

        public List<User> GetAllAdminUsers();
    }
}
