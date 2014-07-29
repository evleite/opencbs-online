using NLog;
using OpenCBS.Online.Service.Data.Security;
using OpenCBS.Online.Service.Models;
using OpenCBS.Online.Service.Models.Security;
using OpenCBS.Online.Service.Security.Encryption;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;


namespace OpenCBS.Online.Service.Security
{
    public class AccessTokenCreator : IAccessTokenCreator
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private IContainer container;
        private ITokenStorage tokenStorage;
        private IDateHelper dateHelper;
        private IOpenGuid openGuid;
        private IEncrypter encrypter;

        public AccessTokenCreator(IContainer container, ITokenStorage tokenStorage, IEncrypter encrypter, IDateHelper dateHelper, IOpenGuid openGuid)
        {
            this.container = container;
            this.tokenStorage = tokenStorage;
            this.dateHelper = dateHelper;
            this.openGuid = openGuid;
            this.encrypter = encrypter;
        }

        public IAccessToken Create(int userId)
        {
            // create the token
            var token = container.GetInstance<IAccessToken>();
            var passwordHash = container.GetInstance<IPasswordHash>();
            string tokenHash;
            string encryptedUserId;
            byte[] userIdSalt;
            DateTime issuedAt, refreshed;

            // check whether there is a token existing for this userId
            bool tokenExists = tokenStorage.VerifyTokenExistence(userId, out tokenHash, out issuedAt, out refreshed);
            if (tokenExists)
            {
                if(dateHelper.IsWithinTimeOutLimit(refreshed)){
                    // token is still valid, refresh the token to extend the timeout
                    if (!tokenStorage.RefreshToken(userId, tokenHash, dateHelper.Now))
                        throw new Exception("Failed to refresh existing the token");

                    token.IssuedAt = issuedAt;
                    token.Token = tokenHash;
                    encryptedUserId = null;
                    issuedAt = new DateTime();
                    refreshed = new DateTime();
                    return token;
                }            
            }

            // Create the token identifier
            Guid tokenId = openGuid.New();
            var hashedToken = passwordHash.CreateHash(tokenId.ToString());

            userIdSalt = encrypter.GetSalt();
            encryptedUserId = encrypter.Encrypt(userId.ToString(), userIdSalt);
            issuedAt = dateHelper.Now;

            //store the hashInfo
            if (!tokenStorage.StoreToken(userId, hashedToken, encryptedUserId, userIdSalt, issuedAt))
                throw new Exception("Failed to store the session token");

            // set the token for the user
            token.Token = hashedToken.Hash;
            token.IssuedAt = issuedAt;

            //reset all information
            hashedToken.Dispose();
            userIdSalt = null;
            encryptedUserId = null;
            passwordHash.Dispose();
            passwordHash = null;
            
            return token;
        }
        
        public void Dispose()
        {
            container = null;
            dateHelper = null;
            tokenStorage.Dispose();
            tokenStorage = null;
            openGuid = null;
            encrypter = null;                    
        }
    }
}