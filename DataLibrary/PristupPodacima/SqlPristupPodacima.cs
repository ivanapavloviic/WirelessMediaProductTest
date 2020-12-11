using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataLibrary.PristupPodacima
{
    public class SqlPristupPodacima
    {
        public static string GetConnectionString(string connName = "Baza")
        {
            return ConfigurationManager.ConnectionStrings[connName].ConnectionString;
        }

        public static List<T> UcitajPodatke<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).ToList();

            }
        }
        public static int SacuvajPodatke<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql, data);

            }
        }
    }
}
