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
            Assert.Inconclusive();

            var container = new Container();
            var dateHelper = new DateHelper();
            var openGuid = new OpenGuid();
            var encrypter = new Encrypter();
            var authService = new AuthService();
            var connectionManager = new ConnectionManager();
            var tokenStorage = new TokenStorage(connectionManager, dateHelper);
            var accessTokenCreator = new AccessTokenCreator(container, tokenStorage, encrypter, dateHelper, openGuid);

            var authenticationService = new AuthenticationService(container, accessTokenCreator, authService);
            var result = authenticationService.Authenticate("user", "success-password");

            Assert.AreEqual(true, result.IsValid);
            Assert.AreEqual(Resources.Content.AuthenticationResult_Success, result.Message);
            Assert.AreEqual(32, result.AccessToken.Length);

            

        }

        [Test]
        public void AuthenticationExceptionTest()
        {
            Assert.Inconclusive();
        }
    }
}

