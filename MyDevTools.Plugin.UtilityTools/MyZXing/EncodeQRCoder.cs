using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode;

namespace MyDevTools.Plugin.UtilityTools.MyZXing
{
    public partial class EncodeQRCoder : Form
    {
        public EncodeQRCoder()
        {
            InitializeComponent();
        }

        private void btnSelectIcon_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateQrCoder_Click(object sender, EventArgs e)
        {
            RenderQRCoder();
        }

        private void btnSaveQrCoder_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Bitmap Image|*.bmp|PNG Image|*.png|JPeg Image|*.jpg|Gif Image|*.gif";
            saveFileDialog.Title = "保存二维码";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != null && saveFileDialog.FileName.Length > 0)
            {
                using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                {
                    ImageFormat imageFormat = null;
                    switch (saveFileDialog.FilterIndex)
                    {
                        case 1:
                            imageFormat = ImageFormat.Bmp;
                            break;
                        case 2:
                            imageFormat = ImageFormat.Png;
                            break;
                        case 3:
                            imageFormat = ImageFormat.Jpeg;
                            break;
                        case 4:
                            imageFormat = ImageFormat.Gif;
                            break;
                        default:
                            throw new NotSupportedException("File extension is not supported");
                    }

                    pictureBox1.Image.Save(fs, imageFormat);
                }
            }
        }

        private void textBoxContext_TextChanged(object sender, EventArgs e)
        {
            RenderQRCoder();
        }

        private void RenderQRCoder()
        {
            string context = textBoxContext.Text.Trim();
            string strLevel = CEELevel.SelectedItem.ToString();
            if (context.Length == 0) return;
            //QRCodeWriter qRCodeWriter = new ZXing.QrCode.QRCodeWriter();
            //var bitMatrix = qRCodeWriter.encode(context, BarcodeFormat.QR_CODE, pictureBox1.Width - 10, pictureBox1.Height - 10);
            pictureBox1.Image = new BarcodeWriter()
            {
                Format=BarcodeFormat.QR_CODE,
                Options=new QrCodeEncodingOptions
                {
                    CharacterSet="UTF-8",
                    Margin=1,
                    DisableECI=true,
                    Width= pictureBox1.Width - 10,
                    Height= pictureBox1.Height-10
                }                
            }.Write(context);
        }
    }
}
