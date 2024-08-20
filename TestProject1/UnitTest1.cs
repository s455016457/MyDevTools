using Microsoft.Toolkit.Uwp.Notifications;
using static System.Net.Mime.MediaTypeNames;
using Windows.Foundation.Collections;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void AddNotification()
        {
            ToastNotificationManagerCompat.OnActivated += toastArgs =>
            {
                // Obtain the arguments from the notification
                ToastArguments args = ToastArguments.Parse(toastArgs.Argument);

                // Obtain any user input (text boxes, menu selections) from the notification
                ValueSet userInput = toastArgs.UserInput;

                Console.WriteLine("Toast toastArgs.UserInput: " + toastArgs.UserInput);
                Console.WriteLine("Toast activated. Args: " + toastArgs.Argument);
                
            };

            new ToastContentBuilder()
                .AddArgument("action", "viewConversation")
                .AddArgument("conversationId", 9813)
                .AddText("Andrew sent you a picture 我的测试")
                .AddText("Check this out, The Enchantments in Washington 测试通知!")
                //.AddButton(new ToastButton().SetContent("确定").AddArgument("action", "确定").SetBackgroundActivation())
                //.AddButton(new ToastButton().SetContent("取消").AddArgument("action", "取消").SetBackgroundActivation())
                .Show();
        }
        [Test]
        public void TesDataContractSerializer()
        {
            var path = AppDomain.CurrentDomain.RelativeSearchPath ?? "D:";
            {
                var dic = new Dictionary<string, object>
                {
                    { "Key1", "Value1" },
                    { "Key2", "Value2" },
                    { "Key3", "Value3" },
                    { "Key4", "Value4" },
                    { "Key5", "Value5" }
                };
                FileStream writer = new FileStream(Path.Combine(path, "Dictionary.xml"), FileMode.Create);
                var dicSerializer = new DataContractSerializer(typeof(Dictionary<string, object>));
                dicSerializer.WriteObject(writer, dic);
            }
            {
                FileStream writer = new FileStream(Path.Combine(path, "string.xml"), FileMode.Create);
                var stringSerializer = new DataContractSerializer(typeof(string));
                stringSerializer.WriteObject(writer, "测试字符串序列化成XML");
            }
            OpenDirectory(path);
        }

        [Test]
        public void TesDataContractSerializerRead()
        {
            var path = AppDomain.CurrentDomain.RelativeSearchPath ?? "D:";
            {
                var dicSerializer = new DataContractSerializer(typeof(Dictionary<string, object>));
                var stream = new FileStream(Path.Combine(path, "Dictionary.xml"), FileMode.Open);
                var data = dicSerializer.ReadObject(stream);
                var dic = data as Dictionary<string, object>;
                if (dic != null)
                {
                    foreach (var item in dic)
                    {
                        Console.WriteLine($"Key:{item.Key}  Value:{item.Value}");
                    }
                }
            }
            {
                var stringSerializer = new DataContractSerializer(typeof(string));
                var stream = new FileStream(Path.Combine(path, "string.xml"), FileMode.Open);
                var data = stringSerializer.ReadObject(stream);
                Console.WriteLine(data);
            }
        }

        private void OpenDirectory(string directory)
        {
            var p = new Process();
            p.StartInfo.FileName = "explorer.exe";
            p.StartInfo.Arguments = directory;
            p.Start();
        }
    }
}