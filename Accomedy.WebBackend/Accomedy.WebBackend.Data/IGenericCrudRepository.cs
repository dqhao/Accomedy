using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accomedy.WebBackend.Model;

namespace Accomedy.WebBackend.Data
{
    public interface IGenericCrudRepository<TModel, TKey>
        where TModel: class
    {
        bool IsValid(TKey id);

        bool IsExist(TKey id);

        TModel Insert(TModel newModel);

        TModel GetById(TKey id);

        TModel Find(SearchModel criteria);

        bool Update(TKey id, TModel newModel);

        bool Delete(TKey id);
    }
}
