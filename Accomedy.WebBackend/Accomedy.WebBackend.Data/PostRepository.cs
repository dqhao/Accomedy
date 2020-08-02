using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Accomedy.WebBackend.Api.Common;
using Accomedy.WebBackend.Entities;
using Accomedy.WebBackend.Share;
using Accomedy.WebBackend.Share.Common;

namespace Accomedy.WebBackend.Data
{
    public class PostRepository : IPostRepository
    {
        string connStr = ConfigurationManager.ConnectionStrings["AccomedyConnection"].ToString();
        ConnectDB _connDb;
        ConvertCommon<POST> _convertDT2List;

        public PostRepository()
        {
            _connDb = new ConnectDB(connStr);
            _convertDT2List = new ConvertCommon<POST>();
        }


        public bool Delete(string key)
        {
            throw new NotImplementedException();
        }

        public bool DeleteMany(string[] keys)
        {
            throw new NotImplementedException();
        }

        public TPagination<POST> Find(string xmlSearchFields, PropertyInfo sortingField, SortingEnum sortingDesc, int pageNumber, int pageCount)
        {
            TPagination<POST> result = new TPagination<POST>();
            string sql = string.Format(@"DECLARE @RountCow INT; 
                                        EXEC [dbo].[wsp_flexible_search_post]   @searchFields = '{0}',
                                                                                @sortingField = '{1}',
                                                                                @sortingDesc = '{2}',
                                                                                @pageNumber = {3},
                                                                                @rowsPerPage = {4},
                                                                                @RountCow = @RountCow OUTPUT
                                        SELECT @RountCow", xmlSearchFields.Replace("'", "''"), sortingField.Name, sortingDesc, pageNumber, pageCount);

            var data = _connDb.GetData(sql);

            result.Items = _convertDT2List.ConvertDataTable<POST>(data.Tables[0]);
            result.Total = (int) data.Tables[1].Rows[0].ItemArray[0];

            return result;
        }

        public POST Get(string key)
        {

            string sql = string.Format(@"EXEC [dbo].[wsp_get_post_detail] @POST_ID = '{0}'", key);

            var data = _connDb.GetData(sql);
            return _convertDT2List.ConvertDataTable<POST>(data.Tables[0]).First();
        }

        public POST Insert(POST entNew)
        {
            throw new NotImplementedException();
        }

        public bool IsExisting(string key)
        {
            throw new NotImplementedException();
        }

        public POST Update(POST entChanged)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> Validate(POST animal, string type)
        {
            throw new NotImplementedException();
        }
    }
}
