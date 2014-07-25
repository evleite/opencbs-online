using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenCBS.Online.Service.Models.Security
{
    public class AccessToken : IAccessToken
    {
        public string Token { get; set; }
        public DateTime IssuedAt { get; set; }

    }
}