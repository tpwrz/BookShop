using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Dtos
{
    public class CreateBookDto
    {

        [Required]
        [StringLength(128, MinimumLength = 3, ErrorMessage = "Title is too short")]
        public string Title { get; set; }

        [Required]
        public string Isbn { get; set; }
        [Required]
        public string? Author { get; set; }
        public string? Genre { get; set; }
        [Required]
        public string? Language { get; set; }
        [Required]
        public DateOnly? ReleaseDate { get; set; }

        [Required]
        [Range(0, 999)]
        public decimal Price { get; set; }
        [Required]
        public bool Available { get; set; }
    }


}

