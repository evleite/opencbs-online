using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenCBS.Online.Service.Models.Security
{
    public class AuthenticationRequest : IAuthenticationRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsValid
        {
            get
            {
                return Username.Length > 0 && Password.Length > 0;
            }
        }
    }
}