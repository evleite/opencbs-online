using Newtonsoft.Json;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenCBS.Online.Service.Json
{
    public static class JsonIocConvert
    {
        /// <summary>
        /// Deserializes a json string to T using a custom Json serializer <see cref="JsonIocSerializer"/>. The method is a wrapper around the standard <see cref="JsonConvert.DeserializeObject"/> from <see cref="Newtonsoft.Json"/>.
        /// </summary>
        /// <typeparam name="T">Type T to convert to</typeparam>
        /// <param name="json">JSON string to convert</param>
        /// <param name="container">IOC container from StructureMap to find the correct concrete type</param>
        /// <returns>Returns T from JSON</returns>
        public static T DeserializeObject<T>(string json, IContainer container)
        {
            return JsonConvert.DeserializeObject<T>(json, new JsonIocSerializer<T>(container));
        }        
    }
}