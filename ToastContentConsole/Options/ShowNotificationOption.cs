using CommandLine;
using CommandLine.Text;
using Microsoft.Toolkit.Uwp.Notifications;

namespace ToastContentConsole.Options
{
    [Verb("ShowNotification", true, HelpText = "显示通知")]
    class ShowNotificationOption
    {
        /// <summary>
        /// 通知抬头
        /// </summary>
        [Option('t', HelpText = "通知抬头", Required = true)]
        public string Title { get; set; } = string.Empty;
        /// <summary>
        /// 通知信息
        /// </summary>
        [Option('m', HelpText = "通知信息", Required = true)]
        public string Message { get; set; } = string.Empty;

        [Usage(ApplicationAlias = "ToastContentConsole")]
        public static IEnumerable<Example> Examples
        {
            get
            {
                yield return new Example("显示通知", new ShowNotificationOption { Title = "这里是通知抬头", Message = "这里是通知信" });
            }
        }

        public void Execute()
        {
            Console.WriteLine($"获取到的参数为：{Title}  {Message}");
            new ToastContentBuilder()
                .AddArgument("action", "viewConversation")
                .AddArgument("conversationId", 9813)
                .AddText(Title)
                .AddText(Message)
                .Show();
        }
    }
}
