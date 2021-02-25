using SkiaSharp;

namespace LabelCore.Entities
{
    public class TextControl : BaseControl
    {
        /// <summary>
        /// 文本样式和颜色信息
        /// </summary>
        public SKPaint Paint { get; set; }

        public string Content { get; set; }

        public override IControl Copy()
        {
            return new TextControl()
            {
                X = X,
                Y = Y,
                Paint = Paint,
                Content=Content
            };
        }

        public override void Draw(SKCanvas canvas)
        {
            canvas.DrawText(Content, new SKPoint(X, Y), Paint);
        }
    }
}
