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
            var dataConnection = new DataConnection();
            var dateHelper = new DateHelper();

            var tokenStorage = new TokenStorage(dataConnection, dateHelper);

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
            var dataConnection = MockRepository.GenerateStub<IDataConnection>();
            var dateHelper = new DateHelper();

            var tokenStorage = new TokenStorage(dataConnection, dateHelper);

            var userIdSalt = new byte[24];
            var tokenSalt = new byte[24];
            var encryptedGuid = "encrypted-guid";
            var encryptedUserId = "dummy-encrypted-user-id";
            var issuedAt = new DateTime(2014, 11, 21, 14, 54, 33);
            var stubSql = @" INSERT INTO [TokenStorage]
                                ([id]
                                ,[id_salt]
                                ,[token_hash]
                                ,[token_salt]
                                ,[token_method]
                                ,[token_iterations]
                                ,[issued_at]
                                ,[refreshed])
                            VALUES
                                (@id
                                ,@id_salt
                                ,@token_hash
                                ,@token_salt
                                ,@token_method
                                ,@token_iterations
                                ,@issued_at
                                ,@refreshed)";

            var hashedToken = new PasswordHash.HashInfo
            {
                Hash = encryptedGuid,
                Iterations = 1000,
                Method = "sha1",
                Salt = Convert.ToBase64String(tokenSalt)
            };

            // stub fake calls
            dataConnection.Stub(x => x.Execute(null, null)).Throw(new Exception()).IgnoreArguments();

            Assert.Throws<Exception>(() => tokenStorage.StoreToken(hashedToken, encryptedUserId, userIdSalt, issuedAt));
            
            //Assert.Throws<Exception>(() => tokenStorage.RetrieveToken(encryptedUserId, out hashedTokenResult, out encryptedUserIdResult, out userIdSaltResult, out issuedAtResult, out refreshedResult));
            
            
                        
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
    }
}

