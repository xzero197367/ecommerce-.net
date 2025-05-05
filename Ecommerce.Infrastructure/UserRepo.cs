using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Context;
using Visual_C__Final_Project_E_Commerce;

namespace Ecommerce.Infrastructure
{
    public class UserRepo : GenericRepo<User>
    {
        private readonly ContextDB _context;

        public UserRepo(ContextDB context) : base(context)
        {
            _context = context;
        }

        // add function 
    }
}
