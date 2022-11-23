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
    internal class GenreCofig : IEntityTypeConfiguration<GenreRef>
    {
        public void Configure(EntityTypeBuilder<GenreRef> entity)
        {
            entity.HasKey(e => e.GenreId)
                    .HasName("PK__GenreRef__0385057EBACAB50B");

            entity.ToTable("GenreRef");

            entity.HasIndex(e => e.GenreName, "UQ__GenreRef__BBE1C3398C7BB20C")
                .IsUnique();

            entity.Property(e => e.GenreName)
                .HasMaxLength(45)
                .IsUnicode(false);
        }
    }
}
