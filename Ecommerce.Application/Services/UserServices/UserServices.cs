using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Application.Contracts;
using Ecommerce.Models;

namespace Ecommerce.Application.Services.UserServices
{
   public class UserServices : IUserServices

    {
        private readonly IUserRepo _userRepo;
        public UserServices(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

   
    }
}
