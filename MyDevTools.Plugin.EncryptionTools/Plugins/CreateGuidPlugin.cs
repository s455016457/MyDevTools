using MyDevTools.Plugin.Attributes;
using MyDevTools.Plugin.EncryptionTools.Forms;
using System.Drawing;
using System.Windows.Forms;

namespace MyDevTools.Plugin.EncryptionTools.Plugins
{
    [Plugin(Group = PluginGroup.Crypto, Title = "创建Guid", Author = "石鹏飞", Description = "创建Guid。")]
    public class CreateGuidPlugin : AbstractPlugin
    {
        private CreateGuidForm _form;
        public override Icon Icon
        {
            get
            {
                return Resources.DES;
            }
        }
        public override void StartUp()
        {
            if (this._form == null)
            {
                this._form = new CreateGuidForm();
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
