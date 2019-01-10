using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;

namespace MyDevTools.Plugin.UtilityTools.MyZXing
{
    public partial class DecodeBarCode : Form
    {
        public DecodeBarCode()
        {
            InitializeComponent();
        }

        private void benSelectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Bitmap Image|*.bmp|PNG Image|*.png|JPeg Image|*.jpg|Gif Image|*.gif",
                Title = "选择图标"
            };
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName.Length > 0)
                textBoxImagePath.Text = openFileDialog.FileName;
            RendderPictureBoxImage();
        }
        private void RendderPictureBoxImage()
        {
            string imagePath = textBoxImagePath.Text.Trim();
            if (imagePath.Length <= 0) return;
            if (!System.IO.File.Exists(imagePath))
            {
                MessageBox.Show("图片不存在！");
                return;
            }

            using (System.IO.FileStream fs = new System.IO.FileStream(textBoxImagePath.Text.Trim(), System.IO.FileMode.Open))
            {
                if (pictureBoxImage.Image != null) pictureBoxImage.Image.Dispose();
                pictureBoxImage.Image = new Bitmap(fs);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            BarcodeReader barcodeReader = new BarcodeReader();
            barcodeReader.Options.CharacterSet = "UTF-8";
            Result result = barcodeReader.Decode((Bitmap)pictureBoxImage.Image);
            if (result != null)
                textBox2.Text = result.Text;
            else
            {
                MessageBox.Show("无法识别的条码！");
                textBox2.Text = "";
            }
        }
    }
}
