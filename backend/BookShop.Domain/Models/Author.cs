using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Domain.Models
{
    public partial class Author :BaseEntity
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }
        [Key]
        //public int AuthorId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? PenName { get; set; }
        public string? Telephone { get; set; }
        public DateTime? BirthDate { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
