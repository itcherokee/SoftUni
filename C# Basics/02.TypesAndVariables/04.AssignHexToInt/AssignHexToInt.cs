namespace PrimitiveDataTypesAndVariables
{
    using System;

    /// <summary>
    /// Task: 4. Declare an integer variable and assign it with the value 254 in hexadecimal format (0x##). Use Windows Calculator to find its hexadecimal representation. Print the variable and ensure that the result is “254”.
    /// </summary>
    public class AssignHexToInt
    {
        public static void Main()
        {
            const int result = 0xFE;
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}