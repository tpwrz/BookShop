using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Domain.Models
{
    public partial class Language:BaseEntity
    {
        public Language()
        {
            Books = new HashSet<Book>();
        }

       // [Key]
      //  public int LanguageId { get; set; }
        public string LanguageName { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; }
    }
}
