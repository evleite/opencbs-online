using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NLog;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenCBS.Online.Service.Json
{
    public class JsonIocSerializer<T> : CustomCreationConverter<T>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private IContainer container;

        public JsonIocSerializer(IContainer container)
        {
            logger.Debug("Instantiate JsonIocSerializer for " + typeof(T));
            this.container = container;
        }

        public override T Create(Type objectType)
        {
            logger.Debug("Create new " + typeof(T));
            return container.GetInstance<T>();
        }
    }
}