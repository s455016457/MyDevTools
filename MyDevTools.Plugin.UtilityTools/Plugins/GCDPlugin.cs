using MyDevTools.Plugin.Attributes;
using MyDevTools.Plugin.UtilityTools.Maths;
using System.Drawing;
using System.Windows.Forms;

namespace MyDevTools.Plugin.UtilityTools.Plugins
{
    [Plugin(Group = PluginGroup.Math, Title = "最大公约数", Author = "石鹏飞", Description = "计算两个数的最大公约数")]
    public class GCDPlugin : AbstractPlugin
    {
        private GCDForm _form;
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
                this._form = new GCDForm();
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
