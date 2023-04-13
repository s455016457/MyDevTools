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
