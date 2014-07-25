using OpenCBS.Online.Service.Models;
using OpenCBS.Online.Service.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCBS.Online.Service.Security
{
    public interface IAuthenticationService
    {
        IAuthenticationResult Authenticate(String username, String password);

        IBadRequest InvalidRequest();

        IBadRequest ErrorRequest();
    }
}
