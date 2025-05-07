using Ecommerce.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Ecommerce.Context.Configration
{
    public class ProductConfiguration:IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.ProductId);
            builder.HasMany(o => o.OrderDetails)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.ProductId);
            builder.HasMany(c => c.CartItems)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.ProductID);
            builder.HasOne(c => c.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.CategoryID)
                .OnDelete(DeleteBehavior.Cascade);



        }
    }
}
