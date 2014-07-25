using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;
using StructureMap.Graph;
using StructureMap.Configuration.DSL;
using OpenCBS.Online.Service.Models.Security;
using OpenCBS.ArchitectureV2.Interface.Service;
using OpenCBS.ArchitectureV2.Service;
using NLog;

namespace OpenCBS.Online.Service
{
    public class ApplicationRegistry : Registry
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public ApplicationRegistry()
        {

            Scan(scanner =>
            {
                scanner.TheCallingAssembly();
                scanner.WithDefaultConventions();
                //scanner.ConnectImplementationsToTypesClosing(typeof(ICommand<>));
            });

            // not needed because of the Scan section
            //For<IAuthenticationResult>().Use<AuthenticationResult>();

            For<IAuthService>().Use<AuthService>();

        }
                
    }
}