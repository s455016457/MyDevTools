using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyDevTools.Plugin;
using MyDevTools.Plugin.Attributes;
using MyDevTools.Plugin.UtilityTools.PasswordManagementTool.Forms;

namespace MyDevTools.Plugin.UtilityTools.Plugins
{
    [Plugin(Group = PluginGroup.Utility, Title = "密码管理工具", Author = "石鹏飞", Description = "密码管理工具")]
    public class PasswordManagementToolPlugin : AbstractPlugin
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
