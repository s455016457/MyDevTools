using MyDevTools.Plugin.UtilityTools.PasswordManagementTool.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDevTools.Plugin.UtilityTools.PasswordManagementTool.Forms
{
    public partial class UpdatePassword : Form
    {
        internal IPassworkProjectRepository repository { get; private set; }
        public UpdatePassword(IPassworkProjectRepository repository)
        {
            InitializeComponent();
            this.repository = repository;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            String oldPassword = textBox_OldPassword.Text.Trim()
                ,password = textBox_Password.Text.Trim()
                ,password2=textBox_Password2.Text.Trim();

            if (String.IsNullOrWhiteSpace(oldPassword))
            {
                MessageBox.Show("请输入旧密码", "温馨提示");
                return;
            }
            if (String.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("请输入新密码", "温馨提示");
                return;
            }
            if (!password.Equals(password2))
            {
                MessageBox.Show("确认密码不一致", "温馨提示");
                return;
            }

            if (!repository.VerificationPassword(oldPassword))
            {
                MessageBox.Show("旧密码不正确！", "温馨提示");
                return;
            }

            repository.UpdatePassword(password);
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
