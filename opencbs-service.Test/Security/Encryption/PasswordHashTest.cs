using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using System.Text;
using OpenCBS.Online.Service.Security.Encryption;

namespace OpenCBS.Online.Service.Test.Security.Encryption
{
    /// <summary>
    /// The text fixture for <see cref="PasswordHashTest" />.
    /// </summary>
    [TestFixture]
    public class PasswordHashTest
    {
        /// <summary>
        /// Test for <see cref="PasswordHashTest" />.
        /// </summary>
        [Test]
        public void HashPasswordTest()
        {
            string orgPassword = "org-password";
            var passwordHash = new PasswordHash();
            var hashedPassword = passwordHash.CreateHash(orgPassword);

            StringBuilder sb = new StringBuilder(); 
            foreach(char c in hashedPassword.ToString()){
                sb.Append(c);
            }

            var enteredPassword = sb.ToString();
            var validateResult = passwordHash.ValidatePassword("org-password", hashedPassword.ToString());

            Assert.AreEqual(hashedPassword.ToString(), enteredPassword);
            Assert.IsTrue(validateResult);

            PasswordHash.HashInfo hi = new PasswordHash.HashInfo(hashedPassword.ToString());
            Assert.AreEqual("sha1", hi.Method);
            Assert.AreEqual(PasswordHash.PBKDF2_ITERATIONS, hi.Iterations);

            Assert.AreEqual(hashedPassword.ToString().Split(':')[0], hi.Method);
            Assert.AreEqual(Int32.Parse(hashedPassword.ToString().Split(':')[1]), hi.Iterations);
            Assert.AreEqual(hashedPassword.ToString().Split(':')[2], hi.Salt);
            Assert.AreEqual(hashedPassword.ToString().Split(':')[3], hi.Hash);

            hi.Dispose();
            Assert.AreEqual(":0::", hi.ToString());

            PasswordHash.HashInfo hi2 = new PasswordHash.HashInfo
            {
                Method = "sha1",
                Iterations = 1000,
                Salt = "salt",
                Hash = "hash"
            };

            Assert.AreEqual("sha1:1000:salt:hash", hi2.ToString());
            hi2.Dispose();
            Assert.AreEqual(":0::", hi2.ToString());
            

        }
    }
}

