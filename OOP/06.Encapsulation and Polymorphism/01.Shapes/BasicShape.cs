namespace Shape
{
    using System;

    public abstract class BasicShape : IShape
    {
        private double width;
        private double height;

        protected BasicShape(double width = 0.0, double height = 0.0)
        {
            this.Width = width;
            this.Height = height;
        }

        protected double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Side cannot be zero or negative.");
                }

                this.width = value;
            }
        }

        protected double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Height cannot be zero or negative.");
                }

                this.height = value;
            }
        }

        public abstract double CalculateArea();

        public abstract double CalculatePerimeter();
    }
}