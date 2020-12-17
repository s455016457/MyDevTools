using System.Drawing;

namespace DotNetPrint.Entities
{
    public class TextControl : BaseControl
    {
        /// <summary>
        /// 字体
        /// </summary>
        public Font Font { get; set; }
        /// <summary>
        /// 笔刷
        /// </summary>
        public Brush Brush { get; set; }

        public string Content { get; set; }

        public override IControl Copy()
        {
            return new TextControl()
            {
                X = X,
                Y = Y,
                Font=Font,
                Brush=Brush,
                Content=Content
            };
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawString(Content, Font, Brush, X, Y);
        }
    }
}
