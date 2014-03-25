namespace OperatorsExpressionsStatements
{
    /// <summary>
    /// Represents a circle 2D René Descarte's coordinate system.
    /// <param name="radius">Circle radius.</param>
    /// <param name="X">Circle center X-axis coordinate.</param>
    /// <param name="Y">Circle center Y-axis coordinate.</param>
    /// </summary>
    internal class Circle : Point
    {
        public Circle(double radius, double x = 0.0d, double y = 0.0d)
            : base(x, y)
        {
            this.Radius = radius;
        }

        public double Radius { get; set; }
    }
}