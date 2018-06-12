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
    [Plugin(Group = PluginGroup.Test, Title = "非对称加密聊天", Author = "石鹏飞", Description = "非对称加密聊天，Alice发送给Bob的消息，用Bob的公钥加密，然后用Alice的私钥签名，Bob收到消息后用Alice的公钥验证签名，并用自己的私钥解密消息。")]
    public class RSACryptoChatPlugin : AbstractPlugin
    {
        private RSACryptoChatForm _form;
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
                this._form = new RSACryptoChatForm();
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
