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
    internal class CurrencyConfig : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> entity)
        {
            //entity.HasKey(e => e.CurrencyId)
            //        .HasName("PK__Currency__14470AF0421D2CB1");

            entity.ToTable("CurrencyRef");

            entity.HasIndex(e => e.CurrencyName, "UQ__Currency__3D13D298CF5F79FF")
                .IsUnique();

            entity.Property(e => e.CurrencyName)
                .HasMaxLength(45)
                .IsUnicode(false);
        }
    }
}
