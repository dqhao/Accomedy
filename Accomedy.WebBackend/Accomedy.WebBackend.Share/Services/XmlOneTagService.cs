using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Accomedy.WebBackend.Share.Services
{
    public class XmlOneTagService : IXmlService
    {
        #region Properties
        protected string TagName
        {
            get
            {
                return _tagOne;
            }
        }

        #endregion

        #region Constructors
        public XmlOneTagService(string tagOne)
        {
            _tagOne = tagOne;
        }
        #endregion

        #region Overrides
        public string Serialize<TModel>(TModel model) where TModel : class
        {
            var doc = new XmlDocument();
            var elm = doc.CreateElement(TagName);
            foreach (PropertyInfo prop in typeof(TModel).GetProperties())
            {
                var val = prop.GetValue(model);
                if (val != null)
                {
                    DateTime dt;
                    if (DateTime.TryParse(val.ToString(), out dt) && !val.ToString().Contains(","))
                    {
                        var dateString = dt.ToShortDateString();
                        dt = DateTime.Parse(dateString);
                        elm.SetAttribute(prop.Name, dt.ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'"));
                    }
                    else if (val is bool)
                    {
                        elm.SetAttribute(prop.Name, ((bool)val) ? "1" : "0");
                    }
                    else
                    {
                        elm.SetAttribute(prop.Name, val.ToString());
                    }

                }
            }

            return elm.OuterXml;
        }
        #endregion

        #region Attributes
        private string _tagOne;
        #endregion
    }
}
