using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

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
    }
}

