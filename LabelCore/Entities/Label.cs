using SkiaSharp;
using System.Collections.Generic;
using System.IO;

namespace LabelCore.Entities
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
        /// 标签宽度
        /// <para>单位为毫米</para>
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// 标签高度
        /// <para>单位为毫米</para>
        /// </summary>
        public int Height { get; set; }
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
        /// 渲染
        /// </summary>
        /// <param name="stream">渲染到指定的流</param>
        /// <param name="imageFormat">图像格式</param>
        /// <param name="quality">图像的质量级别</param>
        public void Render(SKWStream stream, SKEncodedImageFormat imageFormat,int quality)
        {
            SkiaSharp.SKBitmap SKBitmap = new SKBitmap(new SKImageInfo(200, 200, SKColorType.Argb4444));
            SKCanvas sKCanvas = new SKCanvas(SKBitmap);

            foreach (var control in Controls)
            {
                control.Draw(sKCanvas);
            }

            SKBitmap.Encode(stream, imageFormat, quality);
        }
        /// <summary>
        /// 渲染
        /// </summary>
        /// <param name="stream">渲染到指定的流</param>
        /// <param name="imageFormat">图像格式</param>
        /// <param name="quality">图像的质量级别</param>
        public void Render(Stream stream, SKEncodedImageFormat imageFormat, int quality)
        {
            SkiaSharp.SKBitmap SKBitmap = new SKBitmap(new SKImageInfo(200, 200, SKColorType.Argb4444));
            SKCanvas sKCanvas = new SKCanvas(SKBitmap);

            foreach (var control in Controls)
            {
                control.Draw(sKCanvas);
            }

            SKBitmap.Encode(stream, imageFormat, quality);
        }
        /// <summary>
        /// 渲染标签
        /// </summary>
        /// <param name="filePath">要渲染标签的保存的文件路径</param>
        /// <param name="imageFormat">图像格式</param>
        /// <param name="quality">图像的质量级别</param>
        public void Render(string filePath, SKEncodedImageFormat imageFormat, int quality)
        {
            var SKBitmap = new SKBitmap(new SKImageInfo(Width, Height, SKColorType.Argb4444));
            var sKCanvas = new SKCanvas(SKBitmap);

            foreach (var control in Controls)
            {
                control.Draw(sKCanvas);
            }
            var stream = new SKFileWStream(filePath);
            SKBitmap.Encode(stream, imageFormat, quality);
        }
    }
}
