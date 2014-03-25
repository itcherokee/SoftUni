namespace OperatorsExpressionsStatements
{
    internal class Trapezoid
    {
        public Trapezoid(double upperBase = 0.0, double bottomBase = 0.0, double height = 0.0)
        {
            this.UpperBase = upperBase;
            this.BottomBase = bottomBase;
            this.Height = height;
        }

        public double BottomBase { get; set; }

        public double UpperBase { get; set; }

        public double Height { get; set; }

        internal double GetArea()
        {
            return ((this.BottomBase + this.UpperBase) / 2) * this.Height;
        }
    } 
}