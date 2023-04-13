using Microsoft.Win32.TaskScheduler;
using System.Globalization;
using System.Resources;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            // 必须在InitializeComponent 函数之前调用
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-CN");
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();
            form2.Show();
            var dialog = new TaskEditDialog();
            dialog.Show();
        }
    }
}