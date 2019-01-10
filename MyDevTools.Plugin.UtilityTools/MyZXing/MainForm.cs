using System;
using System.Windows.Forms;

namespace MyDevTools.Plugin.UtilityTools.MyZXing
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnDecodeQRCode_Click(object sender, EventArgs e)
        {
            new DecodeQRCoder() {
               Text="识别二维码",
                StartPosition = FormStartPosition.CenterScreen
            }.Show();
        }

        private void btnEncodeQRCode_Click(object sender, EventArgs e)
        {
            new EncodeQRCoder()
            {
                Text = "生成二维码",
                StartPosition = FormStartPosition.CenterScreen
            }.Show();
        }

        private void btnEncodeBarCode_Click(object sender, EventArgs e)
        {
            new EncodeBarCode
            {
                Text=btnEncodeBarCode.Text,
                StartPosition = FormStartPosition.CenterScreen
            }.Show();
        }

        private void btnDecodeBarCode_Click(object sender, EventArgs e)
        {
            new DecodeBarCode
            {
                Text=btnEncodeBarCode.Text,
                StartPosition = FormStartPosition.CenterScreen
            }.Show();
        }
    }
}
