namespace OpenCBS.Online.Service
{
    using Nancy;
    using System;

    public class IndexModule : BaseModule
    {
        public IndexModule()
        {
            var test = new { Test1 = "test 1", Test2 = "test2" };
            Get["/"] = parameters =>
            {
                return Response.AsJson(new[] { test });
            };

            Post["/"] = parameters =>
            {
                return Response.AsJson(new[] { test });
            };
            
        }
    }
}