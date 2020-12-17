using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;

namespace DotNetPrint.Entities
{
    /// <summary>
    /// 标签
    /// </summary>
    public class Label
    {
        /// <summary>
        /// 标签名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 标签中元素的单位
        /// <para>
        /// World 将世界坐标系单位指定为度量单位
        /// </para>
        /// <para>
        /// Display 指定显示设备的度量单位。 通常，视频显示使用的单位是像素；打印机使用的单位是 1/100 英寸。
        /// </para>
        /// <para>
        /// Pixel 将设备像素指定为度量单位
        /// </para>
        /// <para>
        /// Point  将打印机点（1/72 英寸）指定为度量单位。
        /// </para>
        /// <para>
        /// Inch 将英寸指定为度量单位
        /// </para>
        /// <para>
        /// Document 将文档单位（1/300 英寸）指定为度量单位。
        /// </para>
        /// <para>
        /// Millimeter 将毫米指定为度量单位
        /// </para>
        /// </summary>
        public GraphicsUnit GraphicsUnit { get; set; }
        /// <summary>
        /// 标签宽度
        /// <para>单位为毫米</para>
        /// </summary>
        public float Width { get; set; }
        /// <summary>
        /// 标签高度
        /// <para>单位为毫米</para>
        /// </summary>
        public float Height { get; set; }
        /// <summary>
        /// 左边距宽度
        /// <para>单位为毫米</para>
        /// </summary>
        public float Left { get; set; } = 0;
        /// <summary>
        /// 右边距宽度
        /// <para>单位为毫米</para>
        /// </summary>
        public float Right { get; set; } = 0;
        /// <summary>
        /// 上边距宽度
        /// <para>单位为毫米</para>
        /// </summary>
        public float Top { get; set; } = 0;
        /// <summary>
        /// 下边距宽度
        /// <para>单位为毫米</para>
        /// </summary>
        public int Bottom { get; set; } = 0;
        /// <summary>
        /// 标签中的空间
        /// </summary>
        public List<IControl> Controls { get; set; } = new List<IControl>();

        /// <summary>
        /// 打印名称
        /// </summary>
        /// <param name="PrinterName">指定打印机名称，为空则为默认打印</param>
        /// <param name="copies">打印份数</param>
        public void Print(string PrinterName,short copies)
        {
            var pd = new PrintDocument();

            // 设置打印机
            if (!string.IsNullOrEmpty(PrinterName))
                pd.PrinterSettings.PrinterName = PrinterName;

            // 设置页面设置
            SetPageSettings(pd.DefaultPageSettings);

            // 设置打印份数
            pd.PrinterSettings.Copies = copies == 0 ? (short)1 : copies;
            pd.DocumentName = Name;
            pd.BeginPrint += Pd_BeginPrint;
            pd.PrintPage += Pd_PrintPage;
            pd.QueryPageSettings += Pd_QueryPageSettings;

            if (!pd.PrinterSettings.IsValid)
            {
                throw new Exception("未设置有效打印机，不能打印！");
            }
            // 开启打印进程
            pd.Print();
        }

        /// <summary>
        /// 设置页面设置
        /// </summary>
        /// <param name="pageSettings"></param>
        private void SetPageSettings(PageSettings pageSettings)
        {
            pageSettings.PaperSize = new PaperSize()
            {
                /**
                 * 1英寸=25.4毫米
                 * 1毫米=0.04英寸
                 * */
                Width = (int)(Width * 100 / 25.4),
                Height = (int)(Height * 100 / 25.4),
            };
            pageSettings.Margins = new Margins()
            {
                Top = (int)(Top * 100 / 25.4),
                Bottom = (int)(Bottom * 100 / 25.4),
                Left = (int)(Left * 100 / 25.4),
                Right = (int)(Right * 100 / 25.4),
            };
        }

        private void Pd_QueryPageSettings(object sender, QueryPageSettingsEventArgs e)
        {
            Console.WriteLine($"QueryPageSettings：打印输出前触发。sender:【{sender.GetType().FullName}】");
            Console.WriteLine($"打印机【{e.PageSettings.PrinterSettings.PrinterName}】是默认打印机：【{ e.PageSettings.PrinterSettings.IsDefaultPrinter}】");
        }

        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Console.WriteLine($"PrintPage：打印输出时触发。sender:【{sender.GetType().FullName}】");

            Console.WriteLine($"纸张大小【{e.PageSettings.PaperSize.PaperName}】");
            Console.WriteLine($"打印机【{ e.PageSettings.PrinterSettings.PrinterName}】");

            e.Graphics.PageUnit = GraphicsUnit;

            foreach(var control in Controls)
            {
                control.Draw(e.Graphics);
            }
        }

        private void Pd_BeginPrint(object sender, PrintEventArgs e)
        {
            Console.WriteLine($"BeginPrint：开始打印前触发。sender:【{sender.GetType().FullName}】");
        }
    }
}
