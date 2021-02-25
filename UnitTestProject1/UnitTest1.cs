using LabelCore.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkiaSharp;
using System;
using System.Linq;
using System.IO;
using System.Reflection;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        public string savePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AppData");
        public UnitTest1()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(savePath);
            if (!directoryInfo.Exists)
                directoryInfo.Create();
        }
        [TestMethod]
        public void TestMethod1()
        {
            var label = new Label()
            {
                Width = 500,
                Height = 300,
                Name = "My Label Print"
            };

            //var songtiTypeface = SKTypeface.FromFamilyName("宋体");

            var index = SKFontManager.Default.FontFamilies.ToList().IndexOf("宋体");

            var songtiTypeface = SKFontManager.Default.GetFontStyles(index).CreateTypeface(0);

            var songtiPaint = new SKPaint(new SKFont(songtiTypeface) { Size =24})
            {
                Color = SKColor.Parse("000000"),
                Style = SKPaintStyle.StrokeAndFill
            };

            var segoeUiPaint = new SKPaint(new SKFont(SKTypeface.FromFamilyName("Algerian")))
            {
                Color = SKColor.Parse("000000"),
                Style = SKPaintStyle.StrokeAndFill
            };


            var titleText = new TextControl()
            {
                X = 100,
                Y = 20,
                Paint = songtiPaint,
                Content = "这里是抬头"
            };

            var qrCodeCntrol = new QrCodeControl()
            {
                X = 20,
                Y = 100,
                Height = 30,
                Width = 30,
                Content = "er wei ma bu zhi chi zhong wen ma ? 二维码不支持中文吗？",
            };

            var contentText = new TextControl()
            {
                X = 20,
                Y = 100,
                Paint = songtiPaint,
                Content = "物料编码"
            };

            var contentText1 = contentText.Copy() as TextControl;
            contentText1.X = 200;
            contentText1.Content = "LSKJFDOWIEFW";

            label.Controls.Add(titleText);
            //label.Controls.Add(qrCodeCntrol);
            label.Controls.Add(contentText);
            label.Controls.Add(contentText1);

            //contentText1 = contentText1.Copy() as TextControl;
            //contentText1.X = 10;
            //contentText1.Y = 10;
            //contentText1.Content = "A";
            //label.Controls.Add(contentText1);
            //contentText1 = contentText1.Copy() as TextControl;
            //contentText1.X = 10;
            //contentText1.Y = 290;
            //label.Controls.Add(contentText1);
            //contentText1 = contentText1.Copy() as TextControl;
            //contentText1.X = 490;
            //contentText1.Y = 290;
            //label.Controls.Add(contentText1);
            //contentText1 = contentText1.Copy() as TextControl;
            //contentText1.X = 490;
            //contentText1.Y = 10;
            //label.Controls.Add(contentText1);

            label.Render(Path.Combine(savePath, $"{DateTime.Now.Ticks}.png"), SKEncodedImageFormat.Png, 100);
        }
    }
}
