using System;
using System.Drawing;

namespace DotNetPrint.Entities
{
    /// <summary>
    /// 直线
    /// </summary>
    public class StraightLineControl : BaseLineControl
    {
        /// <summary>
        /// 直线结束点X坐标
        /// </summary>
        public int EndX { get; set; }
        /// <summary>
        /// 直线结束点Y坐标
        /// </summary>
        public int EndY { get; set; }

        /// <summary>
        /// 返回直线长度
        /// </summary>
        public int Length
        {
            get
            {
               return (int)  Math.Sqrt(Math.Pow(EndX - X, 2) + Math.Pow(EndY - Y, 2));
            }
        }

        public override IControl Copy()
        {
            return new StraightLineControl()
            {
                X = X,
                Y = Y,
                EndX = EndX,
                EndY = EndY,
                Pen = Pen,
            };
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawLine(Pen, new PointF(X, Y), new Point(EndX, EndY));
        }
    }
}
