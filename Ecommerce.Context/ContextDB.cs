
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Context
{
    public class ContextDB: DbContext
    {
        private const string connection = "Data Source=.;Initial Catalog=EcommerceDB;Integrated Security=True;Trust Server Certificate=True";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connection).UseLazyLoadingProxies();
        }
    }

}
