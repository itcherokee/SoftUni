namespace OperatorsExpressionsStatements
{
    /// <summary>
    /// Represents a circle 2D René Descarte's coordinate system.
    /// <param name="Radius">Circle radius.</param>
    /// <param name="X">Circle center X-axis coordinate.</param>
    /// <param name="Y">Circle center Y-axis coordinate.</param>
    /// 
    /// </summary>
    internal class Circle : Point
    {
        public Circle(int radius, int x = 0, int y = 0)
            : base(x, y)
        {
            this.Radius = radius;
        }

        public int Radius { get; set; }
    } 
}
