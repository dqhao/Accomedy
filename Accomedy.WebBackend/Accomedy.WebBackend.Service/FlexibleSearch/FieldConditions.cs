using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accomedy.WebBackend.Service.FlexibleSearch
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot(nameof(FieldConditions))]
    public class FieldConditions : List<FieldCondition>
    {
        #region Constructors
        public FieldConditions(IList<FieldCondition> fieldConditionList)
            : base(fieldConditionList)
        {
        }
        #endregion
    }
}
