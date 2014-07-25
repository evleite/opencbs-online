using Newtonsoft.Json;
using NUnit.Framework;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCBS.Online.Service.Extensions;
using OpenCBS.Online.Service.Models.Security;
using OpenCBS.Online.Service.Json;

namespace OpenCBS.Online.Service.Test
{
    [TestFixture]
    public class JsonIocSerializerTest
    {
        [Test]
        public void InstantiationTest()
        {
            // Given
            IContainer container = new Container();
            container.RegisterForApplication();
            var bodyDyn = new { username = "admin", password = "success-password" };
            var jsonString = "{\"username\":\"admin\",\"password\":\"success-password\"}";
            
            // When (Deserialize with actual object
            var result1 = JsonConvert.DeserializeObject<AuthenticationRequest>(jsonString);
            
            // Then
            Assert.AreEqual(result1.Username, "admin");
            Assert.AreEqual(result1.Password, "success-password");
            Assert.IsInstanceOf<AuthenticationRequest>(result1);

            // When (Deserialize with Custom IOC converter
            var result2 = JsonConvert.DeserializeObject<IAuthenticationRequest>(jsonString, new JsonIocSerializer<IAuthenticationRequest>(container));

            // Then
            Assert.AreEqual(result2.Username, "admin");
            Assert.AreEqual(result2.Password, "success-password");
            Assert.IsInstanceOf<AuthenticationRequest>(result2);

            // When
            //var result = TestHelper.JsonBodyPost(RouterPattern.Security.Authenticate, bodyDyn);
            //AuthenticationRequest
            //JsonConvert.DeserializeObject<List<IPerson>>(json, new PersonConverter());
        }
    }
}
