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
    public partial class CreatePassword : Form
    {
        Func<String, Boolean> OkFunc = null;
        Func<Boolean> CancelFunc = null;
        public CreatePassword(Func<String, Boolean> okFunc, Func<Boolean> cancelFunc = null)
        {
            InitializeComponent();
            OkFunc = okFunc;
            CancelFunc = cancelFunc;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            String password = textBox_Password.Text.Trim(),password2=textBox_Password2.Text.Trim();
            if (String.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("请输入密码", "温馨提示");
                return;
            }
            if (!password.Equals(password2))
            {
                MessageBox.Show("确认密码不一致", "温馨提示");
                return;
            }

            if (OkFunc == null || OkFunc(password))
            {
                Close();
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (CancelFunc == null || CancelFunc())
            {
                Close();
            }
        }
    }
}
