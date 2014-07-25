using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Encryptor = BlockEncrypter.BlockEncrypter;
using System.Security.Cryptography;

namespace OpenCBS.Online.Service.Test.Security.Encryption
{
    /// <summary>
    /// The text fixture for <see cref="BlockEncryptorTest" />.
    /// </summary>
    [TestFixture]
    public class BlockEncryptorTest
    {
        /// <summary>
        /// Test for <see cref="BlockEncryptorTest" />.
        /// </summary>
        [Test]
        public void EncryptorTest()
        {
            var salt1 = Encryptor.GetSalt();
            var salt2 = Encryptor.GetSalt();
            
            var encription1 = Encryptor.EncryptStringBlock("org-password", salt1);
            var encription2 = Encryptor.EncryptStringBlock("org-password", salt2);

            Assert.AreNotEqual(encription1, encription2);

            var password1 = Encryptor.DecryptStringBlock(encription1, salt1);
            var password2 = Encryptor.DecryptStringBlock(encription2, salt2);

            Assert.Throws<CryptographicException>(() => Encryptor.DecryptStringBlock(encription1, salt2));
            Assert.Throws<CryptographicException>(() => Encryptor.DecryptStringBlock(encription2, salt1));
            
            Assert.AreEqual(password1, password2);
            Assert.AreEqual("org-password", password1);
            Assert.AreEqual("org-password", password2);

        }

        [Test]
        public void SpeedTest()
        {
            var salt1 = Encryptor.GetSalt();
            var encription1 = Encryptor.EncryptStringBlock("org-password", salt1);
            var password1 = Encryptor.DecryptStringBlock(encription1, salt1);
            Assert.AreEqual("org-password", password1);
            
        }
    }
}

