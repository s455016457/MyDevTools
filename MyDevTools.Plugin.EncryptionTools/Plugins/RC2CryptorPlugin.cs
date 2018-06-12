using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyDevTools.Plugin;
using MyDevTools.Plugin.Attributes;
using MyDevTools.Plugin.EncryptionTools.Forms;

namespace MyDevTools.Plugin.EncryptionTools.Plugins
{
    [Plugin(Group = PluginGroup.Crypto, Title = "RC2加密", Author = "石鹏飞", Description = "RC2对称加密，需要秘钥和偏移量，仅用于与旧应用程序和数据的兼容性。考虑使用Aes算法及其派生类而不是RC2CryptoServiceProvider类")]
    public class RC2CryptorPlugin : AbstractPlugin
    {
        private RC2CryptoForm _form;
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
                this._form = new RC2CryptoForm();
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
