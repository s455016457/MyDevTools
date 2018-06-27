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
    public partial class MD5CryptoForm : Form
    {
        public MD5CryptoForm()
        {
            InitializeComponent();
            comboBox_CiphertextDisplayFormat.SelectedIndex = 0;
        }

        private void button_Md5Crypto_Click(object sender, EventArgs e)
        {
            DisplayCiphertexts(MD5Crypto.Encryptor(Encoding.UTF8.GetBytes(textBox_body.Text.Trim())));
        }

        private void button_HashCrypto_Click(object sender, EventArgs e)
        {
            DisplayCiphertexts(MD5Crypto.Hash(Encoding.UTF8.GetBytes(textBox_body.Text.Trim())));
        }

        private void button_CopyResult_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox_Result.Text.Trim() ?? String.Empty);
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals("\x1"))
            {
                (sender as TextBox).SelectAll();
                e.Handled = true;
            }
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
                MessageBox.Show("未知的显示格式：" + comboBox_CiphertextDisplayFormat.SelectedItem, "错误");
            }
        }
    }
}
