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
using OpenCBS.Online.Service.IntegrationTest;

namespace OpenCBS.Online.Service.IntegrationTest.Modules
{
    [TestFixture]
    public class SecurityModuleTest
    {
        [SetUp]
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

        [Test]
        public void ReAuthenticationTest()
        {
            var bootstrapper = new Bootstrapper();
            var browser = new Browser(bootstrapper);
            
            var bodyDyn = new { username = "admin", password = "admin" };

            var result = browser.Post(RouterPattern.Security.Authenticate, with =>
            {
                with.Body(JsonConvert.SerializeObject(bodyDyn), "application/json");
                with.HttpRequest();
            });
            
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            var authenticationResult = JsonConvert.DeserializeObject<AuthenticationResult>(result.Body.AsString());

            Assert.AreEqual(true, authenticationResult.IsValid);
            Assert.AreEqual(Resources.Content.AuthenticationResult_Success, authenticationResult.Message);
        
            // re-authenticate and check whether token and issueAt are the same
            var bodyDyn2 = new { username = "admin", password = "admin" };

            var result2 = browser.Post(RouterPattern.Security.Authenticate, with =>
            {
                with.Body(JsonConvert.SerializeObject(bodyDyn2), "application/json");
                with.HttpRequest();
            });
            
            Assert.AreEqual(HttpStatusCode.OK, result2.StatusCode);
            var authenticationResult2 = JsonConvert.DeserializeObject<AuthenticationResult>(result2.Body.AsString());

            Assert.AreEqual(authenticationResult.IsValid, authenticationResult2.IsValid);
            Assert.AreEqual(authenticationResult.AccessToken, authenticationResult2.AccessToken);
            Assert.AreEqual(authenticationResult.Message, authenticationResult2.Message);
            Assert.IsTrue(authenticationResult.IssuedAt.Value.SqlEquals(authenticationResult2.IssuedAt.Value));
            
            // authenticate with different user and check whether token and issueAt are different
            var bodyDyn3 = new { username = "testuser", password = "testpassword" };

            var result3 = browser.Post(RouterPattern.Security.Authenticate, with =>
            {
                with.Body(JsonConvert.SerializeObject(bodyDyn3), "application/json");
                with.HttpRequest();
            });

            Assert.AreEqual(HttpStatusCode.OK, result3.StatusCode);
            var authenticationResult3 = JsonConvert.DeserializeObject<AuthenticationResult>(result3.Body.AsString());

            Assert.AreEqual(true, authenticationResult3.IsValid);
            Assert.AreEqual(Resources.Content.AuthenticationResult_Success, authenticationResult3.Message);
            
            Assert.AreNotEqual(authenticationResult.AccessToken, authenticationResult3.AccessToken);
            Assert.AreNotEqual(authenticationResult.IssuedAt, authenticationResult3.IssuedAt);
            
        }
    }
}
