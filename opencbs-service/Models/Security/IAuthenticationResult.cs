using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCBS.Online.Service.Models.Security
{
    public interface IAuthenticationResult
    {
        bool IsValid { get; set; }
        string AccessToken { get; set; }
        string Message { get; set; }
        DateTime? IssuedAt { get; set; }
    }
}
