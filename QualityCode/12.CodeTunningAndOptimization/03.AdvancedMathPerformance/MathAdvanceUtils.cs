namespace AdvancedMathPerformance
{
    using System;

    internal class MathAdvanceUtils
    {
        internal static float SquareRoot(float operand)
        {
            float result = (float)Math.Sqrt(operand);
            return result;
        }

        internal static double SquareRoot(double operand)
        {
            double result = Math.Sqrt(operand);
            return result;
        }

        internal static decimal SquareRoot(decimal operand)
        {
            decimal result = (decimal)Math.Sqrt((double)operand);
            return result;
        }

        internal static float Logarithm(float operand)
        {
            float result = (float)Math.Log((double)operand);
            return result;
        }

        internal static double Logarithm(double operand)
        {
            double result = Math.Log(operand);
            return result;
        }

        internal static decimal Logarithm(decimal operand)
        {
            decimal result = (decimal)Math.Log((double)operand);
            return result;
        }

        internal static float Sinus(float angle)
        {
            float result = (float)Math.Sin((double)angle);
            return result;
        }

        internal static double Sinus(double angle)
        {
            double result = Math.Sin(angle);
            return result;
        }

        internal static decimal Sinus(decimal angle)
        {
            decimal result = (decimal)Math.Sin((double)angle);
            return result;
        }
    }
}
