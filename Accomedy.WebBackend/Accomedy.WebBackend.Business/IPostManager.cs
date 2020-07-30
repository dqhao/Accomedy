using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accomedy.WebBackend.Model;

namespace Accomedy.WebBackend.Business
{
    public interface IPostManager : IGenericCrudManager<PostModel, string>
    {
    }
}
