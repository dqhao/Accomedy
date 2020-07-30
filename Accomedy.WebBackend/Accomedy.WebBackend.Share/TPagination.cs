using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accomedy.WebBackend.Share
{
    public class TPagination<TModel> where TModel : class
    {
        public int Total { get; set; }

        public IList<TModel> Items { get; set; }
    }
}
