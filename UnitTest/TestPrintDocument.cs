using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;
using System.Drawing.Printing;
using ZXing;
using DotNetPrint.Entities;

namespace UnitTest
{
    [TestClass]
    public class TestPrintDocument
    {
        [TestMethod]
        public void HelloWorld()
        {
            var pd = new PrintDocument();
            // 设置打印机
            //pd.PrinterSettings.PrinterName = "Canon G3000 series Printer";
            pd.PrinterSettings.PrinterName = "Microsoft XPS Document Writer";
            Console.WriteLine($"打印机【{pd.PrinterSettings.PrinterName}】是默认打印机：【{ pd.PrinterSettings.IsDefaultPrinter}】");

            Console.WriteLine($"打印机【{pd.PrinterSettings.PrinterName}】纸张：");

            foreach(PaperSize pageSize in pd.PrinterSettings.PaperSizes)
            {
                Console.WriteLine($"【{pageSize.PaperName}】【{pageSize.Width}*{pageSize.Height}】");
            }

            // 设置纸张尺寸100mm*60mm
            pd.DefaultPageSettings.PaperSize = new PaperSize() { 
                PaperName="100*60",
                /**
                 * 1英寸=25.4毫米
                 * 1毫米=0.04英寸
                 * */
                Width=(int)(100*100/25.4),
                Height=(int)(60*100/25.4),
            };
            // 设置打印份数
            pd.PrinterSettings.Copies = 3;

            Console.WriteLine($"设置默认的打印纸尺为【{pd.DefaultPageSettings.PaperSize.PaperName}】【{pd.DefaultPageSettings.PaperSize.Width}*{pd.DefaultPageSettings.PaperSize.Height}】");

            pd.DocumentName = "标签打印";
            pd.BeginPrint += Pd_BeginPrint;
            pd.PrintPage += Pd_PrintPage;
            pd.QueryPageSettings += Pd_QueryPageSettings;
            // 开启打印进程
            pd.Print();
        }

        private void Pd_QueryPageSettings(object sender, QueryPageSettingsEventArgs e)
        {
            Console.WriteLine($"QueryPageSettings：打印输出前触发。sender:【{sender.GetType().FullName}】");

            var pd = sender as PrintDocument;
            Console.WriteLine($"打印机【{e.PageSettings.PrinterSettings.PrinterName}】是默认打印机：【{ e.PageSettings.PrinterSettings.IsDefaultPrinter}】");
        }

        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Console.WriteLine($"PrintPage：打印输出时触发。sender:【{sender.GetType().FullName}】");

            Console.WriteLine($"纸张大小【{e.PageSettings.PaperSize.PaperName}】");
            Console.WriteLine($"打印机【{ e.PageSettings.PrinterSettings.PrinterName}】");

            e.Graphics.PageUnit = GraphicsUnit.Millimeter;

            Font titleFont = new Font("黑体", 11, FontStyle.Bold);//标题字体
            Font fntTxt = new Font("宋体", 10, FontStyle.Regular);//正文文字
            Font fntTxt1 = new Font("宋体", 8, FontStyle.Regular);//正文文字
            Brush brush = new SolidBrush(Color.Black);//画刷           
            Pen pen = new Pen(Color.Black,0.2f);           //线条颜色  

            Console.WriteLine($"字体大小【{fntTxt1.Size}】【{fntTxt1.SizeInPoints}】");

            e.Graphics.DrawBox(pen, new Point(1,1),98,58);
            e.Graphics.DrawString("这里是标签标题", titleFont, brush, new PointF(32, 2));

            e.Graphics.DrawImage(CreateQrCode(), 2,4,30,30);

            e.Graphics.DrawString("物料编码", fntTxt,brush,new PointF(32,8));
            e.Graphics.DrawString("ALSDJFOWEIFWSDFJEW", fntTxt1, brush,new PointF(47,8));

            e.Graphics.DrawString("采购单号", fntTxt, brush, 32, 14);
            e.Graphics.DrawString("PO20089839", fntTxt1, brush, 47, 14);

            e.Graphics.DrawString("入库单号", fntTxt, brush, 32, 20);
            e.Graphics.DrawString("GRN20090928", fntTxt1, brush, 47, 20);

            e.Graphics.DrawString("采购批次", fntTxt, brush, 32, 26);
            e.Graphics.DrawString("1", fntTxt1, brush, 47, 26);

            e.Graphics.DrawString("入库批次", fntTxt, brush, 32, 32);
            e.Graphics.DrawString("4", fntTxt1, brush, 47, 32);

            e.Graphics.DrawString("标签编号", fntTxt, brush, 2, 38);
            e.Graphics.DrawString("48#", fntTxt1, brush, 19, 38);

            e.Graphics.DrawString("数量", fntTxt, brush, 32, 38);
            e.Graphics.DrawString("2000", fntTxt1, brush, 47, 38);

            e.Graphics.DrawString("规格型号", fntTxt, brush, 2, 42);
            e.Graphics.DrawString("老师课件丹佛胃说了肯德基佛违反晚上几点否违法了谁看得见佛为发上岛咖啡加沃尔夫", fntTxt1, brush,new RectangleF( 19, 42,79,34));
        }

        private void Pd_BeginPrint(object sender, PrintEventArgs e)
        {
            Console.WriteLine($"BeginPrint：开始打印前触发。sender:【{sender.GetType().FullName}】");
        }

        private Bitmap CreateQrCode()
        {

            return new BarcodeWriter()
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new ZXing.Common.EncodingOptions
                {
                    Width =  400,
                    Height =  400,
                }
            }.Write("GRNVEN032004098743;R-2301CXXX-001-NBF-CCN;1;20000;48#;PO2004098743;1");
        }

        [TestMethod]
        public void TestDotNetPrint()
        {
            var label = new Label() { 
                Width=100,
                Height=60,
                GraphicsUnit=GraphicsUnit.Millimeter,
                Name="My Label Print"
            };
            Font titleFont = new Font("黑体", 11, FontStyle.Bold);//标题字体
            Font fntTxt = new Font("宋体", 10, FontStyle.Regular);//正文文字
            Font fntTxt1 = new Font("宋体", 8, FontStyle.Regular);//正文文字
            Brush brush = new SolidBrush(Color.Black);//画刷           
            Pen pen = new Pen(Color.Black, 0.2f);           //线条颜色  

            var boxControl = new BoxControl()
            {
                X = 1,
                Y = 1,
                Width = 98,
                Height = 58,
                Pen=pen
            };

            var titleText = new TextControl()
            {
                X=35,
                Y=2,
                Font = titleFont,
                Brush= brush,
                Content="这里是抬头"
            };

            var horLine = new HorizontalLineControl()
            {
                X = 2,
                Y = 8,
                Pen = pen,
                Length = 96
            };

            var qrCodeCntrol = new QrCodeControl() { 
                X=2,
                Y=9,
                Height=30,
                Width=30,
                Content= "er wei ma bu zhi chi zhong wen ma ? 二维码不支持中文吗？",
            };

            var verLien = new VerticalLineControl() { 
                X=33,
                Y=9,
                Pen=pen,
                Length=30
            };

            var contentText = new TextControl()
            {
                X=34,
                Y=9,
                Brush=brush,
                Font=fntTxt,
                Content="物料编码"
            };

            var contentText1 = contentText.Copy() as TextControl;
            contentText1.X = 51;
            contentText1.Font = fntTxt1;
            contentText1.Content = "LSKJFDOWIEFW";

            label.Controls.Add(boxControl);
            label.Controls.Add(titleText);
            label.Controls.Add(horLine);
            label.Controls.Add(verLien);
            label.Controls.Add(qrCodeCntrol);
            label.Controls.Add(contentText);
            label.Controls.Add(contentText1);

            horLine = horLine.Copy() as HorizontalLineControl;
            horLine.Y = 40;
            horLine.Length = horLine.Length;
            label.Controls.Add(horLine);

            label.Print("Microsoft XPS Document Writer", 1);
        }
    }

    public static class GraphicsExtension {
        /// <summary>
        /// 绘制一个盒子
        /// </summary>
        /// <param name="graphics">绘图图画</param>
        /// <param name="pen">绘笔</param>
        /// <param name="startPoint">起始坐标</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        public static void DrawBox(this Graphics graphics,Pen pen, Point startPoint, int width,int height)
        {
            graphics.DrawLines(pen, new Point[] {
                startPoint,
                new Point(startPoint.X+width,startPoint.Y),
                new Point(startPoint.X+width,startPoint.Y+height),
                new Point(startPoint.X,startPoint.Y+height),
                startPoint,
            });
        }
    }
}
