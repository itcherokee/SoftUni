namespace Shape
{
    using System;
    
    public class Triangle : BasicShape
    {
        private double sideC;

        public Triangle(double sideA, double sideB, double sideC)
            : base(sideA, sideB)
        {
            this.SideC = sideC;
            if (!this.IsValidTriangle())
            {
                throw new InvalidOperationException("Invalid triangle!");
            }
        }

        public double SideA
        {
            get
            {
                return this.Width;
            }

            set
            {
                this.Width = value;
            }
        }

        public double SideB
        {
            get
            {
                return this.Height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Side cannot be a negative.");
                }

                this.Height = value;
            }
        }

        protected double SideC
        {
            get
            {
                return this.sideC;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Side cannot be a negative.");
                }

                this.sideC = value;
            }
        }

        public override double CalculateArea()
        {
            var halfPerimeter = this.CalculatePerimeter() / 2;
            return Math.Sqrt(halfPerimeter * (halfPerimeter - this.SideA) * (halfPerimeter - this.SideB) * (halfPerimeter - this.SideC));
        }

        public override double CalculatePerimeter()
        {
            return this.SideA + this.SideB + this.SideC;
        }

        private bool IsValidTriangle()
        {
            return !(this.SideA + this.SideB <= this.SideC) &&
                !(this.SideA + this.SideC <= this.SideB) &&
                !(this.SideB + this.SideC <= this.SideA);
        }
    }
}
