
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Context
{
    public class ContextDB: DbContext
    {
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                    .UseSqlServer("Data Source=LAPTOP-GCE6K8LP\\SQLEXPRESS;Initial Catalog=E-Commerce;Integrated Security=true;Encrypt=false");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        }
    }

}
