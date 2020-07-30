using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accomedy.WebBackend.Entities;
using Accomedy.WebBackend.Model;
using ExpressMapper;

namespace Accomedy.WebBackend.Business.Mappers
{
    public class PostMapper : IObjectMapper
    {
        #region Overrides
        public void Register()
        {
            Mapper.Register<POST, PostModel>();
            Mapper.Register<PostModel, POST>();
        }
        #endregion
    }
}
