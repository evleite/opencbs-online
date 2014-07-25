using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCBS.Online.Service.Data
{
    public interface IConnectionManager
    {
        SqlConnection Get();
    }
}
