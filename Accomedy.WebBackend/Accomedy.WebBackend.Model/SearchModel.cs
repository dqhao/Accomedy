using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accomedy.WebBackend.Model
{
    public class SearchModel
    {
        public IDictionary<string, object> Criterias { get; set; }

        public string SortedBy { get; set; }

        public bool IsDescSorting { get; set; }

        public int PageNumber { get; set; }

        public int PageCount { get; set; }
    }
}
