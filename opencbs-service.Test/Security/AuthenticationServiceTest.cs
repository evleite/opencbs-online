using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using OpenCBS.Online.Service.Security;
using StructureMap;
using OpenCBS.ArchitectureV2.Service;
using OpenCBS.Online.Service.Security.Encryption;
using OpenCBS.Online.Service.Data.Security;
using OpenCBS.Online.Service.Data;
using Rhino.Mocks;
using OpenCBS.ArchitectureV2.Interface.Service;
using OpenCBS.CoreDomain;
using OpenCBS.Online.Service.Models.Security;

namespace OpenCBS.Online.Service.Test.Security
{
    /// <summary>
    /// The text fixture for <see cref="AuthenticationServiceTest" />.
    /// </summary>
    [TestFixture]
    public class AuthenticationServiceTest
    {
        /// <summary>
        /// Test for <see cref="AuthenticationServiceTest" />.
        /// </summary>
        [Test]
        public void SuccessfulAuthenticationTest()
        {
            // create mock objects
            var mockContainer = MockRepository.GenerateStub<IContainer>();
            var mockAuthService = MockRepository.GenerateStub<IAuthService>();
            var mockAccessTokenCreator = MockRepository.GenerateStub<IAccessTokenCreator>();

            var user = new User
            {
                FirstName = "Peter",
                Id = 1,
                LastName = "Pan",
                Password = "Neverland",
                Sex = 'M',
                UserRole = new Role { Id = 1, Description = "Admin", RoleName = "Admin"},
                Role = User.Roles.ADMIN,
                UserName = "peterpan",
                IsDeleted = false
            };

            var accessToken = new AccessToken
            {
                IssuedAt = new DateTime(2014, 10, 21, 14, 34, 21),
                Token = "encrypted-token"
            };

            // define mock calls
            mockAuthService.Stub(x => x.Login("user", "success-password")).Return(user);
            mockAccessTokenCreator.Stub(x => x.Create(user.Id)).Return(accessToken);
            mockContainer.Stub(x => x.GetInstance<IAuthenticationResult>()).Return(new AuthenticationResult());
            
            // create test object
            var authenticationService = new AuthenticationService(mockContainer, mockAccessTokenCreator, mockAuthService);
            
            // run the test
            var result = authenticationService.Authenticate("user", "success-password");

            mockAuthService.AssertWasCalled(x => x.Login("user", "success-password"));
            mockAccessTokenCreator.AssertWasCalled(x => x.Create(user.Id));
            mockContainer.AssertWasCalled(x => x.GetInstance<IAuthenticationResult>());
            
            Assert.AreEqual(true, result.IsValid);
            Assert.AreEqual(Resources.Content.AuthenticationResult_Success, result.Message);
            Assert.AreEqual("encrypted-token", result.AccessToken);
            Assert.AreEqual(new DateTime(2014, 10, 21, 14, 34, 21), result.IssuedAt);
        }

        [Test]
        public void AuthenticationExceptionTest()
        {
            // create mock objects
            var mockContainer = MockRepository.GenerateStub<IContainer>();
            var mockAuthService = MockRepository.GenerateStub<IAuthService>();
            var mockAccessTokenCreator = MockRepository.GenerateStub<IAccessTokenCreator>();

            // define mock calls
            mockAuthService.Stub(x => x.Login("user", "password")).Throw(new Exception("dummy-exception"));
            
            // create test object
            var authenticationService = new AuthenticationService(mockContainer, mockAccessTokenCreator, mockAuthService);

            // run the test
            Assert.Throws<Exception>(() => authenticationService.Authenticate("user", "password"));

            mockAuthService.AssertWasCalled(x => x.Login("user", "password"));
            
        }

        [Test]
        public void AuthenticationDeletedUser()
        {
            // create mock objects
            var mockContainer = MockRepository.GenerateStub<IContainer>();
            var mockAuthService = MockRepository.GenerateStub<IAuthService>();
            var mockAccessTokenCreator = MockRepository.GenerateStub<IAccessTokenCreator>();

            var user = new User
            {
                FirstName = "Peter",
                Id = 1,
                LastName = "Pan",
                Password = "Neverland",
                Sex = 'M',
                UserRole = new Role { Id = 1, Description = "Admin", RoleName = "Admin" },
                Role = User.Roles.ADMIN,
                UserName = "peterpan",
                IsDeleted = true
            };


            // define mock calls
            mockAuthService.Stub(x => x.Login("user", "success-password")).Return(user);
            mockContainer.Stub(x => x.GetInstance<IAuthenticationResult>()).Return(new AuthenticationResult());

            // create test object
            var authenticationService = new AuthenticationService(mockContainer, mockAccessTokenCreator, mockAuthService);

            // run the test
            var result = authenticationService.Authenticate("user", "success-password");

            mockAuthService.AssertWasCalled(x => x.Login("user", "success-password"));
            mockContainer.AssertWasCalled(x => x.GetInstance<IAuthenticationResult>());

            Assert.AreEqual(true, result.IsValid);
            Assert.AreEqual(Resources.Content.AuthenticationResult_Failed, result.Message);
            Assert.AreEqual(null, result.AccessToken);
            Assert.AreEqual(null, result.IssuedAt);

        }

        [Test]
        public void AuthenticationFailed()
        {
            // create mock objects
            var mockContainer = MockRepository.GenerateStub<IContainer>();
            var mockAuthService = MockRepository.GenerateStub<IAuthService>();
            var mockAccessTokenCreator = MockRepository.GenerateStub<IAccessTokenCreator>();

            // define mock calls
            mockAuthService.Stub(x => x.Login("non-user", "non-password")).Return(null);
            mockContainer.Stub(x => x.GetInstance<IAuthenticationResult>()).Return(new AuthenticationResult());

            // create test object
            var authenticationService = new AuthenticationService(mockContainer, mockAccessTokenCreator, mockAuthService);

            // run the test
            var result = authenticationService.Authenticate("non-user", "non-password");

            mockAuthService.AssertWasCalled(x => x.Login("non-user", "non-password"));
            mockContainer.AssertWasCalled(x => x.GetInstance<IAuthenticationResult>());

            Assert.AreEqual(true, result.IsValid);
            Assert.AreEqual(Resources.Content.AuthenticationResult_Failed, result.Message);
            Assert.AreEqual(null, result.AccessToken);
            Assert.AreEqual(null, result.IssuedAt);
        }
    }
}

