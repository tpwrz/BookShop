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
    internal class AvailabilityConfig : IEntityTypeConfiguration<Availability>
    {
    
        public void Configure(EntityTypeBuilder<Availability> entity)
        {
           // entity.HasKey(e => e.AvailabilityId)
            //        .HasName("PK__Availabi__DA3979B155081618");

            entity.ToTable("AvailabilityRef");

            entity.HasIndex(e => e.AvailabilityName, "UQ__Availabi__86FED021E4D7B2C2")
                .IsUnique();

            entity.Property(e => e.AvailabilityName)
                .HasMaxLength(45)
                .IsUnicode(false);
        }
    }
}
