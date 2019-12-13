using MyDevTools.Plugin.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDevTools.Plugin.UtilityTools.Plugins
{
    [Plugin(Group = PluginGroup.FileHelper, Title = "IHasher", Author = "Itellyou站长", Description = "计算并验证文件的has值")]
    public class IHasherPlugin : AbstractPlugin
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
                ProcessStartInfo startInfo = new ProcessStartInfo(Application.StartupPath + "\\Plugins\\UtilityTools\\可执行文件\\iHasher-v0.2.exe");
                startInfo.UseShellExecute = false;
                process.StartInfo = startInfo;
                process.Start();
            }
        }
    }
}
