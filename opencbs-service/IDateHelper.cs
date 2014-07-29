using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCBS.Online.Service
{
    public interface IDateHelper
    {
        DateTime Now { get; }

        bool IsWithinTimeOutLimit(DateTime toCheck);
    }
}
