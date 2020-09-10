using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accomedy.WebBackend.Model
{
    public class PostModel
    {
        public Guid post_id { get; set; }
        public string title { get; set; }
        public string details { get; set; }
        public string photos { get; set; }
        public decimal price { get; set; }
        public string address { get; set; }
        public string status { get; set; }
        public string owner { get; set; }
    }
}
