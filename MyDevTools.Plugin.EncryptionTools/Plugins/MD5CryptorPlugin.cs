using MyDevTools.Plugin.Attributes;
using MyDevTools.Plugin.EncryptionTools.Forms;
using System.Drawing;
using System.Windows.Forms;

namespace MyDevTools.Plugin.EncryptionTools.Plugins
{
    [Plugin(Author ="石鹏飞",Group =PluginGroup.Crypto,Title ="MD5",Description ="不可逆加密")]
    public class MD5CryptorPlugin : AbstractPlugin
    {
        private MD5CryptoForm _form;
        public override Icon Icon
        {
            get
            {
                return Resources.AES;
            }
        }
        public override void StartUp()
        {
            if (this._form == null)
            {
                this._form = new MD5CryptoForm()
                {
                    StartPosition=FormStartPosition.CenterScreen
                };
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
