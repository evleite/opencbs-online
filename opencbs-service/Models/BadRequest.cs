using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenCBS.Online.Service.Models
{
    public class BadRequest : IBadRequest
    {
        public string Message { get; set; }
    }
}