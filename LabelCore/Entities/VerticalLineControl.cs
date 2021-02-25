namespace LabelCore.Entities
{
    /// <summary>
    /// 垂直直线
    /// </summary>
    public class VerticalLineControl: StraightLineControl
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
                EndY = Y+value;
                EndX = X;
                _length = value;
            }
        }

        public override IControl Copy()
        {
            return new VerticalLineControl()
            {
                X = X,
                Y = Y,
                Pen = Pen,
                Length = base.Length
            };
        }
    }
}
