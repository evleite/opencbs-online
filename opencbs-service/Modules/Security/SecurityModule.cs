using Nancy;
using OpenCBS.Online.Service.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy.ModelBinding;
using Newtonsoft.Json;
using System.IO;
using StructureMap;
using OpenCBS.Online.Service.Security;
using NLog;
using OpenCBS.Online.Service.Json;
using OpenCBS.Online.Service.Models;

namespace OpenCBS.Online.Service.Modules.Security
{
    public class SecurityModule : BaseModule
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public SecurityModule(IContainer container, IAuthenticationService authenticationService)
        {
            logger.Debug("Instantiate SecurityModule.");

            Post[RouterPattern.Security.VerifyToken] = (parameters =>
            {                
                return parameters;
            });

            Get[RouterPattern.Security.Authenticate] = (parameters =>
            {
                return "test";
            });

            Post[RouterPattern.Security.Authenticate] = parameters =>
            {                
                try
                {
                    var authenticationBody = new StreamReader(this.Request.Body).ReadToEnd();

                    logger.Debug("DeserializeObject IAuthenticationRequest.");
                    var authenticationRequest = JsonIocConvert.DeserializeObject<IAuthenticationRequest>(authenticationBody, container);
                    
                    // check whether the request is valid
                    if (authenticationRequest.IsValid)
                    {
                        logger.Debug("IAuthenticationRequest is valid.");
                        
                        // authenticate the user
                        var authenticatonResult = authenticationService.Authenticate(authenticationRequest.Username, authenticationRequest.Password);
                        
                        // return authentication results as JSON
                        return Response.AsJson<IAuthenticationResult>(authenticatonResult);
                    }
                    else
                    {
                        logger.Warn("IAuthenticationRequest is not valid.");
                        return BadRequest(authenticationService.InvalidRequest());                        
                    }                    
                }
                catch (Exception e)
                {
                    logger.Error(e);
                    // TODO move this away from authentication service (inner method call)
                    return BadRequest(authenticationService.ErrorRequest());
                }
            };          
        }
    }
}