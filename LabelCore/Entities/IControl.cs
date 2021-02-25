using SkiaSharp;
using System.Drawing;

namespace LabelCore.Entities
{
    /// <summary>
    /// 空间接口
    /// </summary>
    public interface IControl
    {
        /// <summary>
        /// 控件的X坐标
        /// </summary>
        float X { get; }
        /// <summary>
        /// 控件的Y坐标
        /// </summary>
        float Y { get; }
        /// <summary>
        /// 绘画
        /// </summary>
        /// <param name="canvas">画布</param>
        void Draw(SKCanvas canvas);
        /// <summary>
        /// 复制
        /// </summary>
        /// <returns></returns>
        IControl Copy();
    }
}
