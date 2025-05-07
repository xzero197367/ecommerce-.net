using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Models;

namespace Ecommerce.Application.Services.UserServices
{
    public interface IUserServices 

    {
        // log in user
        Task<User?> LoginAsync(string email, string password);

        Task RegisterAsync(User user);
    }
}
