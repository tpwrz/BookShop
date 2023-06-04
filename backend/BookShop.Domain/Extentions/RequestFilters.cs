using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Infrastructure.Persistance.Extentions
{
    public class RequestFilters
    {
        public FilterLogicalOperators LogicalOperators { get; set; }

        public IList<Filter> Filters { get; set; }

        public RequestFilters()
        {
            Filters = new List<Filter>();
        }
    }
}
