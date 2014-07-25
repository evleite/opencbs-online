using NUnit.Framework;
using OpenCBS.Online.Service.Models.Security;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCBS.Online.Service;
using OpenCBS.Online.Service.Extensions;
using OpenCBS.Online.Service.Security;

namespace OpenCBS.Online.Service.Test
{
    [TestFixture]
    public class ApplicationRegistryTest
    {
        [Test]
        public void RegistryTest()
        {
            // create the container and register the mappings
            var container = new Container();
            container.RegisterForApplication();

            // retrieve the individual mappings and check the result
            IAuthenticationResult result = container.GetInstance<IAuthenticationResult>();
            Assert.IsInstanceOf<AuthenticationResult>(result);

            IAuthenticationService authenticationService = container.GetInstance<IAuthenticationService>();
            Assert.IsInstanceOf<AuthenticationService>(authenticationService);

            // TODO check what to do with all this, why is the Bootstrapper version not static available, do I need to pass it around?
            ObjectFactory.Configure(o => o.AddRegistry<ApplicationRegistry>());

            IAuthenticationResult result2 = ObjectFactory.GetInstance<IAuthenticationResult>();
            Assert.IsInstanceOf<AuthenticationResult>(result2);

            
        }
    }
}
