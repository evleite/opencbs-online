using OpenCBS.Online.Service.Models;
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


        public bool IsWithinTimeOutLimit(DateTime toCheck)
        {
            if (toCheck <= (Now.AddMinutes(Settings.TimeOutInMinutes)))
                return true;
            
            return false;
        }
    }
}