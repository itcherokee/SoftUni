// Task 3:  Write a program to compare the performance of square root, natural logarithm, sinus 
//          for float, double and decimal values.

namespace AdvancedMathPerformance
{
    using System;
    using System.Diagnostics;

    public class AdvancedMathPerformance
    {
        public static void Main()
        {
            const float NumberFloat = 10000f;
            const double NumberDouble = 10000d;
            const decimal NumberDecimal = 10000m;
            const float AngleFloat = 20f;
            const double AngleDouble = 10000d;
            const decimal AngleDecimal = 10000m;

            var timeElapsed = new Stopwatch();

            // test square root performance
            float resultFloat;
            timeElapsed.Start();
            resultFloat = MathAdvanceUtils.SquareRoot(NumberFloat);
            timeElapsed.Stop();
            Console.WriteLine("Square root calculation of {0} in Float took: {1}", NumberFloat, timeElapsed.Elapsed);
            timeElapsed.Reset();

            double resultDouble;
            timeElapsed.Start();
            resultDouble = MathAdvanceUtils.SquareRoot(NumberDouble);
            timeElapsed.Stop();
            Console.WriteLine("Square root calculation of {0} in Double took: {1}", NumberDouble, timeElapsed.Elapsed);
            timeElapsed.Reset();

            decimal resultDecimal;
            timeElapsed.Start();
            resultDecimal = MathAdvanceUtils.SquareRoot(NumberDecimal);
            timeElapsed.Stop();
            Console.WriteLine("Square root calculation of {0} in Float took: {1}", NumberDecimal, timeElapsed.Elapsed);
            timeElapsed.Reset();

            // test natural logarythm performance
            timeElapsed.Start();
            resultFloat = MathAdvanceUtils.Logarithm(NumberFloat);
            timeElapsed.Stop();
            Console.WriteLine("Natural logarythm calculation of {0} in Float took: {1}", NumberFloat, timeElapsed.Elapsed);
            timeElapsed.Reset();

            timeElapsed.Start();
            resultDouble = MathAdvanceUtils.Logarithm(NumberDouble);
            timeElapsed.Stop();
            Console.WriteLine("Natural logarythm calculation of {0} in Double took: {1}", NumberDouble, timeElapsed.Elapsed);
            timeElapsed.Reset();

            timeElapsed.Start();
            resultDecimal = MathAdvanceUtils.Logarithm(NumberDecimal);
            timeElapsed.Stop();
            Console.WriteLine("Natural logarythm calculation of {0} in Float took: {1}", NumberDecimal, timeElapsed.Elapsed);
            timeElapsed.Reset();

            // test sinus performance
            timeElapsed.Start();
            resultFloat = MathAdvanceUtils.Sinus(AngleFloat);
            timeElapsed.Stop();
            Console.WriteLine("Sinus calculation of {0} degrees in Float took: {1}", AngleFloat, timeElapsed.Elapsed);
            timeElapsed.Reset();

            timeElapsed.Start();
            resultDouble = MathAdvanceUtils.Sinus(AngleDouble);
            timeElapsed.Stop();
            Console.WriteLine("Sinus calculation of {0} in Double took: {1}", AngleDouble, timeElapsed.Elapsed);
            timeElapsed.Reset();

            timeElapsed.Start();
            resultDecimal = MathAdvanceUtils.Sinus(AngleDecimal);
            timeElapsed.Stop();
            Console.WriteLine("Sinus calculation of {0} in Float took: {1}", AngleDecimal, timeElapsed.Elapsed);
        }
    }
}
