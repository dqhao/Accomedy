using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accomedy.WebBackend.Model;
using Accomedy.WebBackend.Share;

namespace Accomedy.WebBackend.Business
{
    public interface IGenericCrudManager<TModel, TKey>
        where TModel : class
        where TKey : class
    {
        bool IsValidKey(TKey key);

        IList<string> InspectFlexibleSearch(SearchModel criteria);

        bool IsExisted(TKey id);


        TModel GetDetailById(TKey id);

        TPagination<TModel> Search(SearchModel criteria);

        TModel Create(TModel model);

        TModel Edit(TModel changedModel);

        bool Delete(TKey id);

        bool Delete(TKey[] ids);
    
}
}
