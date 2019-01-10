using MyDevTools.Plugin.Attributes;
using MyDevTools.Plugin.UtilityTools.JS混淆;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDevTools.Plugin.UtilityTools.Plugins
{
    [Plugin(Group = PluginGroup.Utility, Title = "JS混淆工具", Author = "石鹏飞", Description = "JS混淆工具")]
    public class JSConfusionPlugin : AbstractPlugin
    {
        private MainForm _form;
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
                this._form = new MainForm();
                this._form.FormClosing += delegate (object sender, FormClosingEventArgs e)
                {
                    this._form = null;
                };
                _form.StartPosition = FormStartPosition.CenterScreen;
                _form.Icon = _form.Icon == null ? Icon : _form.Icon;
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
