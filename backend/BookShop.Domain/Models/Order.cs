using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Domain.Models
{
    public partial class Order:BaseEntity
    {
       // [Key]
     //   public int OrderId { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }
        public string ShippingAdr { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public int OrderstatusId { get; set; }
        public decimal OrderPrice { get; set; }

        public virtual OrderStatus Orderstatus { get; set; } = null!;
    }
}
