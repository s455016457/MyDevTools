﻿using System;
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
    [Plugin(Group = PluginGroup.Crypto, Title = "DES加密", Author = "石鹏飞", Description = "DES对称加密，需要秘钥和偏移量")]
    public class DesCryptoPlugin : AbstractPlugin
    {
        private DesCryptoForm _form;
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
                this._form = new DesCryptoForm();
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
