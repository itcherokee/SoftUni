namespace OperatorsExpressionsStatements
{
    /// <summary>
    /// Represents a point in 2D René Descarte's coordinate system.
    /// <param name="X">Point X-axis coordinate.</param>
    /// <param name="Y">Point Y-axis coordinate.</param>
    /// </summary>
    internal class Point
    {
        public Point(double x = 0.0d, double y = 0.0d)
        {
            this.X = x;
            this.Y = y;
        }

        public double X { get; set; }

        public double Y { get; set; }
    }
}