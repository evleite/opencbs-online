using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCBS.Online.Service.IntegrationTest
{
    public static class ExtensionTestHelper
    {
        public static DateTime RemoveMilliseconds(this DateTime date)
        {
            return date.Subtract(new TimeSpan(0, 0, 0, 0, date.Millisecond));
        }

        public static bool SqlEquals(this DateTime first, DateTime second)
        {
            bool same = true;
            if (first.Year != second.Year)
                same = false;
            if (first.Month != second.Month)
                same = false;
            if (first.Day != second.Day)
                same = false;
            if (first.Hour != second.Hour)
                same = false;
            if (first.Minute != second.Minute)
                same = false;
            if (first.Second != second.Second)
                same = false;

            return same;
        }
        
    }
}
