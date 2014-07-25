namespace OpenCBS.Online.Service
{
    using Nancy;
    using System;

    public class IndexModule : BaseModule
    {
        public IndexModule()
        {
            
            Get["/"] = parameters =>
            {
                var sessKey = Request.Session["Key"];
                if (sessKey == null)
                {
                    Guid g = Guid.NewGuid();
                    Request.Session["Key"] = g.ToString();
                    sessKey = g.ToString();
                }

                var test = new { Test1 = "test 1", Test2 = "test2", SessionKey = sessKey };
                                
                return Response.AsJson(new[] { test });
            };

            
        }
    }
}