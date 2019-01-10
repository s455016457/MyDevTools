using System.Drawing;
using System.Windows.Forms;
using MyDevTools.Plugin.Attributes;
using MyDevTools.Plugin.UtilityTools.DownloadImage;

namespace MyDevTools.Plugin.UtilityTools.Plugins
{
    [Plugin(Group = PluginGroup.Utility, Title = "图片下载工具", Author = "石鹏飞", Description = "根据图片URL地址，将图片从网上下载下来")]
    public class DownLoadImagePlugin : AbstractPlugin
    {
        private DownloadForm _form;
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
                this._form = new DownloadForm();
                this._form.FormClosing += delegate (object sender, FormClosingEventArgs e)
                {
                    this._form = null;
                };
                _form.StartPosition = FormStartPosition.CenterScreen;
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
