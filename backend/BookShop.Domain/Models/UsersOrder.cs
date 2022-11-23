using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace BookShop.Domain.Models
{
    [Keyless]
    public partial class UsersOrder
    {
        public int UserId { get; set; }
        public int OrderId { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
