using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using OpenCBS.Online.Service.Security;
using StructureMap;
using Rhino.Mocks;
using OpenCBS.Online.Service.Security.Encryption;
using OpenCBS.Online.Service.Models.Security;
using OpenCBS.Online.Service.Data.Security;

namespace OpenCBS.Online.Service.Test.Security
{
    /// <summary>
    /// The text fixture for <see cref="AccessTokenCreatorTest" />.
    /// </summary>
    [TestFixture]
    public class AccessTokenCreatorTest
    {
        /// <summary>
        /// Test for <see cref="AccessTokenCreatorTest" />.
        /// </summary>
        [Test]
        public void CreateTokenTest()
        {
            // poco mock object
            var userIdSalt = new byte[24];
            var tokenSalt = new byte[24];
            var guid = new Guid("892821c7-ea89-40b7-abe0-2c8c4a521349");
            var encryptedGuid = "encrypted-guid";
            var encryptedUserId = "dummy-encrypted-user-id";
            var accessToken = new AccessToken();
            var issuedAt = new DateTime(2014, 11, 21, 14, 55, 33);

            var hashedToken = new PasswordHash.HashInfo
            {
                Hash = encryptedGuid,
                Iterations = 1000,
                Method = "sha1",
                Salt = Convert.ToBase64String(tokenSalt)
            };

            
            // declare mocks
            var mockContainer = MockRepository.GenerateStub<IContainer>();
            var mockPasswordHash = MockRepository.GenerateStub<IPasswordHash>();
            var mockTokenStorage = MockRepository.GenerateStub<ITokenStorage>();
            var mockDateHelper = MockRepository.GenerateStub<IDateHelper>();
            var mockOpenGuid = MockRepository.GenerateStub<IOpenGuid>();
            var mockEcrypter = MockRepository.GenerateStub<IEncrypter>();
            
            // stub all mock calls
            mockContainer.Stub(x => x.GetInstance<IAccessToken>()).Return(accessToken);
            mockContainer.Stub(x => x.GetInstance<IPasswordHash>()).Return(mockPasswordHash);
            mockOpenGuid.Stub(x => x.New()).Return(guid);
            mockPasswordHash.Stub(x => x.CreateHash(guid.ToString())).Return(hashedToken);
            mockEcrypter.Stub(x => x.GetSalt()).Return(userIdSalt);
            mockEcrypter.Stub(x => x.Encrypt("1", userIdSalt)).Return(encryptedUserId);
            mockTokenStorage.Stub(x => x.StoreToken(hashedToken, encryptedUserId, userIdSalt, issuedAt)).Return(true);
            mockDateHelper.Stub (x => x.Now).Return (issuedAt);
            
            // create test object and call test method
            var accessTokenCreator = new AccessTokenCreator(mockContainer, mockTokenStorage, mockEcrypter, mockDateHelper, mockOpenGuid);
            var accessTokenResult = accessTokenCreator.Create(1);

            // verify stub methods are called
            mockContainer.AssertWasCalled(x => x.GetInstance<IAccessToken>());
            mockContainer.AssertWasCalled(x => x.GetInstance<IPasswordHash>());
            mockOpenGuid.AssertWasCalled(x => x.New());
            mockPasswordHash.AssertWasCalled(x => x.CreateHash(guid.ToString()));
            mockEcrypter.AssertWasCalled(x => x.GetSalt());
            mockEcrypter.AssertWasCalled(x => x.Encrypt("1", userIdSalt));
            mockTokenStorage.AssertWasCalled(x => x.StoreToken(hashedToken, encryptedUserId, userIdSalt, issuedAt));

            // asserts
            Assert.AreEqual(encryptedGuid, accessTokenResult.Token);
            Assert.AreEqual(issuedAt, accessTokenResult.IssuedAt);

        }

        [Test]
        public void CreateTokenUnknownExceptionTest()
        {
            // poco mock object
            var userIdSalt = new byte[24];
            var tokenSalt = new byte[24];
            var guid = new Guid("892821c7-ea89-40b7-abe0-2c8c4a521349");
            var encryptedGuid = "encrypted-guid";
            var encryptedUserId = "dummy-encrypted-user-id";
            var accessToken = new AccessToken();
            var hashedToken = new PasswordHash.HashInfo
            {
                Hash = encryptedGuid,
                Iterations = 1000,
                Method = "sha1",
                Salt = Convert.ToBase64String(tokenSalt)
            };


            // declare mocks
            var mockContainer = MockRepository.GenerateStub<IContainer>();
            var mockPasswordHash = MockRepository.GenerateStub<IPasswordHash>();
            var mockTokenStorage = MockRepository.GenerateStub<ITokenStorage>();
            var mockDateHelper = MockRepository.GenerateStub<IDateHelper>();
            var mockOpenGuid = MockRepository.GenerateStub<IOpenGuid>();
            var mockEcrypter = MockRepository.GenerateStub<IEncrypter>();

            // stub all mock calls
            mockContainer.Stub(x => x.GetInstance<IAccessToken>()).Return(accessToken);
            mockContainer.Stub(x => x.GetInstance<IPasswordHash>()).Return(mockPasswordHash);
            mockOpenGuid.Stub(x => x.New()).Return(guid);
            mockPasswordHash.Stub(x => x.CreateHash(guid.ToString())).Throw(new Exception("Unknown exception"));
           
            // create test object and call test method
            var accessTokenCreator = new AccessTokenCreator(mockContainer, mockTokenStorage, mockEcrypter, mockDateHelper, mockOpenGuid);
            Assert.Throws<Exception>(() => accessTokenCreator.Create(1));
            
            // verify stub methods are called
            // verify stub methods are called
            mockContainer.AssertWasCalled(x => x.GetInstance<IAccessToken>());
            mockContainer.AssertWasCalled(x => x.GetInstance<IPasswordHash>());
            mockOpenGuid.AssertWasCalled(x => x.New());
            mockPasswordHash.AssertWasCalled(x => x.CreateHash(guid.ToString()));
        }

        [Test]
        public void CreateTokenStoreExceptionTest()
        {
            // poco mock object
            var userIdSalt = new byte[24];
            var tokenSalt = new byte[24];
            var guid = new Guid("892821c7-ea89-40b7-abe0-2c8c4a521349");
            var encryptedGuid = "encrypted-guid";
            var encryptedUserId = "dummy-encrypted-user-id";
            var issuedAt = new DateTime(2014, 11, 21, 14, 55, 33);
            var accessToken = new AccessToken();
            var hashedToken = new PasswordHash.HashInfo
            {
                Hash = encryptedGuid,
                Iterations = 1000,
                Method = "sha1",
                Salt = Convert.ToBase64String(tokenSalt)
            };


            // declare mocks
            var mockContainer = MockRepository.GenerateStub<IContainer>();
            var mockPasswordHash = MockRepository.GenerateStub<IPasswordHash>();
            var mockTokenStorage = MockRepository.GenerateStub<ITokenStorage>();
            var mockDateHelper = MockRepository.GenerateStub<IDateHelper>();
            var mockOpenGuid = MockRepository.GenerateStub<IOpenGuid>();
            var mockEcrypter = MockRepository.GenerateStub<IEncrypter>();

            // stub all mock calls
            mockContainer.Stub(x => x.GetInstance<IAccessToken>()).Return(accessToken);
            mockContainer.Stub(x => x.GetInstance<IPasswordHash>()).Return(mockPasswordHash);
            mockOpenGuid.Stub(x => x.New()).Return(guid);
            mockPasswordHash.Stub(x => x.CreateHash(guid.ToString())).Return(hashedToken);
            mockEcrypter.Stub(x => x.GetSalt()).Return(userIdSalt);
            mockEcrypter.Stub(x => x.Encrypt("1", userIdSalt)).Return(encryptedUserId);
            mockTokenStorage.Stub(x => x.StoreToken(hashedToken, encryptedUserId, userIdSalt, issuedAt)).Return(false);
            mockDateHelper.Stub(x => x.Now).Return(issuedAt);

            // create test object and call test method
            var accessTokenCreator = new AccessTokenCreator(mockContainer, mockTokenStorage, mockEcrypter, mockDateHelper, mockOpenGuid);
            Assert.Throws<Exception>(() => accessTokenCreator.Create(1));

            // verify stub methods are called
            mockContainer.AssertWasCalled(x => x.GetInstance<IAccessToken>());
            mockContainer.AssertWasCalled(x => x.GetInstance<IPasswordHash>());
            mockOpenGuid.AssertWasCalled(x => x.New());
            mockPasswordHash.AssertWasCalled(x => x.CreateHash(guid.ToString()));
            mockEcrypter.AssertWasCalled(x => x.GetSalt());
            mockEcrypter.AssertWasCalled(x => x.Encrypt("1", userIdSalt));
            mockTokenStorage.AssertWasCalled(x => x.StoreToken(hashedToken, encryptedUserId, userIdSalt, issuedAt));
                        
        }
    }
}

