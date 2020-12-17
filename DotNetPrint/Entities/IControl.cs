using System.Drawing;

namespace DotNetPrint.Entities
{
    /// <summary>
    /// 空间接口
    /// </summary>
    public interface IControl
    {
        /// <summary>
        /// 控件的X坐标
        /// </summary>
        int X { get; }
        /// <summary>
        /// 控件的Y坐标
        /// </summary>
        int Y { get; }
        /// <summary>
        /// 绘画
        /// </summary>
        /// <param name="graphics">绘图图画</param>
        void Draw(Graphics graphics);
        /// <summary>
        /// 复制
        /// </summary>
        /// <returns></returns>
        IControl Copy();
    }
}
