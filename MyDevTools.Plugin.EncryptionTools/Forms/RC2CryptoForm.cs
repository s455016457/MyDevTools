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
    public partial class RC2CryptoForm : Form
    {
        public RC2CryptoForm()
        {
            InitializeComponent();
            comboBox_EncryptType.SelectedIndex = 0;
        }

        private void btn_CreateKey_Click(object sender, EventArgs e)
        {
            if (isIvEncrypt())
            {
                var keyValue = RC2Crypto.CreateKey();
                textBox_Key.Text = keyValue.Key;
                textBox_IV.Text = keyValue.Value;
            }
            else
            {
                textBox_Key.Text = RC2Crypto.CreateKeyNoIv();
            }
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

            if (String.IsNullOrEmpty(iv)&& isIvEncrypt())
            {
                MessageBox.Show("偏移量不能为空！", "温馨提示");
                return;
            }

            if (String.IsNullOrEmpty(body))
            {
                MessageBox.Show("待处理文本不能为空！", "温馨提示");
                return;
            }

            if(isIvEncrypt())
                textBox_Result.Text = RC2Crypto.Encryptor(body, key, iv);
            else
                textBox_Result.Text = RC2Crypto.Encryptor(body, key);
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

            if (String.IsNullOrEmpty(iv) && isIvEncrypt())
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
                if (isIvEncrypt())
                    textBox_Result.Text = RC2Crypto.Decryptor(body, key, iv);
                else
                    textBox_Result.Text = RC2Crypto.Decryptor(body, key);
            }
            catch (Exception ex)
            {
                MessageBox.Show("解密失败："+ex.Message, "错误");
            }
        }

        private Boolean isIvEncrypt()
        {
            return comboBox_EncryptType.SelectedItem.ToString().Equals("有偏移量加密", StringComparison.CurrentCultureIgnoreCase);
        }

        private void btn_CopyResult_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox_Result.Text.Trim());
        }

        private void comboBox_EncryptType_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox_Key.Text = string.Empty;
            textBox_IV.Text = string.Empty;
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
