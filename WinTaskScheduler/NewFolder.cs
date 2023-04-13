using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinTaskScheduler
{
    public partial class NewFolder : Form
    {
        private TaskFolder parentFolder;
        public NewFolder(TaskFolder parentFolder)
        {
            this.parentFolder = parentFolder;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtFolder.Text.Length <= 0)
            {
                errorProvider1.SetError(txtFolder, "文件夹名称不能为空！");
                return;
            }

            parentFolder.CreateFolder(txtFolder.Text);
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
