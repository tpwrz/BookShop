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

        public string? Isbn { get; set; }

        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public int LanguageId { get; set; }
        public DateOnly ReleaseDate { get; set; }

        [Range(0, 999)]
        public decimal Price { get; set; }
        public int Available { get; set; }
    }
}
