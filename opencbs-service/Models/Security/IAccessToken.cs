using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenCBS.Online.Service.Models.Security
{
    public interface IAccessToken
    {
        string Token { get; set; }
        DateTime IssuedAt { get; set; }
        
    }
}