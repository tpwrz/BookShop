using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Dtos
{
    public class UpdateBookDto
    {
        [StringLength(128, MinimumLength = 3, ErrorMessage = "Name is too short")]
        public string? Title { get; set; }

        public long? Isbn { get; set; }

        public string Author { get; set; }
        public string Genre { get; set; }
        public string Language { get; set; }
        public DateOnly ReleaseDate { get; set; }

        [Range(0, 999)]
        public decimal Price { get; set; }
        public bool Available { get; set; }
    }
}
