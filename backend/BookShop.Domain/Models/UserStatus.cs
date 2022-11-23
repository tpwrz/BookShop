using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Domain.Models
{
    public partial class UserStatus:BaseEntity
    {
        public UserStatus()
        {
            Users = new HashSet<User>();
        }
     //   [Key]
     //   public int StatusId { get; set; }
        public string StatusName { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
