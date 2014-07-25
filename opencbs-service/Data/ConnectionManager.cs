using OpenCBS.Online.Service.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OpenCBS.Online.Service.Data
{
    public class ConnectionManager : IConnectionManager
    {
        public SqlConnection Get()
        {
            return new SqlConnection(Settings.ConnectionString);
        }

    }
}