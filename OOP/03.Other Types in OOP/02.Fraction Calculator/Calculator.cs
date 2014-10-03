// Task 2:  Create a struct Fraction that holds the numerator and denominator of a fraction as fields.
//          A fraction is the division of two rational numbers (e.g. 22 / 7, where 22 is the numerator
//          and 7 is the denominator).
//              •   The struct constructor takes the numerator and denominator as arguments. 
//                  They are integer numbers in the range [-9223372036854775808…9223372036854775807]. 
//              •   Validate the input through properties. The denominator cannot be 0. Throw proper 
//                  exceptions with descriptive messages.
//              •   Overload the + and - operators to perform addition and subtraction on objects of 
//                  type Fraction. The result should be a new Fraction.
//              •   Override ToString() to print the fraction in floating-point format.

namespace Calculator
{
    using System;

    public class Calculator
    {
        public static void Main()
        {
            Fraction fraction1 = new Fraction(22, 7);
            Fraction fraction2 = new Fraction(40, 4); 
            Fraction result = fraction1 + fraction2;
            Console.WriteLine(result.Numerator);
            Console.WriteLine(result.Denominator);
            Console.WriteLine(result);
        }
    }
}
