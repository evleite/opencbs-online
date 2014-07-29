using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenCBS.Online.Service
{
    public class RouterPattern
    {
        public static class Security
        {
            public static readonly string Authenticate = "/security/authenticate";
            public static readonly string VerifyToken = "/security/verifytoken";
        }
    }
}