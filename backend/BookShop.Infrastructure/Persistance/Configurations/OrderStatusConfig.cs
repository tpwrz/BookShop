using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Threading.Tasks;

namespace BookShop.Infrastructure.Persistance.Configurations
{
    internal class OrderStatusConfig : IEntityTypeConfiguration<OrderStatus>
    {

        public void Configure(EntityTypeBuilder<OrderStatus> entity)
        {
            //entity.HasKey(e => e.OrderstatusId)
            //        .HasName("PK__OrderSta__F940B395A07FC836");

            entity.ToTable("OrderStatusRef");

            entity.HasIndex(e => e.OrderstatusName, "UQ__OrderSta__A612D39AFDA69D44")
                .IsUnique();

            entity.Property(e => e.OrderstatusName)
                .HasMaxLength(45)
                .IsUnicode(false);
        }
    }
}
