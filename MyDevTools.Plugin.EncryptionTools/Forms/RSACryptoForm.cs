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

namespace MyDevTools.Plugin.EncryptionTools
{
    public partial class RSACryptoForm : Form
    {
        LogProvider.Interfaces.ILogSaveProvider logSaveProvider = new LogProvider.LogSaveLocalhostProvider();
        public RSACryptoForm()
        {
            InitializeComponent();
        }

        private void CreateKey_Click(object sender, EventArgs e)
        {
            var key = RSACrypto.CreateKey();

            textBox_PublicKey.Text = key.PublicKey;
            textBox_PrivateKey.Text = key.PrivateKey;
        }

        private void PublicKeyEncrypt_Click(object sender, EventArgs e)
        {
            String body = textBox_Body.Text.Trim(), publicKey = textBox_PublicKey.Text.Trim();

            if (String.IsNullOrEmpty(body))
            {
                MessageBox.Show("待处理文本不能为空", "温馨提示");
                return;
            }
            if (String.IsNullOrEmpty(publicKey))
            {
                MessageBox.Show("公钥不能为空", "温馨提示");
                return;
            }

            try
            {
                textBox_CryptBody.Text = RSACrypto.Encrypt(body, publicKey, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");

                logSaveProvider.SaveLog(LogProvider.Factories.LogEntityFactory.Create(ex));
            }
        }

        private void PublicKeyVerifyHash_Click(object sender, EventArgs e)
        {
            String body = textBox_Body.Text.Trim(), 
                publicKey = textBox_PublicKey.Text.Trim(),
                signa = textBox_Signa.Text.Trim();

            if (String.IsNullOrEmpty(body))
            {
                MessageBox.Show("待处理文本不能为空", "温馨提示");
                return;
            }
            if (String.IsNullOrEmpty(signa))
            {
                MessageBox.Show("签名不能为空", "温馨提示");
                return;
            }
            if (String.IsNullOrEmpty(publicKey))
            {
                MessageBox.Show("公钥不能为空", "温馨提示");
                return;
            }

            try
            {
                bool b=  RSACrypto.VerifyHash(publicKey, body, signa);

                textBox_CryptBody.Text = b ? "验证成功" : "验证失败";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
                logSaveProvider.SaveLog(LogProvider.Factories.LogEntityFactory.Create(ex));
            }
        }

        private void PrivateKeySigna_Click(object sender, EventArgs e)
        {
            String body = textBox_Body.Text.Trim(), privateKey = textBox_PrivateKey.Text.Trim();

            if (String.IsNullOrEmpty(body))
            {
                MessageBox.Show("待处理文本不能为空", "温馨提示");
                return;
            }
            if (String.IsNullOrEmpty(privateKey))
            {
                MessageBox.Show("私钥不能为空", "温馨提示");
                return;
            }

            try
            {
                textBox_Signa.Text = RSACrypto.HashAndSign(body, privateKey);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
                logSaveProvider.SaveLog(LogProvider.Factories.LogEntityFactory.Create(ex));
            }
        }

        private void PrivateKeyDncrypt_Click(object sender, EventArgs e)
        {
            String body = textBox_Body.Text.Trim(), privateKey = textBox_PrivateKey.Text.Trim();

            if (String.IsNullOrEmpty(body))
            {
                MessageBox.Show("待处理文本不能为空", "温馨提示");
                return;
            }
            if (String.IsNullOrEmpty(privateKey))
            {
                MessageBox.Show("私钥不能为空", "温馨提示");
                return;
            }

            //textBox_CryptBody.Text = RSACrypto.Decrypt(body, privateKey, false);
            try
            {
                textBox_CryptBody.Text = RSACrypto.Decrypt(body, privateKey, false);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
                logSaveProvider.SaveLog(LogProvider.Factories.LogEntityFactory.Create(ex));
            }
        }

        private void CopyPrivateKey_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox_PrivateKey.Text.Trim());
        }

        private void CopyPublicKey_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox_PublicKey.Text.Trim());
        }

        private void CopyCryptBody_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox_CryptBody.Text.Trim());
        }

        private void CopySigna_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox_Signa.Text.Trim());
        }
    }
}
