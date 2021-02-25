using SkiaSharp;
using ZXing;
using ZXing.QrCode;

namespace LabelCore.Entities
{
    /// <summary>
    /// 二维码控件
    /// </summary>
    public class QrCodeControl : BaseControl
    {
        /// <summary>
        /// 宽度
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// 高度
        /// </summary>
        public int Height { get; set; }
        public string Content { get; set; }
        public override IControl Copy()
        {
            return new QrCodeControl()
            {
                X=X,
                Y=Y,
                Height=Height,
                Width=Width,
                Content=Content
            };
        }

        public override void Draw(SKCanvas canvas)
        {
            canvas.DrawImage(CreateQrCode(), new SKPoint(X, Y));
        }
        private SKImage CreateQrCode()
        {
            return new BarcodeWriter<SKImage>()
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new QrCodeEncodingOptions
                {
                    Width = Width * 10,
                    Height = Height * 10,
                    CharacterSet = "UTF-8",
                    Margin = 0,
                    DisableECI = true,
                }
            }.Write(Content);
        }
    }
}
