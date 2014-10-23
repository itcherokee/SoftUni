namespace Shape
{
    using System;

    public class Rectangle : BasicShape
    {
        public Rectangle(double width, double height)
            : base(width, height)
        {
        }

        public new double Width
        {
            get
            {
                return base.Width;
            }

            set
            {
                base.Width = value;
            }
        }

        public new double Height
        {
            get
            {
                return base.Height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Side cannot be zero or negative.");
                }

                base.Height = value;
            }
        }

        public override double CalculateArea()
        {
            return this.Width * this.Height;
        }

        public override double CalculatePerimeter()
        {
            return (2 * this.Width) + (2 * this.Height);
        }
    }
}
