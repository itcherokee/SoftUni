namespace PrimitiveDataTypesAndVariables
{
    using System;

    /// <summary>
    /// Task:   13.Create a program that assigns null values to an integer and to a double variable. 
    ///         Try to print these variables at the console. Try to add some number or the null literal 
    ///         to these variables and print the result.
    /// </summary>
    public class NullableVariables
    {
        public static void Main()
        {
            int? integerNum = null;
            double? doubleNum = null;
            Console.WriteLine("{0,35}{1,10}", "Integer", "Double");
            Console.WriteLine("Initial values (null):{0,10}{1,10}", integerNum.GetValueOrDefault(), doubleNum.GetValueOrDefault());
            integerNum += 3;
            doubleNum += 3.0d;
            Console.WriteLine("Addition of number 3:{0,11}{1,10}", integerNum.GetValueOrDefault(), doubleNum.GetValueOrDefault());
            integerNum += null;
            doubleNum += null;
            Console.WriteLine("Addition of null:{0,15}{1,10}", integerNum.GetValueOrDefault(), doubleNum.GetValueOrDefault());
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("In three cases the values are null (we need explicitly to assign digitals to variables instead of adding it, because everything calculated with null as operand is null!)");
            Console.ReadKey();
        }
    } 
}