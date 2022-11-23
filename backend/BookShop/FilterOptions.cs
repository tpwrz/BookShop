using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class FilterOptions
    {
        public string? SearchTerm { get; set; }

        public SortOrder Order { get; set; }
    }
}
