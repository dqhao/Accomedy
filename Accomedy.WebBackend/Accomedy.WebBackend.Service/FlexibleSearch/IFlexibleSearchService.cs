using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accomedy.WebBackend.Service.FlexibleSearch
{
    using System.Collections.Generic;
    using System.Reflection;

    public interface IFlexibleSearchService
    {
        IList<string> Inspect<TSearchResult>(IDictionary<string, object> searchCriteria, string sortedBy);

        string AnalyzeSearchCriteria<TSearchResult>(IDictionary<string, object> searchCriteria);

        string AnalyzeSearchCriteria(IDictionary<string, object> searchCriteria);

        PropertyInfo WhichSortingField<TSearchResult>(string sortedBy);
    }
}
