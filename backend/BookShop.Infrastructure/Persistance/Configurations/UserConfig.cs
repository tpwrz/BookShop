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
    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534256BCB0B")
                   .IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.Property(e => e.Parole)
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.Property(e => e.RegistrationDate).HasColumnType("date");

            entity.Property(e => e.Username)
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.HasOne(d => d.Person)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.PersonId).OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Users__PersonId__3A81B327");

            entity.HasOne(d => d.Userstatus)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.UserstatusId).OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Users__Userstatu__3B75D760");
        }
    }
}
