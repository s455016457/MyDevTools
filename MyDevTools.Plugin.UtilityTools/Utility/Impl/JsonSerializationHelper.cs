using MyDevTools.Plugin.UtilityTools.PasswordManagementTool.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDevTools.Plugin.UtilityTools.Utility.Impl
{
    public class JsonSerializationHelper<T> : ISerializationHelper<T>
    {
        public T Deserialization(string message)
        {
            //return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(message,new JsonIReadOnlyListConverter<ExtensionField>());
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(message);
        }

        public string Serialization(T t)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(t);
        }
    }
}
