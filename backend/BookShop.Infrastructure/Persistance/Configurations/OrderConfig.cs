using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Infrastructure.Persistance.Configurations
{ 
    internal class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> entity)
        {
            entity.HasIndex(e => e.OrderDate, "UQ__Orders__7680024B39D5ACE9")
                   .IsUnique();

            entity.Property(e => e.OrderPrice).HasColumnType("decimal(8, 2)");

            entity.Property(e => e.ShippingAdr)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Orderstatus)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderstatusId).OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Orders__Ordersta__403A8C7D");
        }
    }
}
