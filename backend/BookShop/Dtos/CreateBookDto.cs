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
        public int? AuthorId { get; set; }
        public int? GenreId { get; set; }
        [Required]
        public int? LanguageId { get; set; }
        [Required]
        public int? CurrencyId { get; set; }
        [Required]
        public int? Pages { get; set; }
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Range(0, 999)]
        public decimal Price { get; set; }
        [Required]
        public int Available { get; set; }
    }


}

