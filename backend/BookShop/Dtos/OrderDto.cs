using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }
        public string ShippingAdr { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public int OrderstatusId { get; set; }
        public decimal OrderPrice { get; set; }


    }
}
