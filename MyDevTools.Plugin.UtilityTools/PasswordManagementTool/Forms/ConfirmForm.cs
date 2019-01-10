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
    public partial class ConfirmForm : Form
    {
        Func<String, Boolean> OkFunc = null;
        Func<Boolean> CancelFunc = null;
        public ConfirmForm(String Title,String Mesage,String Value,Func<String,Boolean> okFunc,Func<Boolean> cancelFunc=null)
        {
            InitializeComponent();
            Text = Title ?? "温馨提示";
            LabelMessage.Text = Mesage ?? "这里是信息";
            textBoxValue.Text = Value;
            OkFunc = okFunc;
            CancelFunc = cancelFunc;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (OkFunc == null || OkFunc(textBoxValue.Text))
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
        protected override void OnShown(EventArgs e)
        {
            textBoxValue.Select(0, 0);
            base.OnShown(e);
        }
    }
}
