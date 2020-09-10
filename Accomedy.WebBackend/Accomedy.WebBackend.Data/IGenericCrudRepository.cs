using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Accomedy.WebBackend.Share;

namespace Accomedy.WebBackend.Data
{
    public interface IGenericCrudRepository<TEntity, TKey>
        where TEntity : class
        where TKey : class
    {
        bool IsExisting(TKey key);

        TEntity Get(TKey key);

        TPagination<TEntity> Find(string xmlSearchFields, PropertyInfo sortingField, SortingEnum sortingDesc, int pageNumber, int pageCount);

        bool Insert(TEntity entNew);

        TEntity Update(TEntity entChanged);

        bool Delete(TKey key);

        bool DeleteMany(TKey[] keys);

        Dictionary<string, string> Validate(TEntity animal, string type);
    }
}
