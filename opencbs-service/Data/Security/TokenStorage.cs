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

        public bool StoreToken(int userId, PasswordHash.HashInfo hashedToken, string encryptedUserId, byte[] userIdSalt, DateTime issuedAt)
        {
            logger.Debug("Store access token");
            // cleanup table
            var cleanUpSql = @"DELETE FROM [TokenStorage] WHERE user_id = @user_id";
            var deleteResult = dataConnection.Execute(cleanUpSql, new { user_id = userId });

            // store the actual token
            var sql = @" INSERT INTO [TokenStorage]
                                ([id]
                                ,[id_salt]
                                ,[token_hash]
                                ,[token_salt]
                                ,[token_method]
                                ,[token_iterations]
                                ,[issued_at]
                                ,[refreshed]
                                ,[user_id])
                            VALUES
                                (@id
                                ,@id_salt
                                ,@token_hash
                                ,@token_salt
                                ,@token_method
                                ,@token_iterations
                                ,@issued_at
                                ,@refreshed
                                ,@user_id)";
            // maybe 
            var result = dataConnection.Execute(sql, new
            {
                id = encryptedUserId,
                id_salt = Convert.ToBase64String(userIdSalt),
                token_hash = hashedToken.Hash,
                token_salt = hashedToken.Salt,
                token_iterations = hashedToken.Iterations,
                token_method = hashedToken.Method,
                issued_at = issuedAt,
                refreshed = issuedAt,
                user_id = userId
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

        public bool VerifyTokenExistence(int userId, out string tokenHash, out DateTime issuedAt, out DateTime refreshed)
        {
            logger.Debug("VerifyTokenExistence");
            try
            {
                var sql = @"SELECT [token_hash]
                              ,[issued_at]
                              ,[refreshed]
                          FROM [TokenStorage]
                          WHERE [user_id] = @user_id";

                var results = dataConnection.Query<TokenStorageDb>(sql, new { user_id = userId });
                if (results.Count() == 1)
                {
                    // get the first out of the result set
                    var token = results.Single();
                    tokenHash = token.token_hash;
                    issuedAt = token.issued_at;
                    refreshed = token.refreshed;

                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            // set all information on null or default

            issuedAt = new DateTime();
            refreshed = new DateTime();
            tokenHash = null;

            return false;
        }


        public bool RefreshToken(int userId, string tokenHash, DateTime refreshDate)
        {
            try
            {
                var sql = @"UPDATE [TokenStorage] SET refreshed = @refreshed WHERE [user_id] = @user_id AND token_hash = @token_hash";

                var results = dataConnection.Execute(sql, new { refreshed = refreshDate, user_id = userId, token_hash = tokenHash });

                if (results == 1)
                    return true;

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

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