using SkiaSharp;

namespace LabelCore.Entities
{
    /// <summary>
    /// 控件基类
    /// </summary>
    public abstract class BaseControl: IControl
    {
        /// <summary>
        /// 控件的X坐标
        /// </summary>
        public float X { get; set; }
        /// <summary>
        /// 控件的Y坐标
        /// </summary>
        public float Y { get; set; }
        /// <summary>
        /// 复制
        /// </summary>
        /// <returns></returns>
        public abstract IControl Copy();
        /// <summary>
        /// 绘画
        /// </summary>
        /// <param name="canvas">画布</param>
        public abstract void Draw(SKCanvas canvas);
    }
}
