using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accomedy.WebBackend.Share.Services
{
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;

    public class XmlService : IXmlService
    {
        #region Constructors
        public XmlService()
        {
        }
        #endregion

        #region Overrides
        public string Serialize<TModel>(TModel model) where TModel : class
        {
            string strXml = null;
            using (StringWriter sWriter = new StringWriter())
            {
                XmlWriterSettings xmlSettings = new XmlWriterSettings()
                {
                    OmitXmlDeclaration = true
                };
                XmlWriter xmlWriter = XmlWriter.Create(sWriter, xmlSettings);

                XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
                xmlNamespaces.Add(string.Empty, string.Empty);

                XmlSerializer serializer = new XmlSerializer(typeof(TModel));
                serializer.Serialize(xmlWriter, model, xmlNamespaces);

                strXml = sWriter.ToString();
            }

            return strXml;
        }
        #endregion
    }
}
