using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDevTools.Plugin.UtilityTools.TaskScheduler
{
    public partial class TaskList : Form
    {
        public TaskList()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-CN");
            MessageBox.Show($"Thread.CurrentContext.ContextID:{Thread.CurrentContext.ContextID}");
            InitializeComponent();
        }

        private void toolStripEditButton_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-CN");
            MessageBox.Show($"Application.CurrentCulture.DisplayName:{Application.CurrentCulture.DisplayName}");
            MessageBox.Show($"Thread.CurrentThread.CurrentCulture.DisplayName:{Thread.CurrentThread.CurrentCulture.DisplayName}");
            MessageBox.Show($"Thread.CurrentThread.CurrentUICulture.DisplayName:{Thread.CurrentThread.CurrentUICulture.DisplayName}");
            var dialog = new TaskEditDialog();
            dialog.ShowDialog();
        }
    }
}
