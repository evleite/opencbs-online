using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCBS.Online.Service.Security.Encryption
{
    public interface IEncrypter
    {

        byte[] GetSalt();
        string Encrypt(string toEncrypt, byte[] password);
        string Decrypt(string toDecrypt, byte[] password);
    }
}
