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
    internal class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> entity)
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.Adress)
                .HasMaxLength(45)
                .IsUnicode(false);

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

            entity.Property(e => e.Telephone)
                .HasMaxLength(18)
                .IsUnicode(false);
        }
    }
}
