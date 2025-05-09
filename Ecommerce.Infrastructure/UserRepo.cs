using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Application.Contracts;
using Ecommerce.Context;
using Ecommerce.Models;

namespace Ecommerce.Infrastructure
{
    public class UserRepo : GenericRepo<User> // , IUserRepo why this ?? 
    {
        public UserRepo(ContextDB context) : base(context)
        {

        }
    }
}
