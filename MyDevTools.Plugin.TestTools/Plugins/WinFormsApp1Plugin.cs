using MyDevTools.Plugin.Attributes;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MyDevTools.Plugin.UtilityTools.Plugins
{
    [Plugin(Group = PluginGroup.Test, Title = "WinFormsApp1Plugin", Author = "石鹏飞", Description = "测试WinForms全球化")]
    public class WinFormsApp1Plugin : AbstractPlugin
    {
        public override Icon Icon
        {
            get
            {
                return MyDevTools.Plugin.TestTools.Resources.favicon;
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
            MessageBox.Show(Application.StartupPath + "\\Plugins\\TestTools\\可执行文件\\WinFormsApp1\\WinFormsApp1.exe");
            using (Process process = new Process())
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(Application.StartupPath + "\\Plugins\\TestTools\\可执行文件\\WinFormsApp1\\WinFormsApp1.exe");
                startInfo.UseShellExecute = false;
                process.StartInfo = startInfo;
                process.Start();
            }
        }
    }
}
