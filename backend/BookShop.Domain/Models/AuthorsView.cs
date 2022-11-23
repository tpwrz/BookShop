using System;
using System.Collections.Generic;

namespace BookShop.Domain.Models
{
    public partial class AuthorsView
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Isbn { get; set; } = null!;
        public string Title { get; set; } = null!;
    }
}
