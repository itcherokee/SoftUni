namespace PrimitiveDataTypesAndVariables
{
    using System;

    /// <summary>
    /// Task:   10. Declare two integer variables a and b and assign them with 5 and 10 and after that exchange
    ///         their values. Print the variable values before and after the exchange.
    /// </summary>
    public class ExchangeInt
    {
        public static void Main()
        {
            Console.Title = "Exchange values of two integers - version 2";
            int numberOne = 5;
            int numberTwo = 10;
            Console.WriteLine("Number A={0}, Number B={1}", numberOne, numberTwo);
            numberOne = numberOne ^ numberTwo;
            numberTwo = numberOne ^ numberTwo;
            numberOne = numberOne ^ numberTwo;
            Console.WriteLine("After swap (using XOR and no temp variable):");
            Console.WriteLine("Number A={0}, Number B={1}", numberOne, numberTwo);
            Console.ReadKey();
        }
    } 
}