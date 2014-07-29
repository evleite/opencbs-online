using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace OpenCBS.Online.Service.Models
{
    public class Settings
    {
        private static int? timeOutInMinutes;
        /// <summary>
        /// Sessions timeout in minutes
        /// </summary>
        public static int TimeOutInMinutes { 
            get 
            {
                // return set timeout value
                if (timeOutInMinutes.HasValue)
                    return timeOutInMinutes.Value;
                
                // check configuration for timeout value
                int val = 0;
                if (Int32.TryParse(ConfigurationManager.AppSettings["TimeOutInMinutes"], out val))
                {
                    timeOutInMinutes = val;
                    return timeOutInMinutes.Value;
                }

                // return default timout value
                return 30;
        }
            set { timeOutInMinutes = value; }
        }

        public static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["Default"].ConnectionString; }
        }
    }
}