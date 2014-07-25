using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenCBS.Online.Service.Extensions
{
    public static class ContainerExtensions
    {
        public static IContainer RegisterForApplication(this IContainer container)
        {
            container.Configure(c => c.AddRegistry<ApplicationRegistry>());
            return container;
        }
    }
}