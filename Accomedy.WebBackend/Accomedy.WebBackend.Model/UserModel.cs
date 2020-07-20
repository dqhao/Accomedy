using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accomedy.WebBackend.Model
{
    public class UserModel
    {
        public Guid user_id { get; set; }

        public string user_name { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string email { get; set; }

        public string address { get; set; }

        public string phone { get; set; }
    }
}
