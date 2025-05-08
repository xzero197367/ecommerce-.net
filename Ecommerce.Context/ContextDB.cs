
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Context.Configration;

namespace Ecommerce.Context
{
    public class ContextDB: DbContext
    {
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> ordersDetails { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<CartItem> cartItems { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                    .UseSqlServer("Data Source=.;Initial Catalog=ECommerce;Integrated Security=true;Encrypt=false");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailsConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CartItemConfiguration());


        }
    }

}
