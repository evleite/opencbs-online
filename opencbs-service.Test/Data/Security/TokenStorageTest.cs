using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using OpenCBS.Online.Service.Data;
using OpenCBS.Online.Service.Data.Security;
using OpenCBS.Online.Service.Security.Encryption;
using Rhino.Mocks;

namespace OpenCBS.Online.Service.Test.Data.Security
{
    /// <summary>
    /// The text fixture for <see cref="TokenStorageTest" />.
    /// </summary>
    [TestFixture]
    public class TokenStorageTest
    {
        [TestFixtureSetUp]
        public void SetUp()
        {
            TestHelper.DeleteTestData();
            TestHelper.InsertTestData();
        }

        /// <summary>
        /// Test for <see cref="TokenStorageTest" />.
        /// </summary>
        [Test]
        public void StoreAndRetrieveTokenTest()
        {
            TestHelper.DeleteTestData();
            TestHelper.InsertTestData();

            var dataConnection = new DataConnection();
            var dateHelper = new DateHelper();

            var tokenStorage = new TokenStorage(dataConnection, dateHelper);

            var userId = 1;
            var userIdSalt = new byte[24];
            var tokenSalt = new byte[24];
            var encryptedGuid = "encrypted-guid";
            var encryptedUserId = "dummy-encrypted-user-id";
            var issuedAt = new DateTime(2014, 11, 21, 14, 54, 33);

            
            var hashedToken = new PasswordHash.HashInfo
            {
                Hash = encryptedGuid,
                Iterations = 1000,
                Method = "sha1",
                Salt = Convert.ToBase64String(tokenSalt)
            };

            Assert.IsTrue(tokenStorage.StoreToken(userId, hashedToken, encryptedUserId, userIdSalt, issuedAt));
            
            PasswordHash.HashInfo hashedTokenResult;
            string encryptedUserIdResult;
            byte[] userIdSaltResult;
            DateTime issuedAtResult;
            DateTime refreshedResult;
            var retrieveTokenSuccess = tokenStorage.RetrieveToken(encryptedUserId, out hashedTokenResult, out encryptedUserIdResult, out userIdSaltResult, out issuedAtResult, out refreshedResult);

            Assert.IsTrue(retrieveTokenSuccess);
            Assert.AreEqual(hashedToken.Salt, hashedTokenResult.Salt);
            Assert.AreEqual(hashedToken.Hash, hashedTokenResult.Hash);
            Assert.AreEqual(hashedToken.Method, hashedTokenResult.Method);
            Assert.AreEqual(encryptedUserId, encryptedUserIdResult);
            Assert.AreEqual(userIdSalt, userIdSaltResult);
            Assert.AreEqual(new DateTime(2014, 11, 21, 14, 54, 33), issuedAtResult);
            Assert.AreEqual(new DateTime(2014, 11, 21, 14, 54, 33), refreshedResult);            
           
        }

        [Test]
        public void StoreExceptionTest()
        {
            var dataConnection = MockRepository.GenerateStub<IDataConnection>();
            var dateHelper = new DateHelper();

            var tokenStorage = new TokenStorage(dataConnection, dateHelper);

            var userId = 1;
            var userIdSalt = new byte[24];
            var tokenSalt = new byte[24];
            var encryptedGuid = "encrypted-guid";
            var encryptedUserId = "dummy-encrypted-user-id";
            var issuedAt = new DateTime(2014, 11, 21, 14, 54, 33);

            var hashedToken = new PasswordHash.HashInfo
            {
                Hash = encryptedGuid,
                Iterations = 1000,
                Method = "sha1",
                Salt = Convert.ToBase64String(tokenSalt)
            };

            // stub fake calls
            dataConnection.Stub(x => x.Execute(null, null)).Throw(new Exception()).IgnoreArguments();

            Assert.Throws<Exception>(() => tokenStorage.StoreToken(userId, hashedToken, encryptedUserId, userIdSalt, issuedAt));
        }

        [Test]
        public void RetrieveTokenExceptionTest()
        {
            // declare mocks
            var dataConnection = MockRepository.GenerateStub<IDataConnection>();
            
            // declare objects
            var dateHelper = new DateHelper();
            var encryptedUserId = "dummy-encrypted-user-id";
            var tokenStorage = new TokenStorage(dataConnection, dateHelper);
            
            
            // stub fake calls
            dataConnection.Stub(x => x.Query<TokenStorage.TokenStorageDb>(null, null)).Throw(new Exception()).IgnoreArguments();

            PasswordHash.HashInfo hashedTokenResult;
            string encryptedUserIdResult;
            byte[] userIdSaltResult;
            DateTime issuedAtResult;
            DateTime refreshedResult;

            var result = tokenStorage.RetrieveToken(encryptedUserId, out hashedTokenResult, out encryptedUserIdResult, out userIdSaltResult, out issuedAtResult, out refreshedResult);
            
            Assert.IsFalse(result);            
        }

        [Test]
        public void VerifyTokenExistenceTest()
        {
            TestHelper.DeleteTestData();
            TestHelper.InsertTestData();

            //VerifyTokenExistence
            var dataConnection = new DataConnection();
            var dateHelper = new DateHelper();

            var tokenStorage = new TokenStorage(dataConnection, dateHelper);

            var userId = 101;
            var userIdSalt = new byte[24];
            var tokenSalt = new byte[24];
            var encryptedGuid = "encrypted-guid";
            var encryptedUserId = "dummy-encrypted-user-id";
            var issuedAt = new DateTime(2014, 11, 21, 14, 54, 33);
            
            var hashedToken = new PasswordHash.HashInfo
            {
                Hash = encryptedGuid,
                Iterations = 1000,
                Method = "sha1",
                Salt = Convert.ToBase64String(tokenSalt)
            };

            Assert.IsTrue(tokenStorage.StoreToken(userId, hashedToken, encryptedUserId, userIdSalt, issuedAt));

            string hashedTokenResult;
            DateTime issuedAtResult;
            DateTime refreshedResult;
            var verifyTokenSuccess = tokenStorage.VerifyTokenExistence(userId, out hashedTokenResult, out issuedAtResult, out refreshedResult);

            Assert.IsTrue(verifyTokenSuccess);
            Assert.AreEqual(encryptedGuid, hashedTokenResult);
            Assert.AreEqual(new DateTime(2014, 11, 21, 14, 54, 33), issuedAtResult);
            Assert.AreEqual(new DateTime(2014, 11, 21, 14, 54, 33), refreshedResult);

            verifyTokenSuccess = tokenStorage.VerifyTokenExistence(102, out hashedTokenResult, out issuedAtResult, out refreshedResult);

            Assert.IsFalse(verifyTokenSuccess);
            Assert.AreEqual(null, hashedTokenResult);
            Assert.AreEqual(new DateTime(), issuedAtResult);
            Assert.AreEqual(new DateTime(), refreshedResult);
        }

        [Test]
        public void RefreshTokenTest()
        {
            var dataConnection = new DataConnection();
            var dateHelper = new DateHelper();

            var tokenStorage = new TokenStorage(dataConnection, dateHelper);

            var userId = 101;
            var userIdSalt = new byte[24];
            var tokenSalt = new byte[24];
            var encryptedGuid = "encrypted-guid";
            var encryptedUserId = "dummy-encrypted-user-id";
            var issuedAt = new DateTime(2014, 11, 21, 14, 54, 33);
            
            var hashedToken = new PasswordHash.HashInfo
            {
                Hash = encryptedGuid,
                Iterations = 1000,
                Method = "sha1",
                Salt = Convert.ToBase64String(tokenSalt)
            };

            Assert.IsTrue(tokenStorage.StoreToken(userId, hashedToken, encryptedUserId, userIdSalt, issuedAt));

            Assert.IsTrue(tokenStorage.RefreshToken(userId, hashedToken.Hash, new DateTime(2014, 11, 21, 15, 55, 22)));

            PasswordHash.HashInfo hashedTokenResult;
            string encryptedUserIdResult;
            byte[] userIdSaltResult;
            DateTime issuedAtResult;
            DateTime refreshedResult;
            var retrieveTokenSuccess = tokenStorage.RetrieveToken(encryptedUserId, out hashedTokenResult, out encryptedUserIdResult, out userIdSaltResult, out issuedAtResult, out refreshedResult);

            Assert.IsTrue(retrieveTokenSuccess);
            Assert.AreEqual(hashedToken.Salt, hashedTokenResult.Salt);
            Assert.AreEqual(hashedToken.Hash, hashedTokenResult.Hash);
            Assert.AreEqual(hashedToken.Method, hashedTokenResult.Method);
            Assert.AreEqual(encryptedUserId, encryptedUserIdResult);
            Assert.AreEqual(userIdSalt, userIdSaltResult);
            Assert.AreEqual(new DateTime(2014, 11, 21, 14, 54, 33), issuedAtResult);
            Assert.AreEqual(new DateTime(2014, 11, 21, 15, 55, 22), refreshedResult);

            // check if using a wrong id/encryptid fails (it should fail)
            Assert.IsFalse(tokenStorage.RefreshToken(102, hashedToken.Hash, new DateTime(2014, 11, 21, 15, 55, 22)));
            Assert.IsFalse(tokenStorage.RefreshToken(userId, hashedToken.Hash + 'a', new DateTime(2014, 11, 21, 15, 55, 22)));
        }
    }
}

