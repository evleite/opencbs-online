using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace OpenCBS.Online.Service.Models
{
    public class Settings
    {
        /// <summary>
        /// Sessions timeout in minutes
        /// </summary>
        public static int TimeoutValue { get; set; }

        public static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["Default"].ConnectionString; }
        }
    }
}