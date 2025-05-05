using Ecommerce.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Context
{
    public class ProductConfiguration:IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.ProductId);
            builder.HasOne(c => c.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.CategoryID)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
