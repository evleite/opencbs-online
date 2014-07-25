using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenCBS.Online.Service.Security.Encryption
{
    public class Encrypter : IEncrypter
    {
        public byte[] GetSalt()
        {
            return BlockEncrypter.BlockEncrypter.GetSalt();
        }

        public string Encrypt(string toEncypt, byte[] password)
        {
            return BlockEncrypter.BlockEncrypter.EncryptStringBlock(toEncypt, password);
        }

        public string Decrypt(string toEncypt, byte[] password)
        {
            return BlockEncrypter.BlockEncrypter.DecryptStringBlock(toEncypt, password);
        }
    }
}