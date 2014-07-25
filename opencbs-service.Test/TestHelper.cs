using Nancy.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OpenCBS.Online.Service.Test
{
    public static class TestHelper
    {
        
        public static BrowserResponse JsonBodyPost(String pattern, object body, Bootstrapper bootstrapper = null, Browser browser = null)
        {
            if (bootstrapper == null)
                bootstrapper = new Bootstrapper();

            if (browser == null)
                browser = new Browser(bootstrapper);

            return browser.Post(RouterPattern.Security.Authenticate, with =>
            {
                with.Body(JsonConvert.SerializeObject(body), "application/json");
                with.HttpRequest();
            });
        }

        public static void RunSqlFromScriptFile(string filePath)
        {
            string script = File.ReadAllText(filePath);

            // split script on GO command
            IEnumerable<string> commandStrings = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
            conn.Open();

            foreach (string commandString in commandStrings)
            {
                if (commandString.Trim() != "")
                {
                    new SqlCommand(commandString, conn).ExecuteNonQuery();
                }
            }

            conn.Close();
        }

        public static string AssemblyParentDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                DirectoryInfo di = new DirectoryInfo(Path.GetDirectoryName(path));
                return di.Parent.Parent.Parent.FullName;
            }
        }

        internal static void InsertTestData()
        {
            RunSqlFromScriptFile(String.Format(@"{0}\sql\Initial-Data.sql", AssemblyParentDirectory));
        }

        internal static void DeleteTestData()
        {
            RunSqlFromScriptFile(String.Format(@"{0}\sql\Wipe-Data.sql", AssemblyParentDirectory));
        }

        
    }
}
