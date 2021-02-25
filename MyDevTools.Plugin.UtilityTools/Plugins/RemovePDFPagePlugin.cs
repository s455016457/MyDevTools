using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using MyDevTools.Plugin.Attributes;
using MyDevTools.Plugin.UtilityTools.Maths;
using MyDevTools.Plugin.UtilityTools.PDF;

namespace MyDevTools.Plugin.UtilityTools.Plugins
{
    [Plugin(Group = PluginGroup.FileHelper, Title = "删除PDF指定页", Author = "石鹏飞", Description = "删除PDF指定页")]
    public class RemovePDFPagePlugin : AbstractPlugin
    {
        private MyDevTools.Plugin.UtilityTools.PDF.RemovePDFPages _form;
        public override void Reset()
        {
            MessageBox.Show("不支持重置配置！");
        }
        public override void Config()
        {
            MessageBox.Show("不支持配置！");
        }
        public override void StartUp()
        {
            if (this._form == null)
            {
                this._form = new MyDevTools.Plugin.UtilityTools.PDF.RemovePDFPages();
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
    }
}
