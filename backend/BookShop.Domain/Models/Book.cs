using System;
using System.Collections.Generic;

namespace BookShop.Domain.Models
{
    public partial class Book :BaseEntity
    {
       // public int BookId { get; set; }
        public string Isbn { get; set; } = null!;
        public string Title { get; set; } = null!;
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int LanguageId { get; set; }
        public int PageNumber { get; set; }
        public decimal Price { get; set; }
        public int CurrencyId { get; set; }
        public int AvailabilityId { get; set; }

        public virtual Author Author { get; set; } = null!;
        public virtual Availability Availability { get; set; } = null!;
        public virtual Currency Currency { get; set; } = null!;
        public virtual GenreRef Genre { get; set; } = null!;
        public virtual Language Language { get; set; } = null!;

        public static implicit operator Book(Book v)
        {
            throw new NotImplementedException();
        }
    }
}
