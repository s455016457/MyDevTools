using System.Drawing;
using System.Windows.Forms;
using MyDevTools.Plugin.Attributes;
using MyDevTools.Plugin.UtilityTools.DownloadImage;
using MyDevTools.Plugin.UtilityTools.WebSocket;

namespace MyDevTools.Plugin.UtilityTools.Plugins
{
    [Plugin(Group = PluginGroup.Utility, Title = "WebSocket客户端", Author = "石鹏飞", Description = "WebSocket客户端")]
    public class WebSocketClientPlugin : AbstractPlugin
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
                this._form = new WebSocketClientForm();
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
