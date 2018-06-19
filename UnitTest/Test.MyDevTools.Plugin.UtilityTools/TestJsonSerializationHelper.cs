using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDevTools.Plugin.UtilityTools.PasswordManagementTool.Entity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Test.MyDevTools.Plugin.UtilityTools
{
    [TestClass]
    public class TestJsonSerializationHelper
    {
        [TestMethod]
        public void TestDeserializeObject()
        {
            String str = "[{\"Name\":\"test\",\"Address\":\"aaa\",\"Account\":\"3333333\",\"Email\":\"dfwef@54.sdfwe\",\"MobilPhone\":\"1232345423\",\"ExtensionFields\":[{\"Name\":\"AAAA1\",\"Value\":\"SDFWEFW\"},{\"Name\":\"AAAAAA2\",\"Value\":\"SDFWFEW\"}],\"SafetyProblems\":[{\"Problem\":\"BBBB1\",\"Solution\":\"SDFEWFWEFW11111BBBBB\"},{\"Problem\":\"BBBBB2\",\"Solution\":\"BBBB2SDFWEFWF\"}],\"PasswordItems\":[{\"Name\":\"CCCCC1\",\"Password\":\"CCCCC1SFWEFWF\",\"Remark\":\"CCCCC1SD2321123\"},{\"Name\":\"CCCCC2\",\"Password\":\"CCCC2SDFWWSDWEFEW\",\"Remark\":null}]}]";

            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PasswordProject>>(str);

            Assert.IsNotNull(obj.FirstOrDefault().ExtensionFields);
        }

        [TestMethod]
        public void TestDeserializeObject2()
        {
            String str = "[{\"Name\":\"AAAA1\",\"Value\":\"SDFWEFW\"},{\"Name\":\"AAAAAA2\",\"Value\":\"SDFWFEW\"}]";
            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ExtensionField>>(str,new JsonSerializerSettings
            {
                ConstructorHandling= ConstructorHandling.AllowNonPublicDefaultConstructor
            });

            Assert.IsNotNull(obj);
        }

        public class JsonExtensionFieldArrayConverter: JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return typeof(ExtensionField[]).IsAssignableFrom(objectType);
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                var jsonObject = JObject.Load(reader);
                var target = new ExtensionField[10];
                //将JSON值填充到目标对象中。
                serializer.Populate(jsonObject.CreateReader(), target);
                return target;
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }
    }
}
