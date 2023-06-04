using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace BookShop.Domain.Models
{
    public partial class ProjectContext : DbContext
    {
        public ProjectContext()
        {
        }

        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<AuthorsView> AuthorsViews { get; set; } = null!;
        public virtual DbSet<Availability> AvailabilityRefs { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BooksOrder> BooksOrders { get; set; } = null!;
        public virtual DbSet<BooksOrdersUsersView> BooksOrdersUsersViews { get; set; } = null!;
        public virtual DbSet<BooksView> BooksViews { get; set; } = null!;
        public virtual DbSet<Currency> CurrencyRefs { get; set; } = null!;
        public virtual DbSet<GenreRef> GenreRefs { get; set; } = null!;
        public virtual DbSet<Language> LanguageRefs { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderStatus> OrderStatusRefs { get; set; } = null!;
        public virtual DbSet<OrdersUsersView> OrdersUsersViews { get; set; } = null!;
        public virtual DbSet<OrdersView> OrdersViews { get; set; } = null!;
        public virtual DbSet<Person> Persons { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserStatus> UserStatusRefs { get; set; } = null!;
        public virtual DbSet<UsersOrder> UsersOrders { get; set; } = null!;
        public virtual DbSet<UsersView> UsersViews { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=PROJECT;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProjectContext).Assembly);

            modelBuilder.Entity<AuthorsView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("AuthorsView");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Isbn)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BooksOrdersUsersView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("BooksOrdersUsersView");

                entity.Property(e => e.CurrencyName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.GenreName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Isbn)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.LanguageName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.OrderPrice).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.OrderstatusName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.ShippingAdr)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StatusName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Telephone)
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BooksView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("BooksView");

                entity.Property(e => e.AvailabilityName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.CurrencyName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.GenreName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Isbn)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.LanguageName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.ReleaseDate).HasColumnType("date");

                entity.Property(e => e.Title)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrdersUsersView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("OrdersUsersView");

                entity.Property(e => e.Email)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Isbn)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.OrderPrice).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.OrderstatusName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingAdr)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StatusName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Telephone)
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrdersView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("OrdersView");

                entity.Property(e => e.Isbn)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.OrderPrice).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.OrderstatusName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.ShippingAdr)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UsersView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("UsersView");

                entity.Property(e => e.Adress)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.RegistrationDate).HasColumnType("date");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Telephone)
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
