using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Dtos
{
    internal class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        //public long Idnp { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Language { get; set; }
        public DateOnly ReleaseDate { get; set; }

        public decimal Price { get; set; }
        public bool Available { get; set; }
    }
}
