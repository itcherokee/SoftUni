namespace OperatorsExpressionsStatements
{
    /// <summary>
    /// Represents a rectangle in 2D René Descarte's coordinate system.
    /// <param name="LeftUp">Holds X- and Y-axis coordinate for the upper left corner of the rectangle.</param>
    /// <param name="RightDown">Holds X- and Y-axis coordinate for the bottom right corner of the rectangle.</param>
    /// 
    /// </summary>
    internal class Rectangle
    {
        public Rectangle(double leftUpX = 0.0d, double leftUpY = 0.0d, double rightDownX = 0.0d, double rightDownY = 0.0d)
        {
            this.LeftUp = new Point(leftUpX, leftUpY);
            this.RightDown = new Point(rightDownX, rightDownY);
        }

        public Point LeftUp { get; set; }

        public Point RightDown { get; set; }
    }
}