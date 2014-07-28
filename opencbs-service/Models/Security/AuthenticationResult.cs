using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenCBS.Online.Service.Models.Security
{
    public class AuthenticationResult : IAuthenticationResult
    {

        public string AccessToken { get; set; }

        public bool IsValid { get; set; }

        public string Message { get; set; }

        public DateTime? IssuedAt { get; set; }
    }
}