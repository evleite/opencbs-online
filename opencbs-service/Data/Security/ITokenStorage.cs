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
        bool StoreToken(PasswordHash.HashInfo hashedToken, string encryptedUserId, byte[] userIdSalt, DateTime issuedAt);
    }
}
