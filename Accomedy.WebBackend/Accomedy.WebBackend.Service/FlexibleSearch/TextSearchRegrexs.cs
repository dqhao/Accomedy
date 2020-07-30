using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accomedy.WebBackend.Service.FlexibleSearch
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot(nameof(TextSearchRegrexs))]
    public class TextSearchRegrexs : List<TextSearchRegrex>
    {
        #region Constructors
        public TextSearchRegrexs(IList<TextSearchRegrex> searchRegexs)
            : base(searchRegexs)
        {
        }
        #endregion
    }
}
