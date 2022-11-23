using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Domain.Models
{
    public partial class OrderStatus :BaseEntity
    {
        public OrderStatus()
        {
            Orders = new HashSet<Order>();
        }
    //    [Key]
     //   public int OrderstatusId { get; set; }
        public string OrderstatusName { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
