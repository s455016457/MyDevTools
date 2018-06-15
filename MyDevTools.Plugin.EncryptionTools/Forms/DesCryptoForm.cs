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
    public partial class DesCryptoForm : Form
    {
        public DesCryptoForm()
        {
            InitializeComponent();
        }

        private void btn_CreateKey_Click(object sender, EventArgs e)
        {
            var keyValue = DESCrypto.CreatedKey();
            textBox_Key.Text = keyValue.Key;
            textBox_IV.Text = keyValue.Value;
        }

        private void btn_Encrypt_Click(object sender, EventArgs e)
        {
            String key = textBox_Key.Text.Trim(),
                iv = textBox_IV.Text.Trim(),
                body = textBox_Body.Text.Trim();

            if (String.IsNullOrEmpty(key))
            {
                MessageBox.Show("秘钥不能为空！", "温馨提示");
                return;
            }

            if (String.IsNullOrEmpty(iv))
            {
                MessageBox.Show("偏移量不能为空！", "温馨提示");
                return;
            }


            if (String.IsNullOrEmpty(body))
            {
                MessageBox.Show("待处理文本不能为空！", "温馨提示");
                return;
            }

            textBox_Result.Text = DESCrypto.Encryptor(body, key, iv);
        }

        private void btn_Decrypt_Click(object sender, EventArgs e)
        {
            String key = textBox_Key.Text.Trim(),
                iv = textBox_IV.Text.Trim(),
                body = textBox_Body.Text.Trim();

            if (String.IsNullOrEmpty(key))
            {
                MessageBox.Show("秘钥不能为空！", "温馨提示");
                return;
            }

            if (String.IsNullOrEmpty(iv))
            {
                MessageBox.Show("偏移量不能为空！", "温馨提示");
                return;
            }


            if (String.IsNullOrEmpty(body))
            {
                MessageBox.Show("待处理文本不能为空！", "温馨提示");
                return;
            }

            try
            {
                textBox_Result.Text = DESCrypto.Decryptor(body, key, iv);
            }
            catch (Exception ex)
            {
                MessageBox.Show("解密失败：" + ex.Message, "错误");
            }
        }

        private void btn_CopyResult_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox_Result.Text.Trim());
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
