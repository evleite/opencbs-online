using Nancy;
using NLog;
using OpenCBS.Online.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenCBS.Online.Service
{
    public abstract class BaseModule : NancyModule
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        protected Response BadRequest(IBadRequest badRequest)
        {
            return Response.AsJson<IBadRequest>(badRequest, HttpStatusCode.BadRequest);
        }
        
    }
}