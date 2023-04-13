using MyDevTools.Plugin.Attributes;
using MyDevTools.Plugin.UtilityTools.DownloadImage;
using MyDevTools.Plugin.UtilityTools.TaskScheduler;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDevTools.Plugin.UtilityTools.Plugins
{
    [Plugin(Group = PluginGroup.Utility, Title = "任务计划", Author = "石鹏飞", Description = "添加Windows计划任务")]
    public class TaskSchedulerPlugin : AbstractPlugin
    {
        private TaskList _form;
        public override Icon Icon
        {
            get
            {
                return Resources.waixingren;
            }
        }
        public override void StartUp()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("zh-CN");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-CN");
            MessageBox.Show($"Application.CurrentCulture.DisplayName:{Application.CurrentCulture.DisplayName}");
            MessageBox.Show($"Thread.CurrentThread.CurrentCulture.DisplayName:{Thread.CurrentThread.CurrentCulture.DisplayName}");
            MessageBox.Show($"Thread.CurrentThread.CurrentUICulture.DisplayName:{Thread.CurrentThread.CurrentUICulture.DisplayName}");
            if (this._form == null)
            {
                this._form = new TaskList();
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
