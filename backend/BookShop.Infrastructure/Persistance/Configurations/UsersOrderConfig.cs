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
    internal class UsersOrderConfig : IEntityTypeConfiguration<UsersOrder>
    {
        public void Configure(EntityTypeBuilder<UsersOrder> entity)
        {
            entity.HasNoKey();

            entity.HasOne(d => d.Order)
                .WithMany()
                .HasForeignKey(d => d.OrderId).OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__UsersOrde__Order__4CA06362");

            entity.HasOne(d => d.User)
                .WithMany()
                .HasForeignKey(d => d.UserId).OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__UsersOrde__UserI__4BAC3F29");
        }
    }
}
