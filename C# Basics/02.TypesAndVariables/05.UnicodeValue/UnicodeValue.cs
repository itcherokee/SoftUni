namespace PrimitiveDataTypesAndVariables
{
    using System;

    /// <summary>
    /// Task:   5. Declare a character variable and assign it with the symbol that has Unicode code 72, and then print it. 
    ///         Hint: first, use the Windows Calculator to find the hexadecimal representation of 72. 
    ///         The output should be “H”.
    /// </summary>
    public class UnicodeValue
    {
        public static void Main()
        {
            const char symbol = '\u0048';
            Console.Write("Symbol with Unicode code {0} (Hex:{0:X}) is ", (int)symbol);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(symbol);
            Console.ReadKey();
        }
    } 
}