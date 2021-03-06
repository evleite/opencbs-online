﻿using System;
using Nancy.Testing;
using OpenCBS.Online.Service;
using Nancy.Bootstrapper;
using NUnit.Framework;
using Nancy;
using Newtonsoft.Json;
using OpenCBS.Online.Service.Models.Security;
using OpenCBS.Online.Service.Models;
using OpenCBS.Online.Service.Security;
using Rhino.Mocks;
using StructureMap;

namespace OpenCBS.Online.Service.Test.Modules
{
    [TestFixture]
    public class SecurityModuleTest
    {
        [Test]
        public void SuccesfulAuthenticationTest()
        {
            // Given
            // create mocks
            var mockAuthenticationService = MockRepository.GenerateStub<IAuthenticationService>();
            var authenticationResultStub = new AuthenticationResult { AccessToken = "access-token", IsValid = true, Message = Resources.Content.AuthenticationResult_Success };
            mockAuthenticationService.Stub(x => x.Authenticate("admin", "success-password")).Return(authenticationResultStub);

            // insert mock in the IoC container
            var bootstrapper = new Bootstrapper();
            var browser = new Browser(bootstrapper);
            bootstrapper.Container.EjectAllInstancesOf<IAuthenticationService>();
            bootstrapper.Container.Inject<IAuthenticationService>(mockAuthenticationService);

            var bodyDyn = new { username = "admin", password = "success-password" };

            // When
            var result = TestHelper.JsonBodyPost(RouterPattern.Security.Authenticate, bodyDyn, bootstrapper, browser);

            // Then
            mockAuthenticationService.AssertWasCalled(x => x.Authenticate("admin", "success-password"));

            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            var authenticationResult = JsonConvert.DeserializeObject<AuthenticationResult>(result.Body.AsString());

            Assert.AreEqual(true, authenticationResult.IsValid);
            Assert.AreEqual("access-token", authenticationResult.AccessToken);
            Assert.AreEqual(Resources.Content.AuthenticationResult_Success, authenticationResult.Message);
        }

        [Test]
        public void FailedAuthenticationTest()
        {
            // Given
            // create mocks
            var mockAuthenticationService = MockRepository.GenerateStub<IAuthenticationService>();
            var authenticationResultStub = new AuthenticationResult { AccessToken = null, IsValid = true, Message = Resources.Content.AuthenticationResult_Failed };
            mockAuthenticationService.Stub(x => x.Authenticate("admin", "failing-password")).Return(authenticationResultStub);

            // insert mock in the IoC container
            var bootstrapper = new Bootstrapper();
            var browser = new Browser(bootstrapper);
            bootstrapper.Container.EjectAllInstancesOf<IAuthenticationService>();
            bootstrapper.Container.Inject<IAuthenticationService>(mockAuthenticationService);

            var bodyDyn = new { username = "admin", password = "failing-password" };

            // When
            var result = TestHelper.JsonBodyPost(RouterPattern.Security.Authenticate, bodyDyn, bootstrapper, browser);

            // Then
            mockAuthenticationService.AssertWasCalled(x => x.Authenticate("admin", "failing-password"));

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
            var bodyDyn = new { dummyvar = "admin", password = "success-password" };

            // When
            var result = TestHelper.JsonBodyPost(RouterPattern.Security.Authenticate, bodyDyn);

            // Then
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
            var badRequest = JsonConvert.DeserializeObject<BadRequest>(result.Body.AsString());
            Assert.AreEqual(Resources.Content.AuthenticationResult_ErrorRequest, badRequest.Message);
        }

        [Test]
        public void InvalidAuthenticationRequestTest()
        {
            // Given
            var bodyDyn = new { username = "", password = "success-password" };

            // When
            var result = TestHelper.JsonBodyPost(RouterPattern.Security.Authenticate, bodyDyn);

            // Then
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
            var badRequest = JsonConvert.DeserializeObject<BadRequest>(result.Body.AsString());
            Assert.AreEqual(Resources.Content.AuthenticationResult_InvalidRequest, badRequest.Message);
        }

        [Test]
        public void SystemExceptionAuthenticationRequestTest()
        {
            var badRequest = new BadRequest();
            badRequest.Message = "error";
            
            var mockAuthenticationService = MockRepository.GenerateStub<IAuthenticationService>();
            mockAuthenticationService.Stub(x => x.Authenticate("admin", "success-password")).Throw(new Exception());
            mockAuthenticationService.Stub(x => x.ErrorRequest()).Return(badRequest);


            // insert mock in the IoC container
            var bootstrapper = new Bootstrapper();
            var browser = new Browser(bootstrapper);
            bootstrapper.Container.EjectAllInstancesOf<IAuthenticationService>();
            bootstrapper.Container.Inject<IAuthenticationService>(mockAuthenticationService);

            var bodyDyn = new { username = "admin", password = "success-password" };

            // When
            var result = TestHelper.JsonBodyPost(RouterPattern.Security.Authenticate, bodyDyn, bootstrapper, browser);

            // Then
            mockAuthenticationService.AssertWasCalled(x => x.Authenticate("admin", "success-password"));
            mockAuthenticationService.AssertWasCalled(x => x.ErrorRequest());

            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
            var badRequestResult = JsonConvert.DeserializeObject<BadRequest>(result.Body.AsString());
            Assert.AreEqual("error", badRequestResult.Message);
        }

        [Test]
        public void ReAuthenticationTest()
        {
            var mockAuthenticationService = MockRepository.GenerateStub<IAuthenticationService>();
            var mockAuthenticationService2 = MockRepository.GenerateStub<IAuthenticationService>();
            var authenticationResultStub = new AuthenticationResult { AccessToken = "access-token", IsValid = true, Message = Resources.Content.AuthenticationResult_Success, IssuedAt = new DateTime(2014, 10, 21, 14, 55, 43) };
            var authenticationResultStub2 = new AuthenticationResult { AccessToken = "access-token", IsValid = true, Message = Resources.Content.AuthenticationResult_ExistingToken, IssuedAt = new DateTime(2014, 10, 21, 14, 55, 43) };
            mockAuthenticationService.Stub(x => x.Authenticate("admin", "success-password")).Return(authenticationResultStub);
            mockAuthenticationService2.Stub(x => x.Authenticate("admin", "success-password")).Return(authenticationResultStub2);

            // insert mock in the IoC container
            var bootstrapper = new Bootstrapper();
            var browser = new Browser(bootstrapper);
            bootstrapper.Container.EjectAllInstancesOf<IAuthenticationService>();
            bootstrapper.Container.Inject<IAuthenticationService>(mockAuthenticationService);

            var bodyDyn = new { username = "admin", password = "success-password" };

            // When
            var result = TestHelper.JsonBodyPost(RouterPattern.Security.Authenticate, bodyDyn, bootstrapper, browser);

            // Then
            mockAuthenticationService.AssertWasCalled(x => x.Authenticate("admin", "success-password"));
            
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            var authenticationResult = JsonConvert.DeserializeObject<AuthenticationResult>(result.Body.AsString());

            Assert.AreEqual(true, authenticationResult.IsValid);
            Assert.AreEqual("access-token", authenticationResult.AccessToken);
            Assert.AreEqual(Resources.Content.AuthenticationResult_Success, authenticationResult.Message);
            Assert.AreEqual(new DateTime(2014, 10, 21, 14, 55, 43), authenticationResult.IssuedAt);

            bootstrapper.Container.EjectAllInstancesOf<IAuthenticationService>();
            bootstrapper.Container.Inject<IAuthenticationService>(mockAuthenticationService2);

            var bodyDyn2 = new { username = "admin", password = "success-password" };

            // When
            var result2 = TestHelper.JsonBodyPost(RouterPattern.Security.Authenticate, bodyDyn2, bootstrapper, browser);

            // Then
            mockAuthenticationService2.AssertWasCalled(x => x.Authenticate("admin", "success-password"));
                        
            Assert.AreEqual(HttpStatusCode.OK, result2.StatusCode);
            var authenticationResult2 = JsonConvert.DeserializeObject<AuthenticationResult>(result2.Body.AsString());

            Assert.AreEqual(true, authenticationResult2.IsValid);
            Assert.AreEqual("access-token", authenticationResult2.AccessToken);
            Assert.AreEqual(Resources.Content.AuthenticationResult_ExistingToken, authenticationResult2.Message);
            Assert.AreEqual(new DateTime(2014, 10, 21, 14, 55, 43), authenticationResult2.IssuedAt);
        }
    }
}
