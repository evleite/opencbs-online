using System;
using Nancy.Testing;
using OpenCBS.Online.Service;
using Nancy.Bootstrapper;
using NUnit.Framework;
using Nancy;
using Newtonsoft.Json;
using OpenCBS.Online.Service.Models.Security;
using OpenCBS.Online.Service.Models;
using OpenCBS.Online.Service.Security;
using StructureMap;

namespace OpenCBS.Online.Service.IntegrationTest.Modules
{
    [TestFixture]
    public class SecurityModuleTest
    {
        [TestFixtureSetUp]
        public void SetUp()
        {
            TestHelper.DeleteTestData();
            TestHelper.InsertTestData();
        }

        [Test]
        public void SuccesfulAuthenticationTest()
        {
            // Given
            var browser = new Browser(new Bootstrapper());
            var bodyDyn = new { username = "admin", password = "admin" };

            // When
            var result = browser.Post(RouterPattern.Security.Authenticate, with =>
            {
                with.Body(JsonConvert.SerializeObject(bodyDyn), "application/json");
                with.HttpRequest();
            });

            
            // Then
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            var authenticationResult = JsonConvert.DeserializeObject<AuthenticationResult>(result.Body.AsString());

            Assert.AreEqual(true, authenticationResult.IsValid);
            Assert.AreEqual(Resources.Content.AuthenticationResult_Success, authenticationResult.Message);
        }

        [Test]
        public void FailedAuthenticationTest()
        {
            // Given
            
            // insert mock in the IoC container
            var browser = new Browser(new Bootstrapper());
            
            var bodyDyn = new { username = "admin", password = "failing-password" };

            // When
            var result = browser.Post(RouterPattern.Security.Authenticate, with =>
            {
                with.Body(JsonConvert.SerializeObject(bodyDyn), "application/json");
                with.HttpRequest();
            });

            // Then
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            var authenticationResult = JsonConvert.DeserializeObject<AuthenticationResult>(result.Body.AsString());

            Assert.AreEqual(true, authenticationResult.IsValid);
            Assert.AreEqual(null, authenticationResult.AccessToken);
            Assert.AreEqual(Resources.Content.AuthenticationResult_Failed, authenticationResult.Message);
        }

        [Test]
        public void ExceptionAuthenticationRequestTest()
        {
            // Given
            var browser = new Browser(new Bootstrapper());
            var bodyDyn = new { dummyvar = "admin", password = "success-password" };

            // When
            var result = browser.Post(RouterPattern.Security.Authenticate, with =>
            {
                with.Body(JsonConvert.SerializeObject(bodyDyn), "application/json");
                with.HttpRequest();
            });

            // Then
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);

            var badRequest = JsonConvert.DeserializeObject<BadRequest>(result.Body.AsString());

            Assert.AreEqual(Resources.Content.AuthenticationResult_ErrorRequest, badRequest.Message);
        }

        [Test]
        public void InvalidAuthenticationRequestTest()
        {
            // Given
            var browser = new Browser(new Bootstrapper());
            var bodyDyn = new { username = "", password = "success-password" };

            // When
            var result = browser.Post(RouterPattern.Security.Authenticate, with =>
            {
                with.Body(JsonConvert.SerializeObject(bodyDyn), "application/json");
                with.HttpRequest();
            });

            // Then
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);

            var badRequest = JsonConvert.DeserializeObject<BadRequest>(result.Body.AsString());

            Assert.AreEqual(Resources.Content.AuthenticationResult_InvalidRequest, badRequest.Message);
        }
    }
}
