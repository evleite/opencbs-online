using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Data;
using System.Configuration;
using OpenCBS.Manager;
using OpenCBS.CoreDomain;
using OpenCBS.Services;

namespace OpenCBS.Service.Tests.Core.Manager
{
    /// <summary>
    /// The text fixture for <see cref="UserManagerTest" />.
    /// </summary>
    [TestFixture]
    public class UserManagerTest
    {        
        [TestFixtureSetUp]
        public void SetUp()
        {
            TestHelper.DeleteTestData();
            TestHelper.InsertTestData();
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            
        }

        /// <summary>
        /// Test for <see cref="UserManager" />.
        /// </summary>
        [Test]
        public void AddUserTest()
        {
                        
            var role = new Role
            {
                RoleName = "CASHI",
                Id = 2,
                IsDeleted = false,
                Description = "Cashier role"
            };
                        
            var userManager = new UserManager();
            var user = new User
            {
                FirstName = "Test2",
                LastName = "User2",
                Mail = "test2@test2.te2",
                UserName = "testuser2",
                Password = "testpassword2",
                Role = User.Roles.CASHI,
                UserRole = role,
                Phone = "+987654321",
                Sex = 'F'
            };            

            int userId = userManager.AddUser(user);

            var userResult = userManager.SelectUser(userId, true);

            Assert.AreEqual(userId, userResult.Id);
            Assert.AreEqual(user.FirstName, userResult.FirstName);
            Assert.AreEqual(user.LastName, userResult.LastName);
            Assert.AreEqual(user.UserName, userResult.UserName);
            Assert.AreEqual(user.UserRole.Id, userResult.UserRole.Id);
            Assert.AreEqual(user.UserRole.RoleName, userResult.UserRole.RoleName);
            //Assert.AreEqual(user.Password, userResult.Password);
            Assert.AreEqual(user.Mail, userResult.Mail);
            Assert.AreEqual(user.Role, userResult.Role);
            Assert.AreEqual(user.Phone, userResult.Phone);
            Assert.AreEqual(user.Sex, userResult.Sex);



        }

        

    }
}

