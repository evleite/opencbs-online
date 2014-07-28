namespace OpenCBS.Online.Service
{
    using Nancy;
    using Nancy.Bootstrapper;
    using Nancy.Bootstrappers.StructureMap;
    using StructureMap;
    using OpenCBS.Online.Service.Extensions;
    using Nancy.Session;

    public class Bootstrapper : StructureMapNancyBootstrapper 
    {
        
        protected override void ApplicationStartup(IContainer container, IPipelines pipelines)
        {
            // No registrations should be performed in here, however you may
            // resolve things that are needed during application startup.
            //base.ApplicationStartup(container, pipelines);
        
        }

        protected override void ConfigureApplicationContainer(IContainer existingContainer)
        {
            // Perform registation that should have an application lifetime

            // Add the default Application Registry
            existingContainer.RegisterForApplication();
            
        }

        protected override void ConfigureRequestContainer(IContainer container, NancyContext context)
        {
            // Perform registrations that should have a request lifetime
        }

        protected override void RequestStartup(IContainer container, IPipelines pipelines, NancyContext context)
        {
            // No registrations should be performed in here, however you may
            // resolve things that are needed during request startup.
        }

        public IContainer Container
        {
            get { return this.ApplicationContainer; }
        }
               
    }
}