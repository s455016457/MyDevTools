using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace MyDevTools.Plugin.UtilityTools.MyZXing
{
    public partial class EncodeBarCode : Form
    {
        public EncodeBarCode()
        {
            InitializeComponent();
        }

        private void btnSaveBarCode_Click(object sender, EventArgs e)
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

        private void BarCodeType_TextChanged(object sender, EventArgs e)
        {
            RenderBarCode();
        }

        private void RenderBarCode()
        {
            string context = textBox1.Text.Trim();
            string strbarCodeType = BarCodeType.SelectedItem.ToString();
            if (context.Length == 0) return;
            BarcodeFormat barcodeFormat = default(BarcodeFormat);

            if (!Enum.TryParse(strbarCodeType, out barcodeFormat))
            {
                MessageBox.Show("未知条码类型！");
                return;
            }

            try
            {
                CheckContext(barcodeFormat);
                pictureBox1.Image = new BarcodeWriter()
                {
                    Format = barcodeFormat,
                    Options = new ZXing.Common.EncodingOptions
                    {
                        Margin = (int)numericUpDown1.Value,
                        Width = (barcodeFormat == BarcodeFormat.QR_CODE
                            || barcodeFormat == BarcodeFormat.AZTEC 
                            || barcodeFormat == BarcodeFormat.DATA_MATRIX 
                            || barcodeFormat == BarcodeFormat.PDF_417) ? 400 : 20,
                        Height = barcodeFormat == BarcodeFormat.QR_CODE 
                            || barcodeFormat == BarcodeFormat.AZTEC 
                            || barcodeFormat == BarcodeFormat.DATA_MATRIX 
                            || barcodeFormat == BarcodeFormat.PDF_417 ? 400 : 200,
                    }
                }.Write(context);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CheckContext(BarcodeFormat barcodeFormat)
        {
            switch (barcodeFormat)
            {
                case BarcodeFormat.QR_CODE:
                case BarcodeFormat.CODE_128:
                case BarcodeFormat.CODE_39:
                case BarcodeFormat.AZTEC:
                case BarcodeFormat.PDF_417:
                case BarcodeFormat.DATA_MATRIX:
                    return;
            }

            var regex = new Regex(@"^[0-9]*$");
            string context = textBox1.Text.Trim();
            if(!regex.IsMatch(context))
                throw new Exception("内容必须为数字！");;

            if (barcodeFormat == BarcodeFormat.EAN_8 && context.Length != 7)
                throw new Exception($"内容长度必须为7！当前长度为【{context.Length}】");
            if (barcodeFormat == BarcodeFormat.EAN_13 && context.Length != 12)
            throw new Exception($"内容长度必须为12！当前长度为【{context.Length}】");
            if (barcodeFormat == BarcodeFormat.ITF && context.Length%2 != 0)
                throw new Exception($"内容长度必须为偶数！当前长度为【{context.Length}】");
        }

        private void btnCreateBarCode_Click(object sender, EventArgs e)
        {
            RenderBarCode();
        }
    }
}
