using MyDevTools.Plugin.EncryptionTools.Cryptos;
using MyDevTools.Plugin.EncryptionTools.Extends;
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
    public partial class AesCryptoForm : Form
    {
        public AesCryptoForm()
        {
            InitializeComponent();
            comboBox_EncryptType.SelectedIndex = 0;
            comboBox_KeyDisplayFormat.SelectedIndex = 0;
            comboBox_CiphertextDisplayFormat.SelectedIndex = 0;
        }

        private void btn_CreateKey_Click(object sender, EventArgs e)
        {
            var keyValue = AesCrypto.CreateKeyAndIvBytes();
            if (!isIvEncrypt())
            {
                keyValue = new KeyValuePair<byte[], byte[]>(keyValue.Key, null);
            }
            DisplayKey(keyValue);
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
            var keyValue = KeyToBytes();
            byte[] bytes = AesCrypto.Encrypt(Encoding.UTF8.GetBytes(body), keyValue.Key, keyValue.Value);
            DisplayCiphertexts(bytes);
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
                var keyValue = KeyToBytes();
                byte[] bytes = CiphertextsToBytes();
                textBox_Result.Text = Encoding.UTF8.GetString(AesCrypto.Decrypt(bytes, keyValue.Key, keyValue.Value));
            }
            catch (Exception ex)
            {
                MessageBox.Show("解密失败：" + ex.Message, "错误");
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

        private void DisplayKey(KeyValuePair<Byte[], Byte[]> keyValue)
        {
            if (comboBox_KeyDisplayFormat.SelectedItem.ToString().Equals("Base64String", StringComparison.CurrentCultureIgnoreCase))
            {
                textBox_Key.Text = Convert.ToBase64String(keyValue.Key);
                if (keyValue.Value != null)
                {
                    textBox_IV.Text = Convert.ToBase64String(keyValue.Value);
                }
            }
            else if (comboBox_KeyDisplayFormat.SelectedItem.ToString().Equals("BitString", StringComparison.CurrentCultureIgnoreCase))
            {
                textBox_Key.Text = keyValue.Key.ToBitString("");
                if (keyValue.Value != null)
                {
                    textBox_IV.Text = keyValue.Value.ToBitString("");
                }
            }
            else
            {
                MessageBox.Show("未知的显示格式："+comboBox_KeyDisplayFormat.SelectedItem, "错误");
            }
        }

        private KeyValuePair<byte[], byte[]> KeyToBytes()
        {
            byte[] bytesKey = null, bytesIv = null;
            String key = textBox_Key.Text.Trim(), iv = textBox_IV.Text.Trim();
            if (isIvEncrypt() && String.IsNullOrWhiteSpace(iv))
            {
                MessageBox.Show("偏移量不能为空！", "温馨提示");
            }

            if (comboBox_KeyDisplayFormat.SelectedItem.ToString().Equals("Base64String", StringComparison.CurrentCultureIgnoreCase))
            {
                bytesKey = Convert.FromBase64String(key);
                if (isIvEncrypt())
                {
                    bytesIv = Convert.FromBase64String(iv);
                }
            }
            else if (comboBox_KeyDisplayFormat.SelectedItem.ToString().Equals("BitString", StringComparison.CurrentCultureIgnoreCase))
            {
                bytesKey = key.ToByteArrayByBitString();
                if (isIvEncrypt())
                {
                    bytesIv = iv.ToByteArrayByBitString();
                }
            }
            else
            {
                MessageBox.Show("未知的显示格式：" + comboBox_KeyDisplayFormat.SelectedItem, "错误");
                return default(KeyValuePair<byte[],byte[]>);
            }

            return new KeyValuePair<byte[], byte[]>(bytesKey, bytesIv);
        }

        private void DisplayCiphertexts(byte[] bytes)
        {
            if (comboBox_CiphertextDisplayFormat.SelectedItem.ToString().Equals("Base64String", StringComparison.CurrentCultureIgnoreCase))
            {
                textBox_Result.Text = Convert.ToBase64String(bytes);
            }
            else if (comboBox_CiphertextDisplayFormat.SelectedItem.ToString().Equals("BitString", StringComparison.CurrentCultureIgnoreCase))
            {
                textBox_Result.Text = bytes.ToBitString("");
            }
            else
            {
                MessageBox.Show("未知的显示格式：" + comboBox_KeyDisplayFormat.SelectedItem, "错误");
            }
        }

        private byte[] CiphertextsToBytes()
        {
            String Ciphertexts = textBox_Body.Text.Trim();
            if (comboBox_CiphertextDisplayFormat.SelectedItem.ToString().Equals("Base64String", StringComparison.CurrentCultureIgnoreCase))
                return Convert.FromBase64String(Ciphertexts);

            if (comboBox_CiphertextDisplayFormat.SelectedItem.ToString().Equals("BitString", StringComparison.CurrentCultureIgnoreCase))
                return Ciphertexts.ToByteArrayByBitString();

            MessageBox.Show("未知的显示格式：" + comboBox_KeyDisplayFormat.SelectedItem, "错误");
            return null;
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
