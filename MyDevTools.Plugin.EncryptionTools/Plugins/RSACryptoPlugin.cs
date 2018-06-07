using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyDevTools.Plugin;
using MyDevTools.Plugin.Attributes;

namespace MyDevTools.Plugin.EncryptionTools.Plugins
{
    [Plugin(Group = PluginGroup.Crypto, Title = "RSA加密", Author = "石鹏飞", Description = "RSA加密(非对称加密)，公钥加密私钥解密，私钥签名公钥验证签名。")]
    public class RSACryptoPlugin : AbstractPlugin
    {
        private RSACryptoForm _form;
        public override Icon Icon
        {
            get
            {
                return Resources.RSA;
            }
        }
        public override void StartUp()
        {
            if (this._form == null)
            {
                this._form = new RSACryptoForm();
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
