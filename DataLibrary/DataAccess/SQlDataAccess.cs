using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//adding below 
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataLibrary.DataAccess
{
    public static class SQlDataAccess
    {
        //public static string GetConnectionString(string connectionName = "MVCDemoDB")
        //{
        //    return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        //}

        public static List<T> LoadData<T>(string sql, string conString)
        {
            using (IDbConnection cnn = new SqlConnection(conString))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }

        public static int SaveData<T>(string sql, T data, string conString)
        {
            using (IDbConnection cnn = new SqlConnection(conString))
            {
                return cnn.Execute(sql, data);
            }
        }

        public static int SaveDataWorker<T>(string sql, T data, string conString)
        {
            using (IDbConnection cnn = new SqlConnection(conString))
            {
                return cnn.Execute(sql,data);
            }
        }

    }
}
