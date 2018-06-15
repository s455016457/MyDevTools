using MyDevTools.Plugin.EncryptionTools.Cryptos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDevTools.Plugin.EncryptionTools.Forms
{
    public partial class HMACSHA1SignForm : Form
    {
        public HMACSHA1SignForm()
        {
            InitializeComponent();
        }
        
        private void btn_CopyResult_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox_Result.Text.Trim());
        }

        private void btn_CreateSign_Click(object sender, EventArgs e)
        {
            textBox_Sign.Text = HMACSHA1Sign.CreatedSignKey();
        }

        private void btn_DoSign_Click(object sender, EventArgs e)
        {
            String sign = textBox_Sign.Text.Trim(),
                body = textBox_Body.Text.Trim();
            
            if (String.IsNullOrEmpty(sign))
            {
                MessageBox.Show("签名不能为空！", "温馨提示");
                return;
            }

            if (String.IsNullOrEmpty(body))
            {
                MessageBox.Show("待处理文本不能为空！", "温馨提示");
                return;
            }

            textBox_Result.Text = HMACSHA1Sign.SignStr(body, sign);
        }

        private void btn_Verify_Click(object sender, EventArgs e)
        {
            String result = String.Empty;
            String sign = textBox_Sign.Text.Trim(),
                body = textBox_Body.Text.Trim();

            if (String.IsNullOrEmpty(sign))
            {
                MessageBox.Show("签名不能为空！", "温馨提示");
                return;
            }

            if (String.IsNullOrEmpty(body))
            {
                MessageBox.Show("待处理文本不能为空！", "温馨提示");
                return;
            }

            try
            {
                var b = HMACSHA1Sign.VerifyStr(body, sign, out result);

                textBox_Result.Text = b ? result : String.Empty;

                MessageBox.Show(b ? "验证成功！" : "验证失败！", "温馨提示");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"错误");
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\x1')
            {
                ((TextBox)sender).SelectAll();
                e.Handled = true;
            }
        }
    }
}
