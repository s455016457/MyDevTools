namespace LabelCore.Entities
{
    /// <summary>
    /// 水平直线
    /// </summary>
    public class HorizontalLineControl : StraightLineControl
    {
        private int _length;
        /// <summary>
        /// 长度
        /// </summary>
        public new int Length
        {
            get { return _length; }
            set
            {
                EndY = Y;
                EndX = X + value;
                _length = value;
            }
        }

        public override IControl Copy()
        {
            return new HorizontalLineControl()
            {
                X=X,
                Y=Y,
                Pen=Pen,
                Length=_length,
            };
        }
    }
}
