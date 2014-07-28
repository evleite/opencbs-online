using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCBS.Online.Service.Data
{
    public interface IDataConnection
    {
        int Execute(string sql, dynamic param = null);

        IEnumerable<T> Query<T>(string sql, object p);
    }
}
