using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Infrastructure.Persistance.Extentions
{
    public class Filter
    {
        public string Path { get; set; }
        public string Value { get; set; }
        public Expression Expression { get; set; }
    }
}
