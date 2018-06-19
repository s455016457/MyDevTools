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
    public partial class MD5CryptoForm : Form
    {
        public MD5CryptoForm()
        {
            InitializeComponent();
        }

        private void button_Md5Crypto_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = MD5Crypto.Encrypto(textBox_body.Text.Trim());
        }

        private void button_HashCrypto_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = MD5Crypto.Hash(textBox_body.Text.Trim());
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
    }
}
