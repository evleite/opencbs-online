using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCBS.Online.Service.Security.Encryption;

namespace OpenCBS.Online.Service.Data.Security
{
    public interface ITokenStorage : IDisposable
    {
        bool StoreToken(int userId, PasswordHash.HashInfo hashedToken, string encryptedUserId, byte[] userIdSalt, DateTime issuedAt);
        bool RetrieveToken(string id, out PasswordHash.HashInfo hashedToken, out string encryptedUserId, out byte[] userIdSalt, out DateTime issuedAt, out DateTime refreshed);

        bool VerifyTokenExistence(int userId, out string tokenHash, out DateTime issuedAt, out DateTime refreshed);

        bool RefreshToken(int userId, string tokenHash, DateTime refreshDate);

    }
}
