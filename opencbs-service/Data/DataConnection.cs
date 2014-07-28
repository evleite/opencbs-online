using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data.SqlClient;
using OpenCBS.Online.Service.Models;

namespace OpenCBS.Online.Service.Data
{
    public class DataConnection : IDataConnection
    {
       
        public int Execute(string sql, dynamic param = null)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                return SqlMapper.Execute(connection, sql, param);
            }            
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(Settings.ConnectionString);
        }


        public IEnumerable<T> Query<T>(string sql, dynamic param = null)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                return SqlMapper.Query<T>(connection, sql, param);
            }            
        }
    }
}