
using Ecommerce.Context;
using Ecommerce.Models;

namespace Ecommerce.Infrastructure
{
    public class UserRepo : GenericRepo<User>
    {
        private readonly ContextDB _context;

        public UserRepo(ContextDB context) : base(context)
        {
            _context = context;
        }

    }
}
