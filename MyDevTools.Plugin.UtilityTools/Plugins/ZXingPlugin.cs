using System.Drawing;
using System.Windows.Forms;
using MyDevTools.Plugin.Attributes;
using MyDevTools.Plugin.UtilityTools.DownloadImage;

namespace MyDevTools.Plugin.UtilityTools.Plugins
{
    [Plugin(Group = PluginGroup.Utility, Title = "条码工具", Author = "石鹏飞", Description = "生成，识别条码 二维码")]
    public class ZXingPlugin : AbstractPlugin
    {
        private Form _form;
        public override Icon Icon
        {
            get
            {
                return Resources.waixingren;
            }
        }
        public override void StartUp()
        {
            if (this._form == null)
            {
                this._form = new MyZXing.MainForm() { Text = "条码工具", Icon = Icon, StartPosition = FormStartPosition.CenterScreen };
                this._form.FormClosing += delegate (object sender, FormClosingEventArgs e)
                {
                    this._form = null;
                };
            }
            if (this._form.WindowState == FormWindowState.Minimized)
            {
                this._form.WindowState = FormWindowState.Normal;
            }
            this._form.Show();
            this._form.BringToFront();
        }
        public override void Reset()
        {
            MessageBox.Show("不支持重置配置！");
        }
        public override void Config()
        {
            MessageBox.Show("不支持配置！");
        }
    }
}
