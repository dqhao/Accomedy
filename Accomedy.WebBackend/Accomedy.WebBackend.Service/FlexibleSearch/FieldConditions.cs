using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Accomedy.WebBackend.Service.FlexibleSearch
{
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
