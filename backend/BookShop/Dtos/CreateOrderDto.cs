using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Dtos
{
    public class CreateOrderDto
    {
        [Required]
        [StringLength(128, MinimumLength = 10, ErrorMessage = "Adress is too short")]
        public string ShippingAdr { get; set; }

 
        [Required]
        public int? Id { get; set; }
        public int Quantity { get; set; }
        [Required]
        public int OrderstatusId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        [Range(0, 999)]
        public decimal OrderPrice { get; set; }
        [Required]
        public int CartId { get; set; }
    }
}
