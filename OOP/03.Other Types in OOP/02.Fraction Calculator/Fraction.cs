namespace Calculator
{
    using System;
    using System.Globalization;

    public struct Fraction
    {
        private const long Min = -9223372036854775808;
        private const long Max = 9223372036854775807;

        private long numerator;
        private long denominator;

        public Fraction(long numerator, long denominator)
            : this()
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public long Numerator
        {
            get
            {
                return this.numerator;
            }

            set
            {
                if (value < Min || value > Max)
                {
                    throw new ArgumentOutOfRangeException(
                        string.Format("Numerator", "Argument must be in the range [{0}...{1}]", Min, Max));
                }

                this.numerator = value;
            }
        }

        public long Denominator
        {
            get
            {
                return this.denominator;
            }

            set
            {
                if (value < Min || value > Max)
                {
                    throw new ArgumentOutOfRangeException(
                        string.Format("Numerator", "Argument must be in the range [{0}...{1}]", Min, Max));
                }

                if (value == 0)
                {
                    throw new DivideByZeroException("Denominator cannot be zero!");
                }

                this.denominator = value;
            }
        }

        public static Fraction operator +(Fraction fractionOne, Fraction fractionTwo)
        {
            long numeratorOne;
            long numeratorTwo;
            var lcm = PrepareOperations(fractionOne, fractionTwo, out numeratorOne, out numeratorTwo);
            return new Fraction(numeratorOne + numeratorTwo, lcm);
        }

        public static Fraction operator -(Fraction fractionOne, Fraction fractionTwo)
        {
            long numeratorOne;
            long numeratorTwo;
            var lcm = PrepareOperations(fractionOne, fractionTwo, out numeratorOne, out numeratorTwo);
            return new Fraction(numeratorOne - numeratorTwo, lcm);
        }

        public override string ToString()
        {
            return ((decimal)this.Numerator / this.Denominator).ToString(CultureInfo.InvariantCulture);
        }

        private static long PrepareOperations(
            Fraction fractionOne, Fraction fractionTwo, out long numeratorOne, out long numeratorTwo)
        {
            long lcm = fractionOne.Lcm(fractionOne.denominator, fractionTwo.denominator);
            numeratorOne = (lcm / fractionOne.denominator) * fractionOne.numerator;
            numeratorTwo = (lcm / fractionTwo.denominator) * fractionTwo.numerator;
            return lcm;
        }

        private long Lcm(long numberOne, long numberTwo)
        {
            long denominator = this.Gcd(numberOne, numberTwo);
            long numerator = Math.Abs(numberOne * numberTwo);
            return numerator / denominator;
        }

        private long Gcd(long numberOne, long numberTwo)
        {
            if (numberOne == 0 && numberTwo == 0)
            {
                throw new ArgumentOutOfRangeException("GCD parameters", "It is not allowed both parameters to be zero!");
            }

            long numerator;
            long denominator;
            if (this.FindMax(numberOne, numberTwo) == numberOne)
            {
                numerator = numberOne;
                denominator = numberTwo;
            }
            else
            {
                numerator = numberTwo;
                denominator = numberOne;
            }

            long result = 0;
            do
            {
                result = numerator % denominator;
                numerator = denominator;
                denominator = result;
            } 
            while (result > 0);

            return numerator;
        }

        private T FindMax<T>(T numberOne, T numberTwo) where T : IComparable<T>
        {
            return numberOne.CompareTo(numberTwo) <= 0 ? numberTwo : numberOne;
        }
    }
}