using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCBS.Online.Service.Extensions;
using OpenCBS.Online.Service.Json;
using OpenCBS.Online.Service.Models.Security;
using StructureMap;

namespace OpenCBS.Online.Service.Test.Json
{
    [TestFixture]
    public class JsonIocConvertTest
    {
        [Test]
        public void ConversionTest()
        {
            // Given
            IContainer container = new Container();
            container.RegisterForApplication();
            var bodyDyn = new { username = "admin", password = "success-password" };
            var jsonString = "{\"username\":\"admin\",\"password\":\"success-password\"}";

            // When (Deserialize with actual object
            var result1 = JsonIocConvert.DeserializeObject<IAuthenticationRequest>(jsonString, container);

            // Then
            Assert.AreEqual(result1.Username, "admin");
            Assert.AreEqual(result1.Password, "success-password");
            Assert.IsInstanceOf<AuthenticationRequest>(result1);
                        
        }

    }
}
