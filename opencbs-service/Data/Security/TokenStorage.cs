using OpenCBS.Online.Service.Security.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using OpenCBS.Online.Service.Data;
using OpenCBS.Online.Service.Models;
using NLog;

namespace OpenCBS.Online.Service.Data.Security
{
    // TODO move connection stuff to its own class
    public class TokenStorage : ITokenStorage
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private IDataConnection dataConnection;
        private IDateHelper dateHelper;
        public TokenStorage(IDataConnection dataConnection, IDateHelper dateHelper)
        {
            this.dataConnection = dataConnection;
            this.dateHelper = dateHelper;
        }

        public bool StoreToken(PasswordHash.HashInfo hashedToken, string encryptedUserId, byte[] userIdSalt, DateTime issuedAt)
        {
            logger.Debug("Store access token");
            var sql = @" INSERT INTO [TokenStorage]
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

            var result = dataConnection.Execute(sql, new
            {
                id = encryptedUserId,
                id_salt = Convert.ToBase64String(userIdSalt),
                token_hash = hashedToken.Hash,
                token_salt = hashedToken.Salt,
                token_iterations = hashedToken.Iterations,
                token_method = hashedToken.Method,
                issued_at = issuedAt,
                refreshed = issuedAt
            });
            
            logger.Debug("Store access token result: " + result);
            
            return result == 1 ? true : false;
            
        }

        public bool RetrieveToken(string id, out PasswordHash.HashInfo hashedToken, out string encryptedUserId, out byte[] userIdSalt, out DateTime issuedAt, out DateTime refreshed)
        {

            try
            {
                var sql = @"SELECT [id]
                              ,[id_salt]
                              ,[token_hash]
                              ,[token_salt]
                              ,[token_method]
                              ,[token_iterations]
                              ,[issued_at]
                              ,[refreshed]
                          FROM [TokenStorage]
                          WHERE [id] = @id";


                var results = dataConnection.Query<TokenStorageDb>(sql, new { id = id });

                // get the first out of the result set and throw exception if there is more
                var token = results.Single();

                issuedAt = token.issued_at;
                refreshed = token.refreshed;
                hashedToken = new PasswordHash.HashInfo
                {
                    Hash = token.token_hash,
                    Iterations = token.token_iterations,
                    Method = token.token_method,
                    Salt = token.token_salt
                };
                encryptedUserId = token.id;
                userIdSalt = Convert.FromBase64String(token.id_salt);

                return true;

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }         
            
            // set all information on null or default
            hashedToken = null;
            encryptedUserId = null;
            userIdSalt = null;
            issuedAt = new DateTime();
            refreshed = new DateTime();

            return false;
        }

        public void Dispose()
        {
            
        }

        internal class TokenStorageDb
        {
            internal string id { get; set; }
            internal string id_salt { get; set; }
            internal string token_hash { get; set; }
            internal string token_salt { get; set; }
            internal string token_method { get; set; }
            internal int token_iterations { get; set; }
            internal DateTime issued_at { get; set; }
            internal DateTime refreshed { get; set; }
            
        }
    }
}