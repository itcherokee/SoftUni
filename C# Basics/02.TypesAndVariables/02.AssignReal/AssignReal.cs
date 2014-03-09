namespace PrimitiveDataTypesAndVariables
{
    using System;

    /// <summary>
    /// Task: 2. Which of the following values can be assigned to a variable of type float and which to a variable 
    ///          of type double: 34.567839023, 12.345, 8923.1234857, 3456.091? Write a program to assign the numbers 
    ///          in variables and print them to ensure no precision is lost.
    /// </summary>
    public class AssignReal
    {
        public static void Main()
        {
            double numberOne = 34.567839023;
            float numberTwo = 12.345F;
            double numberThree = 8923.1234857;
            float numberFour = 3456.091F;
            Console.WriteLine("double: {0}", numberOne);
            Console.WriteLine("float: {0}", numberTwo);
            Console.WriteLine("double: {0}", numberThree);
            Console.WriteLine("float: {0}", numberFour);
        }
    } 
}