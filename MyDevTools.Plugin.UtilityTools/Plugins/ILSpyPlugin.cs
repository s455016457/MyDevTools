using MyDevTools.Plugin.Attributes;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MyDevTools.Plugin.UtilityTools.Plugins
{
    [Plugin(Group = PluginGroup.Compile, Title = "ILSpyPlugin", Author = "ICSharpCode团队", Description = "ILSpy是开源的.NET程序集浏览器和反编译器")]
    public class ILSpyPlugin : AbstractPlugin
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
                ProcessStartInfo startInfo = new ProcessStartInfo(Application.StartupPath + "\\Plugins\\UtilityTools\\可执行文件\\ILSpy_binaries\\ILSpy.exe");
                startInfo.UseShellExecute = false;
                process.StartInfo = startInfo;
                process.Start();
            }
        }
    }
}
