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

namespace MyDevTools.Plugin.UtilityTools.MyQRCoder
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void textBoxContext_TextChanged(object sender, EventArgs e)
        {
            SetQrCoder();
        }

        private void CEELevel_SelectedValueChanged(object sender, EventArgs e)
        {
            SetQrCoder();
        }

        private void SetQrCoder()
        {
            string context = textBoxContext.Text.Trim();
            string strLevel = CEELevel.SelectedItem.ToString();
            QRCoder.QRCodeGenerator.ECCLevel level = default(QRCoder.QRCodeGenerator.ECCLevel);
            if (!Enum.TryParse(strLevel, out level))
            {
                MessageBox.Show("未知纠错码等级！");
            }
            using (QRCoder.QRCodeGenerator cenerator = new QRCoder.QRCodeGenerator())
            {
                var qrCodeData = cenerator.CreateQrCode(context, level, true);
                using (QRCoder.QRCode rCode = new QRCoder.QRCode(qrCodeData))
                {
                    this.pictureBox1.Image = rCode.GetGraphic(10, Color.Black, Color.White, icon: GetIconBitmap(), iconSizePercent: (int)textBoxImageSize.Value);
                    pictureBox1.Size = new Size(pictureBox1.Width, pictureBox1.Height);
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }

            }
        }


        private Bitmap GetIconBitmap()
        {
            Bitmap img = null;
            if (iconPath.Text.Length > 0)
            {
                try
                {
                    img = new Bitmap(iconPath.Text);
                }
                catch (Exception)
                {
                }
            }
            return img;
        }
        private void MainForm_Resize(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(Width-40, Width-40);
        }

        private void btnCreateQrCoder_Click(object sender, EventArgs e)
        {
            SetQrCoder();
        }

        private void btnSaveQrCoder_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Bitmap Image|*.bmp|PNG Image|*.png|JPeg Image|*.jpg|Gif Image|*.gif";
            saveFileDialog.Title = "保存二维码";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != null && saveFileDialog.FileName.Length > 0)
            {
                using(System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
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

        private void btnSelectIcon_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Bitmap Image|*.bmp|PNG Image|*.png|JPeg Image|*.jpg|Gif Image|*.gif";
            openFileDialog.Title = "选择图标";
            openFileDialog.ShowDialog();
            iconPath.Text = openFileDialog.FileName;
            SetQrCoder();
        }
    }
}
