using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accomedy.WebBackend.Service.FlexibleSearch
{
    using System.Xml.Serialization;

    public class TextSearchRegrex
    {
        [XmlAttribute]
        public string Value { get; set; }
    }
}
