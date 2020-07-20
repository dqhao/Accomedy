using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accomedy.WebBackend.Model;

namespace Accomedy.WebBackend.Data
{
    public class PostRepository : IPostRepository
    {

        #region Overrides
        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public PostModel Find(SearchModel criteria)
        {
            throw new NotImplementedException();
        }

        public PostModel GetById(string id)
        {
            throw new NotImplementedException();
        }

        public PostModel Insert(PostModel newModel)
        {
            throw new NotImplementedException();
        }

        public bool IsExist(string id)
        {
            throw new NotImplementedException();
        }

        public bool IsValid(string id)
        {
            throw new NotImplementedException();
        }

        public bool Update(string id, PostModel newModel)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
