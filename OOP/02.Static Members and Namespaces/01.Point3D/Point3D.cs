namespace EuclidianSpace
{
    public class Point3D
    {
        private static readonly Point3D startingPoint = new Point3D();

        /// <summary>
        /// Initialize a new instance of <see cref="Point3D"/> class.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="z">Z coordinate.</param>
        public Point3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        /// <summary>
        /// Initialize a new instance of <see cref="Point3D"/> class 
        /// with coordinates at point {0,0,0}.
        /// </summary>
        public Point3D()
            : this(0, 0, 0)
        {
        }

        /// <summary>
        /// Gets starting point in Euclidian 3D space (0,0,0).
        /// </summary>
        public static Point3D StartingPoint
        {
            get { return startingPoint; }
        }

        /// <summary>
        /// Gets or sets X coordinate.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Gets or sets Y coordinate.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Gets or sets Z coordinate.
        /// </summary>
        public double Z { get; set; }

        /// <summary>
        /// Converts current instance of <see cref="Point3D"/> into
        /// string representation.
        /// </summary>
        /// <returns>String.string.</returns>
        public override string ToString()
        {
            return string.Format("X: {0}, Y: {1}, Z: {2}", this.X, this.Y, this.Z);
        }
    }
}
