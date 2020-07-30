using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accomedy.WebBackend.Entities;

namespace Accomedy.WebBackend.Data
{
    public interface IPostRepository : IGenericCrudRepository<POST, string>
    {
    }
}
