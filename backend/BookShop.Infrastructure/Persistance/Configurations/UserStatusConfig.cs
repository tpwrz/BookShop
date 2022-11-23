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
    internal class UserStatusConfig : IEntityTypeConfiguration<UserStatus>
    {
        public void Configure(EntityTypeBuilder<UserStatus> entity)
        {
        //    entity.HasKey(e => e.StatusId)
        //               .HasName("PK__UserStat__C8EE20631EE8496D");

            entity.ToTable("UserStatusRef");

            entity.HasIndex(e => e.StatusName, "UQ__UserStat__05E7698A9B49331C")
                .IsUnique();

            entity.Property(e => e.StatusName)
                .HasMaxLength(45)
                .IsUnicode(false);
        }
    }
}
