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
    internal class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasIndex(e => e.Isbn, "UQ__Books__9271CED05E09F6F7")
                    .IsUnique();

            builder.Property(e => e.Isbn)
                .HasMaxLength(45)
                .IsUnicode(false);

            builder.Property(e => e.Price).HasColumnType("decimal(5, 2)");

            builder.Property(e => e.ReleaseDate).HasColumnType("date");

            builder.Property(e => e.Title)
                .HasMaxLength(45)
                .IsUnicode(false);

            builder.HasOne(d => d.Author)
                .WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Books__AuthorId__44FF419A");

            builder.HasOne(d => d.Availability)
                .WithMany(p => p.Books)
                .HasForeignKey(d => d.AvailabilityId).OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Books__Availabil__49C3F6B7");

            builder.HasOne(d => d.Currency)
                .WithMany(p => p.Books)
                .HasForeignKey(d => d.CurrencyId).OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Books__CurrencyI__48CFD27E");

            builder.HasOne(d => d.Genre)
                .WithMany(p => p.Books)
                .HasForeignKey(d => d.GenreId).OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Books__GenreId__45F365D3");

            builder.HasOne(d => d.Language)
                .WithMany(p => p.Books)
                .HasForeignKey(d => d.LanguageId).OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Books__LanguageI__46E78A0C");
           
        }
    }
}
