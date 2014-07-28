using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using OpenCBS.Online.Service.Security.Encryption;
using System.Security.Cryptography;

namespace OpenCBS.Online.Service.Test.Security.Encryption
{
    /// <summary>
    /// The text fixture for <see cref="EncrypterTest" />.
    /// </summary>
    [TestFixture]
    public class EncrypterTest
    {
        /// <summary>
        /// Test for <see cref="EncrypterTest" />.
        /// </summary>
        [Test]
        public void GetSaltTest()
        {
            var encrypter = new Encrypter();
            var salt = encrypter.GetSalt();
            Assert.AreEqual(24, salt.Length);
            var salt2 = encrypter.GetSalt();
            
            // check whether the byte array is the same
            bool same = true;
            for (int x = 0; x < 24; x++)
            {
                if (salt[x] != salt2[x])
                    same = false;
            }

            Assert.IsFalse(same);
            Assert.AreNotEqual(Convert.ToBase64String(salt), Convert.ToBase64String(salt2));
        }

        [Test]
        public void EncryptDecryptTest()
        {
            var text1 = "text-to-encrypt";
            var text2 = "another-text-to-encrypt";
            
            var encrypter = new Encrypter();
            var salt1 = new byte[24] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };
            var salt2 = new byte[24] { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 };

            var encr1 = encrypter.Encrypt(text1, salt1);
            var encr2 = encrypter.Encrypt(text1, salt1);
            Assert.AreNotEqual(encr1, encr2);
            
            var decr1 = encrypter.Decrypt(encr1, salt1);
            var decr2 = encrypter.Decrypt(encr2, salt1);
            Assert.AreEqual(decr1, decr2);

            encr1 = encrypter.Encrypt(text1, salt1);
            encr2 = encrypter.Encrypt(text2, salt1);
            Assert.AreNotEqual(encr1, encr2);

            decr1 = encrypter.Decrypt(encr1, salt1);
            decr2 = encrypter.Decrypt(encr2, salt1);
            Assert.AreNotEqual(decr1, decr2);

            encr1 = encrypter.Encrypt(text1, salt1);
            encr2 = encrypter.Encrypt(text1, salt2);
            Assert.AreNotEqual(encr1, encr2);

            decr1 = encrypter.Decrypt(encr1, salt1);
            decr2 = encrypter.Decrypt(encr2, salt2);
            Assert.AreEqual(decr1, decr2);

            encr1 = encrypter.Encrypt(text1, salt1);
            encr2 = encrypter.Encrypt(text2, salt2);
            Assert.AreNotEqual(encr1, encr2);

            decr1 = encrypter.Decrypt(encr1, salt1);
            decr2 = encrypter.Decrypt(encr2, salt2);
            Assert.AreNotEqual(decr1, decr2);

            encr1 = encrypter.Encrypt(text1, salt1);
            Assert.Throws<CryptographicException>(() => encrypter.Decrypt(encr1, salt2));
            

        }
    }
}

