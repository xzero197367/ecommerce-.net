using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Context
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o=>o.OrderID);
            builder.HasMany(d => d.Details)
                .WithOne(o => o.Order)
            .HasForeignKey(o => o.OrderID)
            .OnDelete(DeleteBehavior.Cascade);
           
        }
    }
}
