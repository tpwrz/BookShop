using BookShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Infrastructure.Persistance.Configurations
{
    internal class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> entity)
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.BirthDate).HasColumnType("date");

            entity.Property(e => e.FirstName)
                        .HasMaxLength(45)
                        .IsUnicode(false);

            entity.Property(e => e.LastName)
                        .HasMaxLength(45)
                        .IsUnicode(false);

            entity.Property(e => e.MiddleName)
                        .HasMaxLength(45)
                        .IsUnicode(false);

            entity.Property(e => e.PenName)
                        .HasMaxLength(45)
                        .IsUnicode(false);

            entity.Property(e => e.Telephone)
                        .HasMaxLength(18)
                        .IsUnicode(false);

            //entity.ToTable("some");
        }
    }
}
