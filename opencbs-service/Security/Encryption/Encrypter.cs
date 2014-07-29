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

        public string Encrypt(string toEncrypt, byte[] password)
        {
            return BlockEncrypter.BlockEncrypter.EncryptStringBlock(toEncrypt, password);
        }

        public string Decrypt(string toDecrypt, byte[] password)
        {
            return BlockEncrypter.BlockEncrypter.DecryptStringBlock(toDecrypt, password);
        }
    }
}