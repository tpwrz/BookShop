using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Dtos
{
    public class BookDto
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public int LanguageId { get; set; }
        public int CurrencyId { get; set; }
        public int Pages { get; set; }
        public DateTime ReleaseDate { get; set; }

        public decimal Price { get; set; }
        public int Available { get; set; }
    }
}
