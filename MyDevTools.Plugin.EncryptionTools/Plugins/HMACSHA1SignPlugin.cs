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
    [Plugin(Group = PluginGroup.Crypto, Title = "HMACSHA1签名", Author = "石鹏飞", Description = "HMACSHA1签名，对密文或明文签名，验证签名并显示密文或明文")]
    public class HMACSHA1Sign : AbstractPlugin
    {
        private HMACSHA1SignForm _form;
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
                this._form = new HMACSHA1SignForm();
                this._form.FormClosing += delegate (object sender, FormClosingEventArgs e)
                {
                    this._form = null;
                };
            }
            if (this._form.WindowState == FormWindowState.Minimized)
            {
                this._form.WindowState = FormWindowState.Normal;
                this._form.StartPosition = FormStartPosition.CenterParent;
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
