using System;
using System.Collections.Generic;

namespace BookShop.Domain.Models
{
    public partial class User :BaseEntity
    {
        //public int UserId { get; set; }
        public int PersonId { get; set; }
        public int UserstatusId { get; set; }
        public string Email { get; set; } = null!;
        public string Parole { get; set; } = null!;
        public DateTime RegistrationDate { get; set; }
        public string? Username { get; set; }

        public virtual Person Person { get; set; } = null!;
        public virtual UserStatus Userstatus { get; set; } = null!;
    }
}
