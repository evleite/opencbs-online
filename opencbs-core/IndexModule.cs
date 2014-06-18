namespace OpenCBS.Online.Core
{
    using Nancy;

    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            var test = new { Test1 = "test 1", Test2 = "test2" };
            Get["/"] = parameters => Response.AsJson(new[] { test });
            
        }
    }
}