using System;
using System.Collections.Generic;

namespace BookShop.Domain.Models
{
    public partial class Person :BaseEntity
    {
        public Person()
        {
            Users = new HashSet<User>();
        }

      //  public int PersonId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Adress { get; set; }
        public string? Telephone { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
