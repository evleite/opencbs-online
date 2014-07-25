using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenCBS.Online.Service
{
    public class OpenGuid : IOpenGuid
    {
        public Guid New()
        {
            return Guid.NewGuid();
        }
    }
}