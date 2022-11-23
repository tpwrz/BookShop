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
    internal class LanguageConfig : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> entity)
        {
           // entity.HasKey(e => e.LanguageId)
           //         .HasName("PK__Language__B93855AB662E9D0E");

            entity.ToTable("LanguageRef");

            entity.HasIndex(e => e.LanguageName, "UQ__Language__E89C4A6A1B581A56")
                .IsUnique();

            entity.Property(e => e.LanguageName)
                .HasMaxLength(45)
                .IsUnicode(false);
        }
    }
}
