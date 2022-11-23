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
    internal class BooksOrderConfig : IEntityTypeConfiguration<BooksOrder>
    {
        public void Configure(EntityTypeBuilder<BooksOrder> entity)
        {
            entity.HasNoKey();

            entity.HasOne(d => d.Book)
                .WithMany()
                .HasForeignKey(d => d.BookId).OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__BooksOrde__BookI__4E88ABD4");

            entity.HasOne(d => d.Order)
                .WithMany()
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__BooksOrde__Order__4F7CD00D");
        }
    }
}
