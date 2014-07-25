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

            // Create the token identifier
            Guid tokenId = openGuid.New();
            var hashedToken = passwordHash.CreateHash(tokenId.ToString());

            var userIdSalt = encrypter.GetSalt();
            var encryptedUserId = encrypter.Encrypt(userId.ToString(), userIdSalt);
            var issuedAt = dateHelper.Now;

            //store the hashInfo
            if (!tokenStorage.StoreToken(hashedToken, encryptedUserId, userIdSalt, issuedAt))
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