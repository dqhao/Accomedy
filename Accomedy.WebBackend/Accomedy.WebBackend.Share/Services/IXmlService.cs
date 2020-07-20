using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accomedy.WebBackend.Share.Services
{
    public interface IXmlService
    {
        string Serialize<TModel>(TModel model) where TModel : class;
    }
}
