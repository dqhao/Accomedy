using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Accomedy.WebBackend.Service.FlexibleSearch
{
    public class TextSearchRegrex
    {
        [XmlAttribute]
        public string Value { get; set; }
    }
}
