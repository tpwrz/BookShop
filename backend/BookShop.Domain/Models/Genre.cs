using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Domain.Models
{
    public partial class GenreRef:BaseEntity
    {
        public GenreRef()
        {
            Books = new HashSet<Book>();
        }
       // [Key]
       // public int GenreId { get; set; }
        public string GenreName { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; }
    }
}
