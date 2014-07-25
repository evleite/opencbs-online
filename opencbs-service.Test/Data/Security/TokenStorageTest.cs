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
            var connectionManager = new ConnectionManager();
            var dateHelper = new DateHelper();

            var tokenStorage = new TokenStorage(connectionManager, dateHelper);

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

            Assert.IsTrue(tokenStorage.StoreToken(hashedToken, encryptedUserId, userIdSalt, issuedAt));
            
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
            Assert.Inconclusive();
        }
    }
}

