using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Domain.Models
{
    public partial class Currency :BaseEntity
    {
        public Currency()
        {
            Books = new HashSet<Book>();
        }

       // [Key]
        //public int CurrencyId { get; set; }
        public string CurrencyName { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; }
    }
}
