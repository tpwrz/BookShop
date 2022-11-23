using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Domain.Models
{
    public partial class Availability :BaseEntity
    {
        public Availability()
        {
            Books = new HashSet<Book>();
        }
        [Key]
       // public int AvailabilityId { get; set; }
        public string AvailabilityName { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; }
    }
}
