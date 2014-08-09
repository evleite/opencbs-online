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
            var userId = 1;
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
            mockTokenStorage.Stub(x => x.StoreToken(userId, hashedToken, encryptedUserId, userIdSalt, issuedAt)).Return(true);
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
            mockTokenStorage.AssertWasCalled(x => x.StoreToken(userId, hashedToken, encryptedUserId, userIdSalt, issuedAt));

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
            var userId = 1;
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
            mockTokenStorage.Stub(x => x.StoreToken(userId, hashedToken, encryptedUserId, userIdSalt, issuedAt)).Return(false);
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
            mockTokenStorage.AssertWasCalled(x => x.StoreToken(userId, hashedToken, encryptedUserId, userIdSalt, issuedAt));
                        
        }

        [Test]
        public void ReAuthenticateTest()
        {
            // poco mock object
            var userId = 1;
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

            string tokenIdOut;
            var issuedAtOutRef = new DateTime(2014, 11, 21, 14, 55, 33);
            var refreshedOutRef = new DateTime(2014, 11, 21, 14, 55, 33);
            DateTime issuedAtOut, refreshedOut;

            // stub all mock calls
            mockContainer.Stub(x => x.GetInstance<IAccessToken>()).Return(accessToken).Repeat.Times(2);
            mockContainer.Stub(x => x.GetInstance<IPasswordHash>()).Return(mockPasswordHash).Repeat.Times(2);
            mockOpenGuid.Stub(x => x.New()).Return(guid).Repeat.Once();
            mockPasswordHash.Stub(x => x.CreateHash(guid.ToString())).Return(hashedToken).Repeat.Once();
            mockEcrypter.Stub(x => x.GetSalt()).Return(userIdSalt).Repeat.Once();
            mockEcrypter.Stub(x => x.Encrypt("1", userIdSalt)).Return(encryptedUserId).Repeat.Once();
            mockTokenStorage.Stub(x => x.VerifyTokenExistence(userId, out tokenIdOut, out issuedAtOut, out refreshedOut))
                                        .OutRef(new object[] { encryptedUserId, issuedAtOutRef, refreshedOutRef })
                                        .Return(false).Repeat.Once();
            mockTokenStorage.Stub(x => x.VerifyTokenExistence(userId, out tokenIdOut, out issuedAtOut, out refreshedOut))
                                        .OutRef(new object[] { encryptedUserId, issuedAtOutRef, refreshedOutRef })
                                        .Return(true).Repeat.Once();
            mockTokenStorage.Stub(x => x.StoreToken(userId, hashedToken, encryptedUserId, userIdSalt, issuedAt)).Return(true).Repeat.Once();
            mockTokenStorage.Stub(x => x.RefreshToken(userId, encryptedUserId, issuedAt)).Return(true).Repeat.Once();
            mockDateHelper.Stub(x => x.Now).Return(issuedAt).Repeat.Times(2);
            mockDateHelper.Stub(x => x.IsWithinTimeOutLimit(refreshedOutRef)).Return(true).Repeat.Once();

            // create test object and call test method
            var accessTokenCreator = new AccessTokenCreator(mockContainer, mockTokenStorage, mockEcrypter, mockDateHelper, mockOpenGuid);
            var accessTokenResult = accessTokenCreator.Create(1);

            // verify stub methods are called
            mockContainer.AssertWasCalled(x => x.GetInstance<IAccessToken>());
            mockContainer.AssertWasCalled(x => x.GetInstance<IPasswordHash>());
            mockTokenStorage.AssertWasCalled(x => x.VerifyTokenExistence(userId, out tokenIdOut, out issuedAtOut, out refreshedOut));
            mockOpenGuid.AssertWasCalled(x => x.New());
            mockPasswordHash.AssertWasCalled(x => x.CreateHash(guid.ToString()));
            mockEcrypter.AssertWasCalled(x => x.GetSalt());
            mockEcrypter.AssertWasCalled(x => x.Encrypt("1", userIdSalt));
            mockTokenStorage.AssertWasCalled(x => x.StoreToken(userId, hashedToken, encryptedUserId, userIdSalt, issuedAt));

            // asserts
            Assert.AreEqual(encryptedGuid, accessTokenResult.Token);
            Assert.AreEqual(issuedAt, accessTokenResult.IssuedAt);

            var accessTokenResult2 = accessTokenCreator.Create(1);
            // verify stub methods are called
            mockContainer.AssertWasCalled(x => x.GetInstance<IAccessToken>());
            mockContainer.AssertWasCalled(x => x.GetInstance<IPasswordHash>());
            mockTokenStorage.AssertWasCalled(x => x.VerifyTokenExistence(userId, out tokenIdOut, out issuedAtOut, out refreshedOut));
            //mockOpenGuid.AssertWasNotCalled(x => x.New());

            Assert.AreEqual(accessTokenResult2.Token, accessTokenResult.Token);
            Assert.AreEqual(accessTokenResult2.IssuedAt, accessTokenResult.IssuedAt);
        }

        [Test]
        public void ReAuthenticateFailsTest()
        {
            // poco mock object
            var userId = 1;
            var userIdSalt = new byte[24];
            var tokenSalt = new byte[24];
            var guid = new Guid("892821c7-ea89-40b7-abe0-2c8c4a521349");
            var guid2 = new Guid("792821c7-ea89-40b7-abe0-2c8c4a521349");
            var encryptedGuid = "encrypted-guid";
            var encryptedGuid2 = "encrypted-guid2";
            var encryptedUserId = "dummy-encrypted-user-id";
            var encryptedUserId2 = "dummy-encrypted-user-id2";
            var accessToken = new AccessToken();
            var accessToken2 = new AccessToken();
            var issuedAt = new DateTime(2014, 11, 21, 13, 55, 33);
            var now = new DateTime(2014, 11, 21, 14, 55, 33);

            var hashedToken = new PasswordHash.HashInfo
            {
                Hash = encryptedGuid,
                Iterations = 1000,
                Method = "sha1",
                Salt = Convert.ToBase64String(tokenSalt)
            };

            var hashedToken2 = new PasswordHash.HashInfo
            {
                Hash = encryptedGuid2,
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

            string tokenIdOut;
            var issuedAtOutRef = new DateTime(2014, 11, 21, 13, 55, 33);
            var refreshedOutRef = new DateTime(2014, 11, 21, 13, 55, 33);
            DateTime issuedAtOut, refreshedOut;

            // stub all mock calls
            mockContainer.Stub(x => x.GetInstance<IAccessToken>()).Return(accessToken).Repeat.Once();
            mockContainer.Stub(x => x.GetInstance<IPasswordHash>()).Return(mockPasswordHash).Repeat.Times(2);

            mockTokenStorage.Stub(x => x.VerifyTokenExistence(userId, out tokenIdOut, out issuedAtOut, out refreshedOut))
                                        .OutRef(new object[] { encryptedUserId, issuedAtOutRef, refreshedOutRef })
                                        .Return(false).Repeat.Once();
            mockOpenGuid.Stub(x => x.New()).Return(guid).Repeat.Once();
            mockPasswordHash.Stub(x => x.CreateHash(guid.ToString())).Return(hashedToken).Repeat.Once();
            mockEcrypter.Stub(x => x.GetSalt()).Return(userIdSalt).Repeat.Once();
            mockEcrypter.Stub(x => x.Encrypt("1", userIdSalt)).Return(encryptedUserId).Repeat.Once();
            mockDateHelper.Stub(x => x.Now).Return(issuedAt).Repeat.Once();
            mockTokenStorage.Stub(x => x.StoreToken(userId, hashedToken, encryptedUserId, userIdSalt, issuedAt)).Return(true).Repeat.Once();
            
            mockContainer.Stub(x => x.GetInstance<IAccessToken>()).Return(accessToken2).Repeat.Once();
            mockTokenStorage.Stub(x => x.VerifyTokenExistence(userId, out tokenIdOut, out issuedAtOut, out refreshedOut))
                                        .OutRef(new object[] { encryptedUserId, issuedAtOutRef, refreshedOutRef })
                                        .Return(true).Repeat.Once();
            mockDateHelper.Stub(x => x.IsWithinTimeOutLimit(refreshedOutRef)).Return(false).Repeat.Once();
            mockDateHelper.Stub(x => x.Now).Return(now).Repeat.Once();
            mockOpenGuid.Stub(x => x.New()).Return(guid2).Repeat.Once();
            mockPasswordHash.Stub(x => x.CreateHash(guid2.ToString())).Return(hashedToken2).Repeat.Once();
            mockEcrypter.Stub(x => x.GetSalt()).Return(userIdSalt).Repeat.Once();
            mockEcrypter.Stub(x => x.Encrypt("1", userIdSalt)).Return(encryptedUserId2).Repeat.Once();
            mockDateHelper.Stub(x => x.Now).Return(now).Repeat.Once();
            mockTokenStorage.Stub(x => x.StoreToken(userId, hashedToken2, encryptedUserId2, userIdSalt, now)).Return(true).Repeat.Once();
            
            // create test object and call test method
            var accessTokenCreator = new AccessTokenCreator(mockContainer, mockTokenStorage, mockEcrypter, mockDateHelper, mockOpenGuid);
            var accessTokenResult = accessTokenCreator.Create(1);

            // verify stub methods are called
            mockContainer.AssertWasCalled(x => x.GetInstance<IAccessToken>());
            mockContainer.AssertWasCalled(x => x.GetInstance<IPasswordHash>());
            mockTokenStorage.AssertWasCalled(x => x.VerifyTokenExistence(userId, out tokenIdOut, out issuedAtOut, out refreshedOut));
            mockOpenGuid.AssertWasCalled(x => x.New());
            mockPasswordHash.AssertWasCalled(x => x.CreateHash(guid.ToString()));
            mockEcrypter.AssertWasCalled(x => x.GetSalt());
            mockEcrypter.AssertWasCalled(x => x.Encrypt("1", userIdSalt));
            mockTokenStorage.AssertWasCalled(x => x.StoreToken(userId, hashedToken, encryptedUserId, userIdSalt, issuedAt));

            // asserts
            Assert.AreEqual(encryptedGuid, accessTokenResult.Token);
            Assert.AreEqual(issuedAt, accessTokenResult.IssuedAt);

            var accessTokenResult2 = accessTokenCreator.Create(1);
            // verify stub methods are called
            mockContainer.AssertWasCalled(x => x.GetInstance<IAccessToken>());
            mockContainer.AssertWasCalled(x => x.GetInstance<IPasswordHash>());
            mockTokenStorage.AssertWasCalled(x => x.VerifyTokenExistence(userId, out tokenIdOut, out issuedAtOut, out refreshedOut));
            mockOpenGuid.AssertWasCalled(x => x.New());
            mockPasswordHash.AssertWasCalled(x => x.CreateHash(guid2.ToString()));
            mockEcrypter.AssertWasCalled(x => x.GetSalt());
            mockEcrypter.AssertWasCalled(x => x.Encrypt("1", userIdSalt));
            mockTokenStorage.AssertWasCalled(x => x.StoreToken(userId, hashedToken2, encryptedUserId2, userIdSalt, now));

            mockOpenGuid.VerifyAllExpectations();

            Assert.AreNotEqual(accessTokenResult2.Token, accessTokenResult.Token);
            Assert.AreNotEqual(accessTokenResult2.IssuedAt, accessTokenResult.IssuedAt);

            Assert.AreEqual(encryptedGuid2, accessTokenResult2.Token);
            Assert.AreEqual(now, accessTokenResult2.IssuedAt);
        }
        
    }
}

