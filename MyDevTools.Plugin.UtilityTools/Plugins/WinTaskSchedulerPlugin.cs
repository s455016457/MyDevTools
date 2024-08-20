using MyDevTools.Plugin.Attributes;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MyDevTools.Plugin.UtilityTools.Plugins
{
    [Plugin(Group = PluginGroup.System, Title = "Windows任务计划", Author = "石鹏飞", Description = "提供Windows任务计划管理")]
    public class WinTaskSchedulerPlugin : AbstractPlugin
    {
        public override Icon Icon
        {
            get
            {
                return Resources.waixingren;
            }
        }
        public override void Reset()
        {
            MessageBox.Show("不支持重置配置！");
        }
        public override void Config()
        {
            MessageBox.Show("不支持配置！");
        }

        public override void StartUp()
        {
            using (Process process = new Process())
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(Application.StartupPath + "\\Plugins\\UtilityTools\\可执行文件\\WinTaskScheduler\\WinTaskScheduler.exe");
                startInfo.UseShellExecute = false;
                process.StartInfo = startInfo;
                process.Start();
            }
        }
    }
}
