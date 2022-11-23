using System;
using System.Collections.Generic;

namespace BookShop.Domain.Models
{
    public partial class BooksView
    {
        public int BookId { get; set; }
        public string Isbn { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string GenreName { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
        public string LanguageName { get; set; } = null!;
        public int PageNumber { get; set; }
        public decimal Price { get; set; }
        public string CurrencyName { get; set; } = null!;
        public string AvailabilityName { get; set; } = null!;
    }
}
