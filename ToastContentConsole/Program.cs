// See https://aka.ms/new-console-template for more information
// https://learn.microsoft.com/zh-cn/windows/apps/design/shell/tiles-and-notifications/send-local-toast?tabs=desktop-msix
// https://github.com/commandlineparser/commandline


using CommandLine;
using ToastContentConsole.Options;

namespace ToastContentConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //var str = "ShowNotification -m 这里是通知信 -t 这里是通知抬头";
            //args = str.Split(' ');
            var result = Parser.Default.ParseArguments<ShowNotificationOption>(args);
            if (result != null&&result.Errors.Count()<=0)
            {
                result.MapResult(
                options =>
                {
                    return RunAndReturnExitCode(options);
                }
                , _ => 1);
            }
        }

        static int RunAndReturnExitCode(ShowNotificationOption options)
        {
            options.Execute();
            return 0;
        }
    }
}
