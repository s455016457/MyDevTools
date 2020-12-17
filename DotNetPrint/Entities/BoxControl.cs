using System.Drawing;

namespace DotNetPrint.Entities
{
    /// <summary>
    /// 盒子
    /// </summary>
    public class BoxControl: BaseLineControl
    {
        /// <summary>
        /// 宽度
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// 高度
        /// </summary>
        public int Height { get; set; }

        public override IControl Copy()
        {
            return new BoxControl()
            {
                X = X,
                Y=Y,
                Height=Height,
                Width=Width,
                Pen=Pen
            };
        }

        public override void Draw(Graphics graphics)
        {
            var startPoint = new Point(X,Y);
            graphics.DrawLines(Pen, new Point[] {
                startPoint,
                new Point(startPoint.X+Width,startPoint.Y),
                new Point(startPoint.X+Width,startPoint.Y+Height),
                new Point(startPoint.X,startPoint.Y+Height),
                startPoint,
            });
        }
    }
}
