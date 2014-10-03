// Task 1:  Write a program that reads an integer number and calculates and prints its square root. 
//          If the number is invalid or negative, print "Invalid number". In all cases finally print 
//          "Good bye". Use try-catch-finally.

namespace SquareRoot
{
    using System;

    public class SquareRoot
    {
        public static void Main()
        {
            const string ErrorMsg = "Invalid number!";
            try
            {
                Console.Write("Enter an integer:");
                string input = Console.ReadLine();
                int number = int.Parse(input);
                if (number < 0)
                {
                    throw new ArgumentException();
                }

                Console.WriteLine("Square root of number {0} is: {1}", number, Math.Sqrt(number));
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine(ErrorMsg);
            }
            catch (ArgumentException)
            {
                Console.WriteLine(ErrorMsg);
            }
            catch (FormatException)
            {
                Console.WriteLine("Number has not been entered in correct format.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Number is out of limits for the Integer type.");
            }
            finally
            {
                Console.WriteLine("Good bye!");
            }
        }
    }
}
