using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using OpenCBS.Online.Service.Models;

namespace OpenCBS.Online.Service.Test
{
    /// <summary>
    /// The text fixture for <see cref="DateHelperTest" />.
    /// </summary>
    [TestFixture]
    public class DateHelperTest
    {
        /// <summary>
        /// Test for <see cref="DateHelperTest" />.
        /// </summary>
        [Test]
        public void NowTest()
        {
            var dateHelper = new DateHelper();
            var orgNow = DateTime.Now;
            var newNow = dateHelper.Now;
            Assert.IsTrue(orgNow <= newNow);

        }

        [Test]
        public void IsWithinTimeOutLimitTest()
        {
            Settings.TimeOutInMinutes = 30;
            var expired = DateTime.Now.AddMinutes(-60);
            var valid = DateTime.Now.AddMinutes(-15);
                        
            var dateHelper = new DateHelper();

            Assert.IsFalse(dateHelper.IsWithinTimeOutLimit(expired));
            Assert.IsTrue(dateHelper.IsWithinTimeOutLimit(valid));
        }
    }
}

