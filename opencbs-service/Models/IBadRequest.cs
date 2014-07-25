using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCBS.Online.Service.Models
{
    public interface IBadRequest
    {
        string Message { get; set; }
    }
}
