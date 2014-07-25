using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenCBS.Online.Service
{
    public class DateHelper : IDateHelper
    {
        public DateTime Now {
            get { 
                return DateTime.Now;
            }
        }
    }
}