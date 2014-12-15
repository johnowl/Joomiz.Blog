using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joomiz.Blog.Repository.Helper
{
    public class SqlHelper
    {
        public static SqlConnection GetConnection()
        {
            string connectionName = ConfigurationManager.AppSettings["CurrentSqlConnectionName"];

            if(string.IsNullOrEmpty(connectionName))
                throw new Exception(string.Format("App setting with name CurrentSqlConnectionName not found in configuration file.", connectionName));

            return GetConnection(connectionName);
        }

        public static SqlConnection GetConnection(string connectionName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
                throw new Exception(string.Format("Connection string with name {0} not found.", connectionName));

            var connection = new SqlConnection(connectionString);
            connection.Open();

            return connection;
        }
    }
}
