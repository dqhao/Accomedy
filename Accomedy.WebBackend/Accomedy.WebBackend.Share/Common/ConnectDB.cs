using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Accomedy.WebBackend.Api.Common
{
    public class ConnectDB
    {
        string connStr;
        public ConnectDB(string connectionString)
        {
            connStr = connectionString;
        }

        public DataSet GetData(string sqlQuery)
        {
            var dsb = new System.Data.Common.DbConnectionStringBuilder();

            dsb.ConnectionString = connStr;
            dsb.Remove("Provider");

            var ds = new DataSet();
            using (var conn = new SqlConnection(dsb.ConnectionString))
            {
                var adapter = new SqlDataAdapter(sqlQuery, conn);
                adapter.SelectCommand.CommandTimeout = 0;
                adapter.Fill(ds);
                conn.Close();
            }

            return ds;
        }
    }
}