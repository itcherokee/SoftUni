// Task 1:  Create a delegate CalculateInterest (or use Func<…>) with parameters sum of money, 
//          interest and years that calculates the interest according to the method it points to. 
//          The result should be rounded to 4 places after the decimal point.
//          .......
//          Create a class InterestCalculator that takes in its constructor money, interest, 
//          years and interest calculation delegate. 

namespace Interest
{
    using System;

    public class InterestCalculatorExec
    {
        public static void Main()
        {
            CalculateInterest calculator = GetCompoundInterest;
            var compound = new InterestCalculator(500, 0.056, 10, calculator);
            Console.WriteLine("Compound Interest = {0}", compound);
            calculator = GetSimpleInterest;
            var simple = new InterestCalculator(2500, 0.072, 15, calculator);
            Console.WriteLine("Simple Interest = {0}", simple);
            Console.ReadKey();
        }

        private static decimal GetSimpleInterest(decimal sum, double interest, double years)
        {
            return sum * (decimal)(1 + (interest * years));
        }

        private static decimal GetCompoundInterest(decimal sum, double interest, double years)
        {
            return sum * (decimal)Math.Pow(1 + (interest / 12), years * 12);
        }
    }
}
