using System;
using System.Drawing;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;

namespace MyDevTools.Plugin.UtilityTools.MyZXing
{
    public partial class DecodeQRCoder : Form
    {
        public DecodeQRCoder()
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
            if(!System.IO.File.Exists(imagePath))
            {
                MessageBox.Show("图片不存在！");
                return;
            }

            using (System.IO.FileStream fs = new System.IO.FileStream(textBoxImagePath.Text.Trim(), System.IO.FileMode.Open))
            {
                pictureBoxImage.Image = new Bitmap(fs);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QRCodeReader qRCodeReader = new QRCodeReader();

            var bitmapLuminanceSource = new BitmapLuminanceSource((Bitmap)pictureBoxImage.Image);
            GlobalHistogramBinarizer globalHistogramBinarizer = new GlobalHistogramBinarizer(bitmapLuminanceSource);
            BinaryBitmap binaryBitmap = new BinaryBitmap(globalHistogramBinarizer);
            Result result = qRCodeReader.decode(binaryBitmap);
            if (result != null)
                textBox2.Text = result.Text;
            else
            {
                MessageBox.Show("无法识别的二维码！");
                textBox2.Text = "";
            }
        }
    }
}
