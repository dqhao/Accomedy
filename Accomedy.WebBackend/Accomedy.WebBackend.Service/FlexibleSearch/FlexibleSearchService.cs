using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Accomedy.WebBackend.Share.Services;
using Newtonsoft.Json.Linq;

namespace Accomedy.WebBackend.Service.FlexibleSearch
{
    public class FlexibleSearchService : IFlexibleSearchService
    {
        #region Properties
        protected IXmlService XmlSvc
        {
            get
            {
                return xmlSvc;
            }
        }
        #endregion

        #region Constructors
        public FlexibleSearchService(IXmlService svcXml)
        {
            xmlSvc = svcXml;
        }
        #endregion

        #region Overrides
        public string AnalyzeSearchCriteria<TSearchResult>(IDictionary<string, object> searchCriteria)
        {
            string analyzedCriteria = null;
            if (searchCriteria != null)
            {
                analyzedCriteria = ToStandardSearchCriteria(searchCriteria);
            }

            return analyzedCriteria;
        }

        public string AnalyzeSearchCriteria(IDictionary<string, object> searchCriteria)
        {
            string analyzedCriteria = null;
            if (searchCriteria != null)
            {
                var sqlValues = FlexibleSearchService.Parse2SqlValues(searchCriteria);

                var fieldCriterias = sqlValues.Where(sc => !sc.Value.Contains(",") && !sc.Value.Contains("%"))
                                        .ToDictionary(sc => sc.Key, sc => sc.Value);
                var fieldConditions = FlexibleSearchService.CollectFieldConditions(fieldCriterias);

                var regexCriterias = sqlValues.Where(sc => sc.Value.Contains(",") || sc.Value.Contains("%"))
                                        .ToDictionary(sc => sc.Key, sc => sc.Value);
                var searchRegexs = FlexibleSearchService.CollectSearchRegexs(regexCriterias);

                var numberFields = searchCriteria.Sum(sc => sc.Key.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Length);
                if (numberFields == (fieldConditions.Count + searchRegexs.Count))
                {
                    StringBuilder criteriaBuilder = new StringBuilder();

                    if (fieldConditions.Count > 0)
                    {
                        criteriaBuilder.Append(XmlSvc.Serialize(fieldConditions));
                    }

                    if (searchRegexs.Count > 0)
                    {
                        criteriaBuilder.Append(XmlSvc.Serialize(searchRegexs));
                    }

                    analyzedCriteria = criteriaBuilder.ToString();
                }
            }

            return analyzedCriteria;
        }

        public IList<string> Inspect<TSearchResult>(IDictionary<string, object> searchCriteria, string sortedBy)
        {
            var issues = new List<string>();

            if (searchCriteria == null)
            {
                issues.Add(string.Format("Invalid Search Criterias"));
            }
            else
            {
                var invalidCriterias = searchCriteria.Keys.Where(sc => (typeof(TSearchResult).GetProperty(sc ?? string.Empty)) == null).ToArray();
                if (invalidCriterias.Length > 0)
                {
                    issues.AddRange(invalidCriterias.Select(ic => string.Format("Invalid Criteria {0}", ic)));
                }
            }

            var sortingProperty = WhichSortingField<TSearchResult>(sortedBy);
            if (sortingProperty == null)
            {
                issues.Add(string.Format("Invalid Sorted By {0}", sortedBy));
            }

            return issues;
        }

        public PropertyInfo WhichSortingField<TSearchResult>(string sortedBy)
        {
            return typeof(TSearchResult).GetProperty(sortedBy ?? string.Empty);
        }
        #endregion

        #region Utilities
        protected static IDictionary<string, string> Parse2SqlValues(IDictionary<string, object> searchCriteria)
        {
            var sqlValues = new Dictionary<string, string>();
            if (searchCriteria != null)
            {
                foreach (var criteria in searchCriteria)
                {
                    if (criteria.Value != null)
                    {
                        DateTime dt;
                        if (DateTime.TryParse(criteria.Value.ToString(), out dt))
                        {
                            var dateString = dt.ToShortDateString();
                            dt = DateTime.Parse(dateString); // Fix for format T00:00:00
                            sqlValues[criteria.Key] = dt.ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'");
                        }
                        else
                        {
                            var text = criteria.Value.ToString();
                            if (text.Contains(","))
                            {
                                var arrCriterias = text.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                                sqlValues[criteria.Key] = string.Join(",", arrCriterias.Select(c => string.Format("'{0}'", c.Trim())));
                            }
                            else
                            {
                                sqlValues[criteria.Key] = text;
                            }
                        }
                    }
                }
            }

            return sqlValues;
        }

        protected static string IndicateRegex(string key, string value)
        {
            string regex = string.Empty;
            if (!string.IsNullOrWhiteSpace(key) && !string.IsNullOrWhiteSpace(value))
            {
                if (value.Contains(","))
                {
                    regex = string.Format(" ({0}) IN ({1}) ", key, value);
                }
                else if (value.Contains("%"))
                {
                    regex = string.Format(" ({0}) LIKE '{1}' ", key, value);
                }
            }

            return regex;
        }

        protected static FieldConditions CollectFieldConditions(IDictionary<string, string> simpleSearchCriteria)
        {
            var fieldConditionList = new List<FieldCondition>();
            if (simpleSearchCriteria != null)
            {
                var singleCriterias = simpleSearchCriteria.Where(sc => !sc.Key.Contains(","));
                fieldConditionList = simpleSearchCriteria.Select(ssf => new FieldCondition()
                {
                    FieldName = string.Format("({0})", ssf.Key),
                    Value = ssf.Value
                }).ToList();

                var multipleCriterias = simpleSearchCriteria.Where(sc => sc.Key.Contains(","));
                foreach (var multiCriteria in multipleCriterias)
                {
                    var criterias = multiCriteria.Key.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    foreach (var cr in criterias)
                    {
                        fieldConditionList.Add(new FieldCondition()
                        {
                            FieldName = string.Format("({0})", cr),
                            Value = multiCriteria.Value
                        });
                    }
                }
            }

            return (new FieldConditions(fieldConditionList));
        }

        protected static TextSearchRegrexs CollectSearchRegexs(IDictionary<string, string> regexCriterias)
        {
            var textSearchRegrexList = new List<TextSearchRegrex>();
            if (regexCriterias != null)
            {
                var singleCriterias = regexCriterias.Where(sc => !sc.Key.Contains(","));
                textSearchRegrexList = regexCriterias.Select(ssf => new TextSearchRegrex()
                {
                    Value = IndicateRegex(ssf.Key, ssf.Value)
                }).ToList();

                var multipleCriterias = regexCriterias.Where(sc => sc.Key.Contains(","));
                foreach (var multiCriteria in multipleCriterias)
                {
                    var criterias = multiCriteria.Key.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    foreach (var cr in criterias)
                    {
                        textSearchRegrexList.Add(new TextSearchRegrex()
                        {
                            Value = IndicateRegex(cr, multiCriteria.Value)
                        });
                    }
                }
            }

            return (new TextSearchRegrexs(textSearchRegrexList));
        }


        protected string ToStandardSearchCriteria(IDictionary<string, object> searchCriteria)
        {
            var fieldConditionList = new List<FieldCondition>();
            var textSearchRegrexList = new List<TextSearchRegrex>();

            foreach (var criteria in searchCriteria)
            {
                if (criteria.Value != null)
                {
                    var key = string.Format("({0})", criteria.Key);

                    DateTime dt;
                    // ****** TYPE: DATE TIME PICKER ****** //
                    if (DateTime.TryParse(criteria.Value.ToString(), out dt))
                    {
                        var dateString = dt.ToShortDateString();
                        dt = DateTime.Parse(dateString); // Fix for format T00:00:00
                                                         // Normal condition
                        fieldConditionList.Add(new FieldCondition()
                        {
                            FieldName = key,
                            Value = dt.ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'")
                        });
                    }

                    // ****** TYPE: DROP DOWN LIST ****** //
                    else if (criteria.Value is JArray)
                    {
                        var items = criteria.Value as JArray;
                        var strItems = items.ToObject<string[]>();
                        if (strItems != null)
                        {
                            var lstItems = strItems.ToList();
                            if (lstItems.Count > 0)
                            {
                                textSearchRegrexList.Add(new TextSearchRegrex()
                                {
                                    Value = string.Format(" {0} IN ({1}) ", key, string.Join(",", lstItems.Select(val => string.Format("'{0}'", Parse2ValidConditionValue(val)))))
                                });
                            }
                        }
                    }

                    // ****** TYPE: TEXTBOX ****** //
                    else
                    {
                        var conVal = Parse2ValidConditionValue(criteria.Value.ToString());
                        if (criteria.Value.ToString().Contains("%")) // Regex condition
                        {
                            textSearchRegrexList.Add(new TextSearchRegrex()
                            {
                                Value = BuildRegexConditionScript(key, conVal)
                            });
                        }
                        else if (criteria.Value.ToString().Contains(",")) // Regex condition
                        {
                            textSearchRegrexList.Add(new TextSearchRegrex()
                            {
                                Value = BuildRegexConditionScript(key, conVal)
                            });
                        }
                        else // Normal condition
                        {
                            fieldConditionList.Add(new FieldCondition()
                            {
                                FieldName = key,
                                Value = conVal
                            });
                        }
                    }
                }
            }

            // Build final criteria script
            StringBuilder criteriaBuilder = new StringBuilder();
            if (fieldConditionList.Count > 0)
            {
                criteriaBuilder.Append(XmlSvc.Serialize(new FieldConditions(fieldConditionList)));
            }

            if (textSearchRegrexList.Count > 0)
            {
                criteriaBuilder.Append(XmlSvc.Serialize(new TextSearchRegrexs(textSearchRegrexList)));
            }

            return criteriaBuilder.ToString();
        }

        // Convert special characters to corresponding valid characters
        private static string Parse2ValidConditionValue(string value)
        {
            string result = value;
            if (!string.IsNullOrWhiteSpace(value))
            {
                if (value.Contains("'"))
                {
                    result = value.Replace("'", "''");
                }
            }
            return result;
        }
        // Build script to search with special characters
        private static string BuildRegexConditionScript(string key, string value)
        {
            string result = string.Empty;
            if (!string.IsNullOrWhiteSpace(value))
            {
                if (value.Contains("%"))
                {
                    char[] strRegex = @"\[".ToCharArray();
                    if (value.IndexOfAny(strRegex) != -1) // this case needs to be handled if value contains char %
                    {
                        result = string.Format(@" {0} LIKE '{1}' ESCAPE '\' ", key, value.Replace(@"\", @"\\").Replace("[", @"\["));
                    }
                    else
                    {
                        result = string.Format(@" {0} LIKE '{1}' ", key, value);
                    }
                }

                if (value.Contains(","))
                {
                    result = string.Format(@" {0} IN ({1}) ", key, value.Replace("''", "'"));
                }
            }
            return result;
        }
        #endregion

        #region Attributes
        private IXmlService xmlSvc;
        #endregion
    }
}
