using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCBS.Online.Service.Models.Security
{
    public interface IAuthenticationRequest
    {
        String Username { get; set; }
        string Password { get; set; }
        bool IsValid { get; }
    }
}
