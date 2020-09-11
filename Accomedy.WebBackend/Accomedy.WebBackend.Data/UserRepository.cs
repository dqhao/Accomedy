using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Accomedy.WebBackend.Entities;
using Accomedy.WebBackend.Share;

namespace Accomedy.WebBackend.Data
{
    public class UserRepository : IUserRepository
    {
        public bool Delete(string key)
        {
            throw new NotImplementedException();
        }

        public bool DeleteMany(string[] keys)
        {
            throw new NotImplementedException();
        }

        public TPagination<USER> Find(string xmlSearchFields, PropertyInfo sortingField, SortingEnum sortingDesc, int pageNumber, int pageCount)
        {
            throw new NotImplementedException();
        }

        public USER Get(string key)
        {
            throw new NotImplementedException();
        }

        public bool Insert(USER entNew)
        {
            throw new NotImplementedException();
        }

        public bool IsExisting(string key)
        {
            throw new NotImplementedException();
        }

        public USER Update(USER entChanged)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> Validate(USER animal, string type)
        {
            throw new NotImplementedException();
        }

        
    }
}
