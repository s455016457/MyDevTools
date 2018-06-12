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
    [Plugin(Group = PluginGroup.Crypto, Title = "Rijndael加密", Author = "石鹏飞", Description = "Rijndael对称加密，需要秘钥和偏移量。Rijndael算法是Aes的前身。您应该使用Aes类而不是RijndaelManaged")]
    public class RijndaelCryptoPlugin : AbstractPlugin
    {
        private RijndaelCryptoForm _form;
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
                this._form = new RijndaelCryptoForm();
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
